
using System;
using System.Collections.Generic;

namespace TreeTraversal
{
	public class Node
	{
		public Node() {}
		
		public string Tipo { get; set;}
		public double? Valor { get; set; }
		
		public Func<double, double, double> Operation { get; set; }
		public string OperationSymbol { get; set; }
		
		public List<Node> Children { get; set; }
	}
}
