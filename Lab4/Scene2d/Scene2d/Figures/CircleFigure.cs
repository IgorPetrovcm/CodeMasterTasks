namespace Scene2d.Figures
{
    using System.Drawing;

    public class CircleFigure : IFigure
    {
        private ScenePoint _center;
        private double _radius;

        public CircleFigure(ScenePoint center, double radius)
        {
            _center = center;
            _radius = radius;
        }

        public SceneRectangle CalculateCircumscribingRectangle()
        {
            SceneRectangle sceneRectangle = new SceneRectangle();

            sceneRectangle.Vertex1 = new ScenePoint(_center.X - _radius, _center.Y - _radius);
            sceneRectangle.Vertex2 = new ScenePoint(_center.X + _radius, _center.Y + _radius);

            return sceneRectangle;
        }

        public object Clone()
        {
            throw new System.NotImplementedException();
        }

        public void Draw(ScenePoint origin, Graphics drawing)
        {
            /* Already implemented */
            using (var pen = new Pen(Color.Green))
            {
                drawing.DrawEllipse(
                    pen,
                    (int)(_center.X - _radius - origin.X),
                    (int)(_center.Y - _radius - origin.Y),
                    (int)(_radius * 2),
                    (int)(_radius * 2));
            }
        }

        public void Move(ScenePoint vector)
        {
            throw new System.NotImplementedException();
        }

        public void Reflect(ReflectOrientation orientation)
        {
            throw new System.NotImplementedException();
        }

        public void Rotate(double angle)
        {
            throw new System.NotImplementedException();
        }
    }
}