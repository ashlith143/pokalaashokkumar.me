using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class LongestPalindromicSubstringTests
    {
        [Fact]
        public void LongestPalindrome_ReturnsExpectedSubstring()
        {
            string result = LongestPalindromicSubstring.LongestPalindrome("babad");
            Assert.True(result == "bab" || result == "aba");
        }
    }
}
