
using System;

namespace OperandOverride
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Point point1 = new Point { X = 1, Y = 2 };
			Point point2 = new Point { X = 4, Y = 2 };
			
			Point point3 = point1 + point2;
			Console.WriteLine("point3.X: {0}, point3.Y: {1}", point3.X, point3.Y);
			
			Point point4 = point1 - 5;
			Console.WriteLine("point4.X: {0}, point4.Y: {1}", point4.X, point4.Y);
						
			Point point5 = new Point { X = 1.2, Y = 2.4 };
			double multiplication = point5 * 5.0;
			Console.WriteLine("multiplication: {0}", multiplication);
			
			Console.ReadKey(true);
		}
	}
}