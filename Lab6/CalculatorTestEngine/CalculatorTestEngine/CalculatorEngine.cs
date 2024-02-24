namespace CalculatorTestEngine;


public class CalculatorEngine
{
    private Dictionary<string, CalculatorEngineEventArgs>? operations;


    public void PerformOperation(string sing, double[] values)
    {
        
    }

    public void SetNewOperation(string sign, Func<double, double> func)
    {
        CalculatorEngineEventArgs args = new CalculatorEngineEventArgs();

        args.SetFunc(func);

        operations.Add(sign, args);
    }
    public void SetNewOperation(string sign, Func<double,double,double> func)
    {
		CalculatorEngineEventArgs args = new CalculatorEngineEventArgs();

		args.SetFunc(func);

		operations.Add(sign, args);
	}

    public void SetNewOperation(string sign, Func<double, double, double, double> func)
    {
		CalculatorEngineEventArgs args = new CalculatorEngineEventArgs();

		args.SetFunc(func);

		operations.Add(sign, args);
	}
}

