namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Searches for the first occurrence of <paramref name="needle"/> within
    /// <paramref name="haystack"/> using a simple substring comparison.
    /// This naive approach runs in O(n*m) time.
    /// </summary>
    public static class StrStr
    {
        public static int Find(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle)) return 0;
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                int j = 0;
                while (j < needle.Length && haystack[i + j] == needle[j])
                {
                    j++;
                }
                if (j == needle.Length) return i;
            }
            return -1;
        }
    }
}
