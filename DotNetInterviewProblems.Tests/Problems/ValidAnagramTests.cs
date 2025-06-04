using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class ValidAnagramTests
    {
        [Fact]
        public void IsAnagram_ReturnsTrueForValid()
        {
            Assert.True(ValidAnagram.IsAnagram("listen", "silent"));
        }

        [Fact]
        public void IsAnagram_ReturnsFalseForInvalid()
        {
            Assert.False(ValidAnagram.IsAnagram("rat", "car"));
        }
    }
}
