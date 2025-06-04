using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class ValidPalindromeTests
    {
        [Fact]
        public void IsPalindrome_IgnoresNonAlphanumeric()
        {
            Assert.True(ValidPalindrome.IsPalindrome("A man, a plan, a canal: Panama"));
        }

        [Fact]
        public void IsPalindrome_ReturnsFalseWhenNotPalindrome()
        {
            Assert.False(ValidPalindrome.IsPalindrome("hello"));
        }
    }
}
