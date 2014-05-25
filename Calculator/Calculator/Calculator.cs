
using System;

namespace Calculator
{
	public static class Calculator
	{
		public static double Calculate(Node currentNode)
		{
			if (currentNode.Type == Node.NodeTypes.Operator)
			{
				double valor1 = Calculate(currentNode.Children[0]);
				double valor2 = Calculate(currentNode.Children[1]);
				
				return Operations.OperationsDictionary[currentNode.OperationSymbol](valor1, valor2);
			}
			else
			{
				return (double)currentNode.Value;
			}
		}
	}
}
