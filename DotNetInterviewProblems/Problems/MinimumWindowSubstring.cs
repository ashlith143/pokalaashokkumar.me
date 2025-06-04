using System;
using System.Collections.Generic;

namespace DotNetInterviewProblems.Problems
{
    public static class MinimumWindowSubstring
    {
        // Returns the minimum window in s which contains all characters of t
        public static string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || t.Length > s.Length)
                return string.Empty;

            var need = new Dictionary<char, int>();
            foreach (char c in t)
            {
                need[c] = need.ContainsKey(c) ? need[c] + 1 : 1;
            }

            int required = need.Count;
            int formed = 0;
            var windowCounts = new Dictionary<char, int>();

            int left = 0;
            int[] ans = { -1, 0, 0 }; // length, left, right

            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];
                windowCounts[c] = windowCounts.ContainsKey(c) ? windowCounts[c] + 1 : 1;

                if (need.ContainsKey(c) && windowCounts[c] == need[c])
                {
                    formed++;
                }

                while (left <= right && formed == required)
                {
                    if (ans[0] == -1 || right - left + 1 < ans[0])
                    {
                        ans[0] = right - left + 1;
                        ans[1] = left;
                        ans[2] = right;
                    }

                    char ch = s[left];
                    windowCounts[ch]--;
                    if (need.ContainsKey(ch) && windowCounts[ch] < need[ch])
                    {
                        formed--;
                    }
                    left++;
                }
            }

            return ans[0] == -1 ? string.Empty : s.Substring(ans[1], ans[0]);
        }
    }
}

