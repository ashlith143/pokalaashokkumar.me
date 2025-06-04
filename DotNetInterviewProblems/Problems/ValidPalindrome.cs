using System;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Checks whether a string is a palindrome while ignoring any
    /// non-alphanumeric characters. Utilizes a two-pointer approach and runs
    /// in O(n) time.
    /// </summary>
    public static class ValidPalindrome
    {
        public static bool IsPalindrome(string s)
        {
            if (s == null) return false;
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left])) left++;
                while (left < right && !char.IsLetterOrDigit(s[right])) right--;
                if (char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right]))
                    return false;
                left++; right--;
            }
            return true;
        }
    }
}
