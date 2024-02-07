namespace Scene2d.CommandBuilders
{
    using System.Text.RegularExpressions;
    using Scene2d.Commands;
    using Scene2d.Exceptions;
    using Scene2d.Figures;

    public class AddCircleCommandBuilder : ICommandBuilder
    {
        private static readonly Regex RecognizeRegex = new Regex(@"add circle ([a-zA-Z0-9\-_]+) \((-?\d+),\s?(-?\d+)\) radius (-?\d+)");

        private IFigure _circle;

        private string _name;

        public bool IsCommandReady 
        {
            get { return true; }
        }

        public void AppendLine(string line)
        {
            Match match = RecognizeRegex.Match(line);

            if (match.Groups.Count == 5)
            {
                _name = match.Groups[1].Value;

                _circle = new CircleFigure(
                    new ScenePoint(double.Parse(match.Groups[2].Value), double.Parse(match.Groups[3].Value)),
                    double.Parse(match.Groups[4].Value)
                );
            }
            else 
            {
                throw new BadFormatException();
            }
        }

        public ICommand GetCommand()
        {
            return new AddFigureCommand(_name, _circle);
        }
    }
}