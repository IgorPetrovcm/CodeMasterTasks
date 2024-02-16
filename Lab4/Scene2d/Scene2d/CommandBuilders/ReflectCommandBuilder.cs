using System.Text.RegularExpressions;
using Scene2d.Commands;
using Scene2d.Exceptions;

namespace Scene2d.CommandBuilders;


public class ReflectCommandBuilder : ICommandBuilder
{
    private static readonly Regex RecognizeRegex = new Regex(@"reflect (vertically|horizontally) ([a-zA-Z0-9\-_]+|scene)");

    private ReflectOrientation _orientation;

    private string _name;

    public bool IsCommandReady => true;

    public void AppendLine(string line)
    {
        Match match = RecognizeRegex.Match(line);

        if (match.Groups.Count != 3)
            throw new BadFormatException();
        
        _name = match.Groups[2].Value;

        if (match.Groups[1].Value == "vertically")
            _orientation = ReflectOrientation.Vertical;

        else if (match.Groups[1].Value == "horizontally")
            _orientation = ReflectOrientation.Horizontal;

        else 
            throw new BadFormatException();
    }

    public ICommand GetCommand() => new ReflectFigureCommand(_name,_orientation);
}