namespace Scene2d.Figures
{
    using System;
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
            double minX = _points.Min(p => p.X);
            double maxX = _points.Max(p => p.X);

            double minY = _points.Min(p => p.Y);
            double maxY = _points.Max(p => p.Y);

            SceneRectangle sceneRectangle = new SceneRectangle();

            sceneRectangle.Vertex1 = new ScenePoint(minX, maxY);
            sceneRectangle.Vertex2 = new ScenePoint(maxX, minY);

            return sceneRectangle;
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
            for (int i = 0; i < _points.Length; i++)
            {
                _points[i].X += vector.X;
                _points[i].Y += vector.Y;
            }
        }

        public void Reflect(ReflectOrientation orientation)
        {
            ScenePoint center = new ScenePoint();

            for (int i = 0; i < _points.Length; i++)
            {
                center.X += _points[i].X;
                center.Y += _points[i].Y;
            }

            center.X /= 4;
            center.Y /= 4;

            if (orientation == ReflectOrientation.Horizontal)
            {
                for (int i = 0; i < _points.Length; i++)
                {
                    _points[i].X = center.X * 2 - _points[i].X;
                }
            }
            else 
            {
                for (int i = 0; i < _points.Length; i++)
                {
                    _points[i].Y = center.Y * 2 - _points[i].Y;
                }
            }
        }

        public void Rotate(double angle)
        {
            ScenePoint center = new ScenePoint();

            for (int i = 0; i < _points.Length; i++)
            {
                center.X += _points[i].X;
                center.Y += _points[i].Y;
            }

            center.X /= 4;
            center.Y /= 4;

             double alpha = angle * (Math.PI / 180); 

            for (int i = 0; i < _points.Length; i++)
            {
                double x = _points[i].X;

                _points[i].X = (x - center.X) * Math.Cos(alpha) - (_points[i].Y - center.Y) * Math.Sin(alpha) + center.X;
                _points[i].Y = (x - center.X) * Math.Sin(alpha) + (_points[i].Y - center.Y) * Math.Cos(alpha) + center.Y;
            }
        }
    }
}