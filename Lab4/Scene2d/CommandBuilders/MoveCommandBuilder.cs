using System.Text.RegularExpressions;

using Scene2d.Commands;
using Scene2d.Exceptions;

namespace Scene2d.CommandBuilders
{
    public class MoveCommandBuilder : ICommandBuilder
    {
        private static readonly Regex RecognizeRegex = new Regex(@"^move \s*?([a-zA-Z0-9\-_]+) \((-?\d+),\s*?(-?\d+)\)");
        private string _name;

        private ScenePoint _vector;

        public bool IsCommandReady => true;

        public void AppendLine(string line)
        {
            Match match = RecognizeRegex.Match(line);

            if (match.Groups.Count != 4)
                throw new BadFormatException();

            _name = match.Groups[1].Value;

            _vector.X = double.Parse(match.Groups[2].Value);
            _vector.Y = double.Parse(match.Groups[3].Value);
        }

        public ICommand GetCommand() => new MoveFigureCommand(_name, _vector);
    }
}