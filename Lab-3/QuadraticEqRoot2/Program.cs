namespace QuadraticEqRoot2
{
    using System.Collections.Generic;
    using System.IO;

    internal class Program
    {
        private static void Main()
        {
            const string outputPath = "output.txt";

            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            using (var input = File.OpenText("input.txt"))
            using (var output = File.CreateText(outputPath))
            {
                string line;

                while ((line = input.ReadLine()) != null)
                {
                    string[] valuesInLine = line.Split(',');

                    List<double> roots = Solver.GetRootEquation(double.Parse(valuesInLine[0]), double.Parse(valuesInLine[1]), double.Parse(valuesInLine[2]));

                    string outputLine = string.Join(", ", roots);

                    output.WriteLine(outputLine);
                }
            }
        }
    }
}

