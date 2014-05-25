
using System;
using System.Collections.Generic;

namespace Calculator
{
	public static class Calculator
	{
		public static Dictionary<string, Func<double, double, double>> OperationsDictionary = new Dictionary<string, Func<double, double, double>>
		{
			{ "+", ((x,y) => (x + y)) },
			{ "-", ((x,y) => (x - y)) },
			{ "*", ((x,y) => (x * y)) },
			{ "/", ((x,y) => (x / y)) },
			{ "^", ((x,y) => (Math.Pow(x, y))) }
		};
		
		
		
		public static double Calculate(string expression)
		{
			TreeBuilder tb = new TreeBuilder();
			Node tree = tb.BuildFromExpression(expression);
			return Calculator.Calculate(tree);
		}
		
		
		private static double Calculate(Node currentNode)
		{
			if (currentNode.Type == Node.NodeTypes.Operator)
			{
				double valor1 = Calculate(currentNode.Children[0]);
				double valor2 = Calculate(currentNode.Children[1]);
				
				return Calculator.OperationsDictionary[currentNode.OperationSymbol](valor1, valor2);
			}
			else
			{
				return (double)currentNode.Value;
			}
		}
	}
}
