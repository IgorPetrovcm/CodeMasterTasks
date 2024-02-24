using System;
using Calculator.Exceptions;

namespace Calculator
{
	public class CalculatorEngineArgs
	{
		public Func<double, double> oneValueEvent;
		
		public Func<double, double, double> twoValueEvent;
		
		public Func<double, double, double, double> threeValueEvent;
		
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
			if (values.Length == 1)
			{
				return oneValueEvent.Invoke(values[0]);
			}
			else if (values.Length == 3)
			{
				return threeValueEvent.Invoke(values[0], values[1], values[2]);
			}
			else if (values.Length == 2)
			{
				return twoValueEvent.Invoke(values[0], values[1]);
			}

			throw new ParametersCountMismatchException("Incorrect count of parameters");
		}

		public Type[] GetTypesExistsFuncs()
		{
			Type[] typeStrings = new Type[3]; 

			if (oneValueEvent != null)
			{
				typeStrings[0] = oneValueEvent.GetType();
			}
			if (twoValueEvent != null)
			{
				typeStrings[1] = twoValueEvent.GetType();
			}
			if (threeValueEvent != null)
			{
				typeStrings[2] = threeValueEvent.GetType();
			}

			return typeStrings;
		}
	}
}
