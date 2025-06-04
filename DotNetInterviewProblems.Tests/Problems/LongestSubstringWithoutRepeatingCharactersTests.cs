using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class LongestSubstringWithoutRepeatingCharactersTests
    {
        [Fact]
        public void LengthOfLongestSubstring_ReturnsExpectedLength()
        {
            string s = "abcabcbb";
            int len = LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring(s);
            Assert.Equal(3, len); // "abc"
        }

        [Fact]
        public void LengthOfLongestSubstring_AllSameCharacters()
        {
            string s = "bbbbb";
            int len = LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring(s);
            Assert.Equal(1, len);
        }
    }
}

