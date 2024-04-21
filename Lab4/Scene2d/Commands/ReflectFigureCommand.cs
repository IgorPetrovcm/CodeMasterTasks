namespace Scene2d.Commands;


public class ReflectFigureCommand : ICommand
{
    private string _name;

    private ReflectOrientation _orientation;

    public ReflectFigureCommand(string name, ReflectOrientation orientation)
    {
        _name = name;
        _orientation = orientation;
    }

    public string FriendlyResultMessage => "Reflect figure " + _name;

    public void Apply(Scene scene)
    {
        scene.Reflect(_name, _orientation);
    }
}