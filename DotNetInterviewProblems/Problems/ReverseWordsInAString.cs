using System;
using System.Linq;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Reverses the order of words in the provided string. Splits on spaces,
    /// reverses the resulting array and joins it back together. Runs in O(n)
    /// time where n is the length of the string.
    /// </summary>
    public static class ReverseWordsInAString
    {
        public static string ReverseWords(string s)
        {
            var words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(' ', words);
        }
    }
}
