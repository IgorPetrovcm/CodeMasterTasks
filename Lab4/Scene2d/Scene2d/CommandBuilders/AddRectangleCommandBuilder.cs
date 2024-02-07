namespace Scene2d.CommandBuilders
{
    using System.Text.RegularExpressions;
    using Scene2d.Commands;
    using Scene2d.Exceptions;
    using Scene2d.Figures;

    public class AddRectangleCommandBuilder : ICommandBuilder
    {
        private static readonly Regex RecognizeRegex = new Regex(@"add rectangle ([a-zA-Z0-9\-_]+) \((-?\d+),\s?(-?\d+)\) \((-?\d+),\s?(-?\d+)\)");

        /* Should be set in AppendLine method */
        private IFigure _rectangle;

        /* Should be set in AppendLine method */
        private string _name;

        public bool IsCommandReady
        {
            get
            {
                /* "add rectangle" is a one-line command so it is always ready */
                return true;
            }
        }

        public void AppendLine(string line)
        {
            // check if line matches the RecognizeRegex
            Match match = RecognizeRegex.Match(line);

            if (match.Groups.Count == 6)
            {
                _name = match.Groups[1].Value;

                _rectangle = new RectangleFigure(
                    new ScenePoint(double.Parse(match.Groups[2].Value), double.Parse(match.Groups[3].Value)),
                    new ScenePoint(double.Parse(match.Groups[4].Value), double.Parse(match.Groups[5].Value))
                );
            }
            else 
                throw new BadFormatException();
        }

        public ICommand GetCommand() => new AddFigureCommand(_name, _rectangle);
    }
}