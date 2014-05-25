
using System;
using System.Collections.Generic;

namespace Calculator
{
	public class Node
	{
		public enum NodeTypes { Operand = 10, Operator = 20 };
		
		public Node() {}
		
		public NodeTypes Type { get; set;}
		public double? Value { get; set; }
		
		public Func<double, double, double> Operation { get; set; }
		public string OperationSymbol { get; set; }
		
		public List<Node> Children { get; set; }
	}
}
