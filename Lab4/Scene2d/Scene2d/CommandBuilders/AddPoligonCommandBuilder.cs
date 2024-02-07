namespace Scene2d.CommandBuilders 
{

    using System.Text.RegularExpressions;
    using Scene2d.Commands;
    using Scene2d.Exceptions;
    using Scene2d.Figures;

    public class AddPoligonCommandBuilder : ICommandBuilder
    {
        private static readonly Regex RecognizeRegex = new Regex(@"^(add polygon) ([a-zA-Z0-9\-_]+)|
            (add point) \((-?\d+),\s?(-?\d+)\)|(end polygon)");

        private bool _isStarted = false; 

        public bool IsCommandReady 
        {
            get 
            {
                if (_isStarted)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void AppendLine(string line)
        {
            Match match = RecognizeRegex.Match(line);
        }

        public ICommand GetCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}