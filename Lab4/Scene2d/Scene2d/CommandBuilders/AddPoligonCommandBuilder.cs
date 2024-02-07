namespace Scene2d.CommandBuilders 
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Scene2d.Commands;
    using Scene2d.Exceptions;
    using Scene2d.Figures;

    public class AddPoligonCommandBuilder : ICommandBuilder
    {
        private static readonly Regex RecognizeRegex = new Regex(@"^(?:add polygon ([a-zA-Z0-9\-_]+)|add point \((-?\d+),\s?(-?\d+)\)|end polygon)");

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

            if (line.StartsWith("add polygon"))
            {
                _name = match.Groups[1].Value;

                _isStarted = true;
            }
            else if (line.StartsWith("add point"))
            {
                _points.Add(new ScenePoint(double.Parse(match.Groups[2].Value), double.Parse(match.Groups[3].Value)));
            }
            else if (line.StartsWith("end polygon"))
            {
                _isStarted = false;

                _polygon = new PolygonFigure(_points.ToArray());
            }
        }

        public ICommand GetCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}