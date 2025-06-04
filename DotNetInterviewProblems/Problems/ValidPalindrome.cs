using System;

namespace DotNetInterviewProblems.Problems
{
    public static class ValidPalindrome
    {
        // Returns true if s is a palindrome ignoring non-alphanumeric characters
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
