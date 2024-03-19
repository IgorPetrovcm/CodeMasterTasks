namespace Autocomplete.Basic
{
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public sealed class LiveSearch
    {
        private static readonly string[] SimpleWords = File.ReadAllLines(@"Data/words.txt");
        private static readonly string[] MovieTitles = File.ReadAllLines(@"Data/movies.txt");
        private static readonly string[] StageNames = File.ReadAllLines(@"Data/stagenames.txt");

        private Thread? _searchThread;
        private CancellationTokenSource? _searchThreadCancellationTokenSource;

        public static string? FindBestSimilar(string example, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return null;
            }

            SimilarLine? stageResult = new SimilarLine(string.Empty, default);

            Thread stageResultThread = new Thread(
                () =>
                {
                    stageResult = BestSimilarInArray(StageNames, example);
                });

            /*if (cancellationToken.IsCancellationRequested)
            {
                return null;
            }*/

            SimilarLine movieResult = new SimilarLine(string.Empty, default);

            Thread movieResultThread = new Thread(
                () =>
                {
                    movieResult = BestSimilarInArray(MovieTitles, example);
                });

            /*if (cancellationToken.IsCancellationRequested)
            {
                return null;
            }*/

            SimilarLine wordResult = new SimilarLine(string.Empty, default);

            Thread wordResultThread = new Thread(
                () =>
                {
                    wordResult = BestSimilarInArray(SimpleWords, example);
                    
                });

            wordResultThread.Start();
            movieResultThread.Start();
            stageResultThread.Start();

            while (wordResultThread.ThreadState != ThreadState.Stopped)
            {}

            while (movieResultThread.ThreadState != ThreadState.Stopped)
            {}

            while (stageResultThread.ThreadState != ThreadState.Stopped)
            {}
            

            if (wordResult.SimilarityScore > movieResult.SimilarityScore &&
                wordResult.SimilarityScore > stageResult.SimilarityScore)
            {
                return wordResult.Line;
            }

            return (stageResult.IsBetterThan(movieResult) ? stageResult : movieResult).Line;
        }

        public void HandleTyping(HintedControl control)
        {
            if (_searchThread != null && _searchThreadCancellationTokenSource != null)
            {
                _searchThreadCancellationTokenSource.Cancel();
                _searchThread.Join();
            }

            _searchThreadCancellationTokenSource = new CancellationTokenSource();
            _searchThread = new Thread(
                () =>
                {
                    string? result = FindBestSimilar(control.LastWord, _searchThreadCancellationTokenSource.Token);
                    if (result != null)
                    {
                        control.Hint = result;
                    }
                });

            _searchThread.Start();
        }

        internal static SimilarLine BestSimilarInArray(string[] lines, string example)
        {
            return lines.Aggregate(
                new SimilarLine(string.Empty, 0),
                (SimilarLine best, string line) =>
                {
                    var current = new SimilarLine(line, line.Similarity(example));

                    return current.IsBetterThan(best) ? current : best;
                });
        }
    }
}
