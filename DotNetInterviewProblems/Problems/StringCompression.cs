namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Performs in-place run length encoding on the given character array and
    /// returns the new length. Utilizes two pointers for O(n) processing time
    /// and O(1) extra space.
    /// </summary>
    public static class StringCompression
    {
        public static int Compress(char[] chars)
        {
            if (chars.Length == 0) return 0;
            int write = 0;
            int read = 0;
            while (read < chars.Length)
            {
                char current = chars[read];
                int count = 0;
                while (read < chars.Length && chars[read] == current)
                {
                    read++;
                    count++;
                }
                chars[write++] = current;
                if (count > 1)
                {
                    foreach (char c in count.ToString())
                    {
                        chars[write++] = c;
                    }
                }
            }
            return write;
        }
    }
}
