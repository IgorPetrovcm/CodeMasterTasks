namespace Calculator
{
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
    using Calculator.Exceptions;

    public class Parser : IParser
    {
        private readonly static Regex RecognizeRegex = new Regex(@"^([a-zA-Z0-9\+\-\*\/]+)\s+?([1-9]+)(?:\s+?([1-9]+))?(?:\s+?([1-9]+))?");

        public Operation Parse(string inputString)
        {
            // todo: реализуйте метод Parse().
            // этод метод "парсит" строку inputString и возвращает объект Operation
            // Формат строки: {имя_операции} {параметр1} ... {параметрN}
            // Обратите внимание:
            // предварительно повторяющиеся пробелы и пробелы в начале и в конце нужно игнорировать
            //
            // Если что-то пойдет не так (например, из строки нельзя выделить
            // знак операции и как минимум один параметр), не забудьте сгенерировать
            // соответствующее исключение из папки Exceptions
            //
            // Обратите внимание на юнит-тесты для этого класса

            string? operationName;

            List<double> operationValues = new List<double>();

            inputString = inputString.Trim();

            Match match = RecognizeRegex.Match(inputString);

            operationName = match.Groups[1].Value;

            double currentValue;

			if (!double.TryParse(match.Groups[2].Value, out currentValue))
            {
                throw new IncorrectParametersException("");
            }

            operationValues.Add(currentValue);

            for (int i = 3; i < match.Groups.Count && match.Groups[i].Value != ""; i++)
            {
                if (!double.TryParse(match.Groups[i].Value, out currentValue))
                {
                    throw new IncorrectParametersException("");
                }

                operationValues.Add(currentValue);
            }

            Operation operation = new Operation(operationName, operationValues.ToArray());

            return operation;
        }
    }
}