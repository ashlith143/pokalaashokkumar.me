namespace DotNetInterviewProblems.Problems
{
    public static class StrStr
    {
        // Returns index of first occurrence of needle in haystack or -1
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
