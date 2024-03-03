namespace Calculator
{
    using System;
    using System.Collections.Generic;
	using System.Linq;
	using System.Reflection.Metadata.Ecma335;
	using Calculator.Exceptions;

    public class CalculatorEngine : ICalculatorEngine
    {
        private Dictionary<string, CalculatorEngineArgs> operations = new Dictionary<string, CalculatorEngineArgs>();

        public double PerformOperation(Operation operation)
        {
			if (!operations.ContainsKey(operation.Sign))
			{
				throw new NotFoundOperationException("Not found an operation with this name");
			}

			double answer = 0.0;

			try
			{
				answer = operations[operation.Sign]
							.Run(operation.Parameters);
			}
			catch (Exception ex)
			{
				throw ex; 
            }

            return answer;
        }

        public void DefineOperation(string sign, Func<double, double, double, double> body)
        {
            if (operations.ContainsKey(sign))
            {
                if (operations[sign].GetExistsFuncs()[2]) { 
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
				if (operations[sign].GetExistsFuncs()[1])
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
				if (operations[sign].GetExistsFuncs()[0])
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
