namespace Scene2d.CommandBuilders 
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Scene2d.Commands;
    using Scene2d.Exceptions;
    using Scene2d.Figures;

    public class AddPoligonCommandBuilder : ICommandBuilder
    {
        private static readonly Regex RecognizeRegex = new Regex(@"^(?:\s*?(add polygon) ([a-zA-Z0-9\-_]+)|\s*?(add point) \((-?\d+),\s?(-?\d+)\)|\s*?(end polygon))");

        private bool _isStarted = false; 

        private string _name;

        private IFigure _polygon;

        private List<ScenePoint> _points = new List<ScenePoint>();

        public bool IsCommandReady 
        {
            get 
            {
                return !_isStarted;
            }
        }

        public void AppendLine(string line)
        {
            Match match = RecognizeRegex.Match(line);

            if (match.Groups[1].Value == "add polygon")
            {
                _name = match.Groups[2].Value;

                _isStarted = true;
            }
            else if (match.Groups[3].Value == "add point")
            {
                _points.Add(new ScenePoint(
                                double.Parse(match.Groups[4].Value), double.Parse(match.Groups[5].Value)
                            )
                        );
            }
            else if (match.Groups[6].Value == "end polygon")
            {
                _isStarted = false;

                _polygon = new PolygonFigure(_points.ToArray());
            }
        }

        public ICommand GetCommand() => new AddFigureCommand(_name, _polygon);
    }
}