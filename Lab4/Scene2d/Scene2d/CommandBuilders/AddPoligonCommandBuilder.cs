namespace Scene2d.CommandBuilders 
{

    using System.Text.RegularExpressions;
    using Scene2d.Commands;
    using Scene2d.Exceptions;
    using Scene2d.Figures;

    public class AddPoligonCommandBuilder : ICommandBuilder
    {
        private static readonly Regex RecognizeRegex = new Regex(@"");

        public bool IsCommandReady => throw new System.NotImplementedException();

        public void AppendLine(string line)
        {
            throw new System.NotImplementedException();
        }

        public ICommand GetCommand()
        {
            throw new System.NotImplementedException();
        }
    }
}