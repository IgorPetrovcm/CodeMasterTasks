namespace Calculator
{
    using System;
    using System.Collections.Generic;
	using System.Linq;
	using Calculator.Exceptions;

    public class CalculatorEngine : ICalculatorEngine
    {
        private Dictionary<string, CalculatorEngineArgs>? operations;

        public double PerformOperation(Operation operation)
        {
			double answer = 0.0;

			try
			{
				answer = operations[operation.Sign]
							.Run(operation.Parameters);
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }

            return answer;
        }

        public void DefineOperation(string sign, Func<double, double, double, double> body)
        {
            if (operations.ContainsKey(sign))
            {
                if (operations[sign].GetTypesExistsFuncs()[2] == body.GetType()) { 
                    throw new AlreadyExistsOperationException("This operation already exists");
                }

                operations[sign].SetFunc(body);
            }
            else
            {
				CalculatorEngineArgs args = new CalculatorEngineArgs();

				args.SetFunc(body);

				operations.Add(sign, args);
			}
        }

        public void DefineOperation(string sign, Func<double, double, double> body)
        {
			if (operations.ContainsKey(sign))
			{
				if (operations[sign].GetTypesExistsFuncs()[1] == body.GetType())
				{
					throw new AlreadyExistsOperationException("This operation already exists");
				}

				operations[sign].SetFunc(body);
			}
			else
			{
				CalculatorEngineArgs args = new CalculatorEngineArgs();

				args.SetFunc(body);

				operations.Add(sign, args);
			}
		}

        public void DefineOperation(string sign, Func<double, double> body)
        {
			if (operations.ContainsKey(sign))
			{
				if (operations[sign].GetTypesExistsFuncs()[0] == body.GetType())
				{
					throw new AlreadyExistsOperationException("This operation already exists");
				}

				operations[sign].SetFunc(body);
			}
			else
			{
				CalculatorEngineArgs args = new CalculatorEngineArgs();

				args.SetFunc(body);

				operations.Add(sign, args);
			}
		}

    }
}
