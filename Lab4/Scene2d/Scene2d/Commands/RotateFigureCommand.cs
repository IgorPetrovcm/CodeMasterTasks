namespace Scene2d.Commands;


public class RotateFigureCommand : ICommand
{
    private string _name;

    private double _angle;

    public RotateFigureCommand(string name, double angle)
    {
        _angle = angle;
        _name = name;
    }

    public string FriendlyResultMessage => "Rotate figure " + _name;

    public void Apply(Scene scene)
    {
        scene.Rotate(_name, _angle);
    }
}