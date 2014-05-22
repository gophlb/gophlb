using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeTraversal
{
	public class TreeBuilder
	{
		public TreeBuilder() { }
		
		public Dictionary<string, Func<double, double, double>> operationsDictionary = new Dictionary<string, Func<double, double, double>>
		{
			{ "+", ((x,y) => (x + y)) },
			{ "-", ((x,y) => (x - y)) },
			{ "*", ((x,y) => (x * y)) },
			{ "/", ((x,y) => (x / y)) },
			{ "^", ((x,y) => (Math.Pow(x, y))) }
		};
		

		public Node GetTree(string s)
		{
			List<string> tokens = (s.Split(' ')).ToList<string>();			
			return GetTree(new Node(), tokens);
		}
		
		
		private Node GetTree(Node currentNode, List<string> tokens)
		{
			// Operation
			if (operationsDictionary.ContainsKey(tokens[0]))
			{
				currentNode.Tipo = "operation";
				currentNode.Operation = operationsDictionary[tokens[0]];
				currentNode.OperationSymbol = tokens[0];
				
				currentNode.Children = new List<Node>();
				tokens.RemoveAt(0);
				
				// Operand 1
				currentNode.Children.Add(GetTree(new Node(), tokens));
				// Operand 2
				currentNode.Children.Add(GetTree(new Node(), tokens));
			}
			// Operand
			else
			{
				currentNode.Tipo = "operand";
				currentNode.Valor = double.Parse(tokens[0]);
				Console.WriteLine("currentNode.Valor " + currentNode.Valor + " " + tokens[0]);
				tokens.RemoveAt(0);
			}
			
			return currentNode;
		}


		public double Evaluar(Node currentNode)
		{
			if (currentNode.Tipo == "operation")
			{
				double valor1 = Evaluar(currentNode.Children[0]);
				double valor2 = Evaluar(currentNode.Children[1]);
				
				return operationsDictionary[currentNode.OperationSymbol](valor1, valor2);
			}
			else
			{
				return (double)currentNode.Valor;
			}
		}
		
		
		public string Dump(Node currentNode, string tab)
		{
			if (currentNode.Tipo == "operation")
			{
				string valor1 = Dump(currentNode.Children[0], tab + " ");
				string valor2 = Dump(currentNode.Children[1], tab + " ");
				
				return tab + currentNode.OperationSymbol + "\n" + tab + valor1 + "\n" + tab + valor2;
			}
			else
			{
				return tab + currentNode.Valor.ToString();
			}
		}
	}
}