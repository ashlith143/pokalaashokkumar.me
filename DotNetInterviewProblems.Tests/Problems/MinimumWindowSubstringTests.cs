using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class MinimumWindowSubstringTests
    {
        [Fact]
        public void MinWindow_ReturnsSmallestWindow()
        {
            string s = "ADOBECODEBANC";
            string t = "ABC";
            string result = MinimumWindowSubstring.MinWindow(s, t);
            Assert.Equal("BANC", result);
        }

        [Fact]
        public void MinWindow_NoPossibleWindow_ReturnsEmpty()
        {
            string s = "a";
            string t = "aa";
            string result = MinimumWindowSubstring.MinWindow(s, t);
            Assert.Equal(string.Empty, result);
        }
    }
}

