namespace Scene2d.CommandBuilders;

using System.Text.RegularExpressions;
using Scene2d.Commands;
using Scene2d.Exceptions;

public class RotateCommandBuilder : ICommandBuilder
{
    private static readonly Regex RecognizeRegex = new Regex(@"^rotate \s*?([a-zA-Z0-9\-_]+) (\d+)");

    private double _angle;

    private string _name;

    public bool IsCommandReady => true;

    public void AppendLine(string line)
    {
        Match match = RecognizeRegex.Match(line);

        if (match.Groups.Count != 3)
            throw new BadFormatException();

        _name = match.Groups[1].Value;

        _angle = double.Parse(match.Groups[2].Value);
    }

    public ICommand GetCommand() => new RotateFigureCommand(_name, _angle);
}