using System.Collections.Generic;

namespace DotNetInterviewProblems.Problems
{
    public static class ValidAnagram
    {
        // Returns true if t is an anagram of s
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
