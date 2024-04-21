namespace Scene2d.Figures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class RectangleFigure : IFigure
    {
        /* We store four rectangle points because after rotation edges could be not parallel to XY axes. */
        private ScenePoint _p1;
        private ScenePoint _p2;
        private ScenePoint _p3;
        private ScenePoint _p4;

        public RectangleFigure(ScenePoint p1, ScenePoint p2)
        {
            _p1 = p1; 
            _p2 = new ScenePoint { X = p2.X, Y = p1.Y };
            _p3 = p2; 
            _p4 = new ScenePoint { X = p1.X, Y = p2.Y };
        }

        public object Clone()
        {
            /* Should return new Rectangle with the same points as the current one. */

            throw new NotImplementedException();
        }

        public SceneRectangle CalculateCircumscribingRectangle()
        {
            /* Should calculate the rectangle that wraps current figure and has edges parallel to X and Y */

            List<double> xCollection = new List<double>();
            List<double> yCollection = new List<double>();

            foreach (ScenePoint point in GetPoints())
            {
                xCollection.Add(point.X);
                yCollection.Add(point.Y);
            }

            SceneRectangle sceneRectangle = new SceneRectangle();

            sceneRectangle.Vertex1 = new ScenePoint(xCollection.Min(), yCollection.Max());
            sceneRectangle.Vertex2 = new ScenePoint(xCollection.Max(), yCollection.Min());

            return sceneRectangle;
        }

        public void Move(ScenePoint vector)
        {
            _p1.X += vector.X;
            _p1.Y += vector.Y;

            _p2.X += vector.X;
            _p2.Y += vector.Y;

            _p3.X += vector.X;
            _p3.Y += vector.Y;

            _p4.X += vector.X;
            _p4.Y += vector.Y;
        }

        public void Rotate(double angle)
        {
            ScenePoint center = new ScenePoint();

            center.X = (_p1.X + _p2.X + _p3.X + _p4.X) / 4;

            center.Y = (_p1.Y + _p2.Y + _p3.Y + _p4.Y) / 4;

            double alpha = angle * (Math.PI / 180); 

            double x = _p1.X;

            _p1.X = (x - center.X) * Math.Cos(alpha) - (_p1.Y - center.Y) * Math.Sin(alpha) + center.X;
            _p1.Y = (x - center.X) * Math.Sin(alpha) + (_p1.Y - center.Y) * Math.Cos(alpha) + center.Y;

            x = _p2.X;

            _p2.X = (x - center.X) * Math.Cos(alpha) - (_p2.Y - center.Y) * Math.Sin(alpha) + center.X;
            _p2.Y = (x - center.X) * Math.Sin(alpha) + (_p2.Y - center.Y) * Math.Cos(alpha) + center.Y;

            x = _p3.X;

            _p3.X = (x - center.X) * Math.Cos(alpha) - (_p3.Y - center.Y) * Math.Sin(alpha) + center.X;
            _p3.Y = (x - center.X) * Math.Sin(alpha) + (_p3.Y - center.Y) * Math.Cos(alpha) + center.Y;

            x = _p4.X;

            _p4.X = (x - center.X) * Math.Cos(alpha) - (_p4.Y - center.Y) * Math.Sin(alpha) + center.X;
            _p4.Y = (x - center.X) * Math.Sin(alpha) + (_p4.Y - center.Y) * Math.Cos(alpha) + center.Y;

        }

        public void Reflect(ReflectOrientation orientation)
        {

        }

        public void Draw(ScenePoint origin, Graphics drawing)
        {
            /* Already implemented */

            using (var pen = new Pen(Color.Blue))
            {
                drawing.DrawLine(
                    pen,
                    (float)(_p1.X - origin.X),
                    (float)(_p1.Y - origin.Y),
                    (float)(_p2.X - origin.X),
                    (float)(_p2.Y - origin.Y));

                drawing.DrawLine(
                    pen,
                    (float)(_p2.X - origin.X),
                    (float)(_p2.Y - origin.Y),
                    (float)(_p3.X - origin.X),
                    (float)(_p3.Y - origin.Y));

                drawing.DrawLine(
                    pen,
                    (float)(_p3.X - origin.X),
                    (float)(_p3.Y - origin.Y),
                    (float)(_p4.X - origin.X),
                    (float)(_p4.Y - origin.Y));

                drawing.DrawLine(
                    pen,
                    (float)(_p4.X - origin.X),
                    (float)(_p4.Y - origin.Y),
                    (float)(_p1.X - origin.X),
                    (float)(_p1.Y - origin.Y));
            }
        }

        private IEnumerable<ScenePoint> GetPoints()
        {
            yield return _p1;
            yield return _p2;
            yield return _p3;
            yield return _p4;
        }
    }
}
