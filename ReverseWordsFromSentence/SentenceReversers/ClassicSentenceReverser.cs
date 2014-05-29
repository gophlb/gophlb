using System;
using System.Text;

namespace ReverseWordsFromSentence.SentenceReversers
{
	public class ClassicSentenceReverser : ISentenceReverser
	{
		public ClassicSentenceReverser() { }

		public string Reverse(string sentence)
		{
			StringBuilder resultSb = new StringBuilder();
			
			string[] words = sentence.Split(' ');
			string separador = "";
			
			for(int i = words.Length - 1; i >= 0; i--)
			{
				resultSb.Append(separador).Append(words[i]);
				separador = " ";
			}
			
			return resultSb.ToString();
		}
	}
}
