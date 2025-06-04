using System;
using System.Collections.Generic;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Determines the length of the longest substring without repeating
    /// characters. Maintains a sliding window and dictionary of last seen
    /// indices for O(n) time complexity.
    /// </summary>
    public static class LongestSubstringWithoutRepeatingCharacters
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var map = new Dictionary<char, int>();
            int left = 0;
            int maxLen = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];
                if (map.TryGetValue(c, out int idx) && idx >= left)
                {
                    left = idx + 1;
                }

                map[c] = right;
                int len = right - left + 1;
                if (len > maxLen) maxLen = len;
            }

            return maxLen;
        }
    }
}

