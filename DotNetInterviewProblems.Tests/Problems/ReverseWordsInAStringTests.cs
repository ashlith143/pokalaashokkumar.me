using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class ReverseWordsInAStringTests
    {
        [Fact]
        public void ReverseWords_ReversesOrder()
        {
            string result = ReverseWordsInAString.ReverseWords("the sky is blue");
            Assert.Equal("blue is sky the", result);
        }
    }
}
