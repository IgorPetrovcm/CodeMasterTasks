using System;
using Calculator.Exceptions;

namespace Calculator
{
	public class CalculatorEngineArgs
	{
		private Func<double, double>? _oneValueEvent;
		
		private Func<double, double, double>? _twoValueEvent;
		
		private Func<double, double, double, double>? _threeValueEvent;
		
		public void SetFunc(Func<double, double> func)
		{
			_oneValueEvent = func;
		}

		public void SetFunc(Func<double, double, double> func)
		{
			_twoValueEvent = func;
		}

		public void SetFunc(Func<double, double, double, double> func)
		{
			_threeValueEvent = func;
		}
		
		public double Run(double[] values)
		{
			if (values.Length == 1)
			{
				return _oneValueEvent.Invoke(values[0]);
			}
			else if (values.Length == 3)
			{
				return _threeValueEvent.Invoke(values[0], values[1], values[2]);
			}
			else if (values.Length == 2)
			{
				return _twoValueEvent.Invoke(values[0], values[1]);
			}
			
			throw new ParametersCountMismatchException("");
		}

		public bool[] GetExistsFuncs()
		{
			return new bool[]
			{
				_oneValueEvent != null,
				_twoValueEvent != null,
				_threeValueEvent != null
			};
		}
	}
}
