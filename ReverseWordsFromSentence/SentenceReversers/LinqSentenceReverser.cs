using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseWordsFromSentence.SentenceReversers
{
	public class LinqSentenceReverser : ISentenceReverser
	{
		public LinqSentenceReverser() { }
		
		
		public string Reverse(string sentence)
		{
			IEnumerable<string> reversed = sentence.Split(' ').Reverse();
			return string.Join(" ", reversed);
		}
	}
}
