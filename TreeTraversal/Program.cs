using System;

namespace TreeTraversal
{
	class Program
	{
		public static void Main(string[] args)
		{
			ManageOperation("+ 1 - + 3 4 * 3 5", "-7");
			
			ManageOperation("+ 1 2", "3");
			
			ManageOperation("/ 1 2", "0.5");
			
			ManageOperation("/ 1 + 1 1", "0.5");
			
			ManageOperation("^ / 1 + 1 1 3", "0.125");
			
			ManageOperation("+ 0,1 0,3", "0.4");
			
			
			Console.ReadKey(true);
		}
		
		
		public static void ManageOperation(string operationString, string ExpectedResult)
		{
			TreeBuilder tb = new TreeBuilder();
			Node root = tb.GetTree(operationString);
			Console.WriteLine(operationString);
			Console.WriteLine("  Result   = " + tb.Evaluar(root));
			Console.WriteLine("  Expected = {0}", ExpectedResult);
			Console.WriteLine("\n");
			Console.WriteLine(tb.Dump(root, ""));
			Console.WriteLine("\n\n");
		}
	}
}
