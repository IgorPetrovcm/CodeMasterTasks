namespace Scene2d.Commands
{
    public class MoveFigureCommand : ICommand
    {
        private string _name;

        private ScenePoint _vector;

        public MoveFigureCommand(string name, ScenePoint vector)
        {
            _name = name;
            _vector = vector;
        }

        public string FriendlyResultMessage => "Moved figure " + _name;

        public void Apply(Scene scene)
        {
            scene.Move(_name, _vector);
        }
    }
}