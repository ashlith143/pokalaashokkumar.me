using System.Collections.Generic;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Determines whether two strings are anagrams by counting character
    /// occurrences with a dictionary. Runs in O(n) time.
    /// </summary>
    public static class ValidAnagram
    {
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var counts = new Dictionary<char, int>();
            foreach (char c in s)
            {
                counts[c] = counts.ContainsKey(c) ? counts[c] + 1 : 1;
            }
            foreach (char c in t)
            {
                if (!counts.ContainsKey(c)) return false;
                counts[c]--;
                if (counts[c] == 0) counts.Remove(c);
            }
            return counts.Count == 0;
        }
    }
}
