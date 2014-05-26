using System;

namespace OperandOverride
{
	public class Point
	{
		public double X { get; set; }
		public double Y { get; set; }
		
		
		public static Point operator + (Point point1, Point point2)
		{
			return new Point { X = point1.X + point2.X, Y = point1.Y + point2.Y };
		}
		
		
		public static Point operator - (Point point1, double delta)
		{
			return new Point { X = point1.X - delta, Y = point1.Y - delta };
		}
		
		
		public static double operator * (Point point1, double delta)
		{
			return (point1.X * delta) + (point1.Y * delta);
		}		
		
		public static Point operator * (Point point1, Point point2)
		{
			return new Point { X = point1.X * point2.X, Y = point1.Y * point2.Y };
		}
		
		
		public Point() { }
	}
}
