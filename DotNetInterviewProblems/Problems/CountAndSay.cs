using System.Text;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Generates the n-th term of the "count and say" sequence. Each
    /// iteration compresses the previous term by counting consecutive digits.
    /// Complexity is proportional to the size of the generated strings.
    /// </summary>
    public static class CountAndSay
    {
        public static string Generate(int n)
        {
            if (n <= 0) return string.Empty;
            string result = "1";
            for (int i = 1; i < n; i++)
            {
                var sb = new StringBuilder();
                int index = 0;
                while (index < result.Length)
                {
                    char current = result[index];
                    int count = 0;
                    while (index < result.Length && result[index] == current)
                    {
                        count++;
                        index++;
                    }
                    sb.Append(count).Append(current);
                }
                result = sb.ToString();
            }
            return result;
        }
    }
}
