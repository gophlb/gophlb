using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
	public class TreeBuilder
	{
		public TreeBuilder() { }
		
		public Node BuildFromExpression(string s)
		{
			List<string> tokens = (s.Split(' ')).ToList<string>();			
			return BuildFromTokens(new Node(), tokens);
		}
		
		
		private Node BuildFromTokens(Node currentNode, List<string> tokens)
		{
			// Operation
			if (Operations.OperationsDictionary.ContainsKey(tokens[0]))
			{
				currentNode.Type = Node.NodeTypes.Operator;
				currentNode.Operation = Operations.OperationsDictionary[tokens[0]];
				currentNode.OperationSymbol = tokens[0];
				
				currentNode.Children = new List<Node>();
				tokens.RemoveAt(0);
				
				// Operand 1
				currentNode.Children.Add(BuildFromTokens(new Node(), tokens));
				// Operand 2
				currentNode.Children.Add(BuildFromTokens(new Node(), tokens));
			}
			// Operand
			else
			{
				currentNode.Type = Node.NodeTypes.Operand;
				currentNode.Value = double.Parse(tokens[0]);
				tokens.RemoveAt(0);
			}
			
			return currentNode;
		}


		public string Dump(Node currentNode, string tab)
		{
			if (currentNode.Type == Node.NodeTypes.Operator)
			{
				string value1 = Dump(currentNode.Children[0], tab + " ");
				string value2 = Dump(currentNode.Children[1], tab + " ");
				
				return tab + currentNode.OperationSymbol 
					+ "\n" + tab + value1 
					+ "\n" + tab + value2
				;
			}
			else
			{
				return tab + currentNode.Value.ToString();
			}
		}
	}
}