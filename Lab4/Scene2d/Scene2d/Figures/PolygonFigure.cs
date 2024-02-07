namespace Scene2d.Figures
{
    using System.Drawing;
    using System.Linq;

    public class PolygonFigure : IFigure
    {
        private ScenePoint[] _points;

        public PolygonFigure(ScenePoint[] points)
        {
            _points = points;
        }

        public SceneRectangle CalculateCircumscribingRectangle()
        {
            double minX = _points.Min(p => p.X)
            throw new System.NotImplementedException();
        }

        public object Clone()
        {
            throw new System.NotImplementedException();
        }

        public void Draw(ScenePoint origin, Graphics drawing)
        {
            /* Already implemented */

            using (var pen = new Pen(Color.DarkOrchid))
            {
                for (var i = 0; i < _points.Length; i++)
                {
                    ScenePoint firstPoint = _points[i];
                    ScenePoint secondPoint = i >= _points.Length - 1 ? _points.First() : _points[i + 1];

                    drawing.DrawLine(
                        pen,
                        (float)(firstPoint.X - origin.X),
                        (float)(firstPoint.Y - origin.Y),
                        (float)(secondPoint.X - origin.X),
                        (float)(secondPoint.Y - origin.Y));
                }
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