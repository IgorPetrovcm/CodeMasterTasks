namespace QuadraticEqRoot2
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    internal class Program
    {
        private static void Main()
        {
            const string outputPath = @"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\QuadraticEqRoot2\output.txt";

            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            var output = File.CreateText(outputPath);
            try 
            {
                var input = File.OpenText(@"C:\Users\Honor\Desktop\study C#\заметки\igor_petrov\Lab-3\QuadraticEqRoot2\input.txt");                
                string line;

                while ((line = input.ReadLine()) != null)
                {
                    string[] valuesInLine = line.Split(',');

                    List<double> roots = Solver.GetRootEquation(double.Parse(valuesInLine[0],CultureInfo.InvariantCulture), double.Parse(valuesInLine[1],CultureInfo.InvariantCulture), double.Parse(valuesInLine[2],CultureInfo.InvariantCulture));
                    roots = roots.OrderByDescending(x => x ).ToList(); 
                    string outputLine = string.Join(", ", roots);

                    output.WriteLine(outputLine);
                }
            }
            catch (Exception e) 
            {
                output.WriteLine($"error: {e}");
            }
            finally 
            {
                output.Dispose();
            }
        }
    }
}
