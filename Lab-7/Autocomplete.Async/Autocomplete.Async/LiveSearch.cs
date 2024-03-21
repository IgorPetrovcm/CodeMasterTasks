namespace Autocomplete.Async
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class LiveSearch
    {
        private static readonly string[] SimpleWords = File.ReadAllLines(@"Data/words.txt");
        private static readonly string[] MovieTitles = File.ReadAllLines(@"Data/movies.txt");
        private static readonly string[] StageNames = File.ReadAllLines(@"Data/stagenames.txt");

        private CancellationTokenSource? _token;

        public async Task<string> FindBestSimilarAsync(string example)
        {
            if (_token != null)
            {
                _token.Cancel();
            }

            _token = new CancellationTokenSource();

            Task<SimilarLine> stageTask = BestSimilarInArray(StageNames, example, _token.Token);
            
            Task<SimilarLine> movieTask = BestSimilarInArray(MovieTitles, example, _token.Token);

            Task<SimilarLine> wordTask = BestSimilarInArray(SimpleWords, example, _token.Token);

            await Task.WhenAll(stageTask, movieTask, wordTask);

            SimilarLine wordResult = wordTask.Result; 

            SimilarLine stageResult = stageTask.Result;

            SimilarLine movieResult = movieTask.Result;

            if (wordResult.SimilarityScore > movieResult.SimilarityScore && wordResult.SimilarityScore > stageResult.SimilarityScore)
            {
                return wordResult.Line;
            }

            if (movieResult.IsBetterThan(stageResult))
                {
                return movieResult.Line;
            }

            _token.Cancel();

            return stageResult.Line;
        }

        public async void HandleTyping(HintedControl control)
        {
            control.Hint = await FindBestSimilarAsync(control.LastWord);
        }

        internal static Task<SimilarLine> BestSimilarInArray(string[] lines, string example, CancellationToken token)
        {
            Task<SimilarLine> task = Task.Factory.StartNew<SimilarLine>(
                () => 
                {
                    var best = new SimilarLine(string.Empty, 0);

                    foreach (var line in lines)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return new SimilarLine(string.Empty, default);
                        }

                        var currentLine = new SimilarLine(line, line.Similarity(example));

                        if (currentLine.IsBetterThan(best))
                        {
                            best = currentLine;
                        }
                    }

                    return best;
                }
            );

            return task;
        }
    }
}
