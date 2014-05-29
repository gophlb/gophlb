using System;
using System.IO;
using System.Text;

using ReverseWordsFromSentence.SentenceReversers;

namespace ReverseWordsFromSentence.TextLineProcessors
{
	public class TextLineProcessor
	{
		public TextLineProcessor() { }

		
		public string ReverseText(string filePath, ISentenceReverser SentenceReverser)
		{
			StringBuilder resultSb = new StringBuilder();

			string[] sentences = File.ReadAllLines(filePath);			
			
			foreach(string sentence in sentences)
			{
				resultSb.Append(SentenceReverser.Reverse(sentence));
			}
					
			return resultSb.ToString();
		}
	}
}