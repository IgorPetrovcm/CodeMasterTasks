namespace CalculatorTestEngine;


public class CalculatorEngineEventArgs
{
	public event Func<double, double> oneValueEvent;

	public event Func<double, double, double> twoValueEvent;

	public event Func<double, double, double, double> threeValueEvent;

	public void SetFunc(Func<double, double> func)
	{
		oneValueEvent = func;
	}

	public void SetFunc(Func<double, double, double> func)
	{
		twoValueEvent = func;
	}

	public void SetFunc(Func<double, double, double, double> func)
	{
		threeValueEvent = func;
	}

	public double Run(double[] values)
	{
		if (oneValueEvent != null)
		{
			return oneValueEvent.Invoke(values[0]);
		}
		else if (twoValueEvent != null)
		{
			return twoValueEvent.Invoke(values[0], values[1]);
		}
		else if (threeValueEvent != null)
		{
			return threeValueEvent.Invoke(values[0], values[1], values[3]);
		}
		throw new Exception();
	}
}
