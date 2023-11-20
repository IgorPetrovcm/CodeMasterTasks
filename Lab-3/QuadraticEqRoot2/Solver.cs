namespace QuadraticEqRoot2
{
    using System.Collections.Generic;

    public static class Solver
    {
        static public List<double> GetRootEquation(double a, double b, double c)
        {
            List<double> roots = new List<double>();
            double d = (b*b) - (4 * a * c);
            if (Math.Round(d,8) > 0) 
            { 
                roots.Add((double)((-b + Math.Sqrt(d)) / (a * 2)));
                roots.Add((double)((-b - Math.Sqrt(d)) / (a * 2)));
            }
            else if (Math.Round(d,8) == 0)
            {
                roots.Add((double)((-b) / (2 * a)));
            }
            else
            {
                return roots;
            }
            return roots;
        }  

    }
}
