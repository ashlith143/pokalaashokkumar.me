namespace DotNetInterviewProblems.Problems
{
    public static class StringCompression
    {
        // Compresses the array in place and returns the new length
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
