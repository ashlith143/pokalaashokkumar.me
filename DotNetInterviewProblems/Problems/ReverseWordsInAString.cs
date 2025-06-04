using System;
using System.Linq;

namespace DotNetInterviewProblems.Problems
{
    public static class ReverseWordsInAString
    {
        // Reverses the words in a string
        public static string ReverseWords(string s)
        {
            var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(' ', words);
        }
    }
}
