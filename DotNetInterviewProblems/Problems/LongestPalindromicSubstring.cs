using System;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Returns the longest palindromic substring within <paramref name="s"/>.
    /// Uses an expand-around-center approach for each index, resulting in
    /// O(n^2) time and constant space complexity.
    /// </summary>
    public static class LongestPalindromicSubstring
    {
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end - start + 1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--; right++;
            }
            return right - left - 1;
        }
    }
}
