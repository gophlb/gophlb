using System;
using System.Linq;
using ReverseWordsFromSentence.SentenceReversers;
using ReverseWordsFromSentence.TextLineProcessors;

namespace ReverseWordsFromSentence
{
	class Program
	{
		public static void Main(string[] args)
		{
			TextLineProcessor tle = new TextLineProcessor();

			int[] numberOfLinesPerFile = { 20000, 40000, 60000, 80000, 100000, 200000 };
			
			foreach(int numberOfLines in numberOfLinesPerFile)
			{
				ProcessFile(@"c:\\test" + numberOfLines + ".txt" , tle, numberOfLines);
			}

			Console.ReadKey(true);
		}
		
		
		public static void ProcessFile(string filePath, TextLineProcessor tle, int numberOfLines)
		{
			Console.WriteLine("******** {0} lines:", numberOfLines);
			
			DateTime init = DateTime.Now;
			string linqReversed = tle.ReverseText(filePath, new LinqSentenceReverser());
			Console.WriteLine("Linq: {0} ms", DateTime.Now.Subtract(init).TotalMilliseconds);
			
			init = DateTime.Now;
			string classicReversed = tle.ReverseText(filePath, new ClassicSentenceReverser());
			Console.WriteLine("Classic: {0} ms", DateTime.Now.Subtract(init).TotalMilliseconds);
			
			Console.WriteLine("---------------------------------------------");
		}
	}
}