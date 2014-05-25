
using System;
using System.Collections.Generic;

namespace Calculator
{
	public static class Operations
	{
		public static Dictionary<string, Func<double, double, double>> OperationsDictionary = new Dictionary<string, Func<double, double, double>>
		{
			{ "+", ((x,y) => (x + y)) },
			{ "-", ((x,y) => (x - y)) },
			{ "*", ((x,y) => (x * y)) },
			{ "/", ((x,y) => (x / y)) },
			{ "^", ((x,y) => (Math.Pow(x, y))) }
		};
	}
}
