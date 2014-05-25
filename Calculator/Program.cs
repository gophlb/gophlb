using System;

namespace Calculator
{
	class Program
	{
		public static void Main(string[] args)
		{
			CalculateExpression("+ 1 - + 3 4 * 3 5", -7d);
			
			CalculateExpression("+ 1 2", 3d);
			
			CalculateExpression("/ 1 2", 0.5d);
			
			CalculateExpression("/ 1 + 1 1", 0.5d);
			
			CalculateExpression("^ / 1 + 1 1 3", 0.125d);
			
			CalculateExpression("+ 0,1 0,3", 0.4d);
			
			
			Console.ReadKey(true);
		}
		
		
		public static void CalculateExpression(string expressionString, double expectedResult)
		{
			TreeBuilder tb = new TreeBuilder();
			Node tree = tb.BuildFromExpression(expressionString);
			double result = Calculator.Calculate(tree);
			string treeDump = tb.Dump(tree, "    ");
			
			
			Console.WriteLine("  Expression = " + expressionString);
			Console.WriteLine("  Result   = {0}", result);
			Console.WriteLine("  Expected = {0}", expectedResult);
			Console.WriteLine("  Result == Expected ? {0}", (result == expectedResult));
			
			Console.WriteLine("\n");
			Console.WriteLine("  Tree dump:");
			Console.WriteLine(treeDump);
			Console.WriteLine("\n\n********************\n\n");
		}
	}
}
