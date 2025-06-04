using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class StrStrTests
    {
        [Fact]
        public void Find_ReturnsIndex()
        {
            int idx = StrStr.Find("hello", "ll");
            Assert.Equal(2, idx);
        }

        [Fact]
        public void Find_NotFoundReturnsMinusOne()
        {
            int idx = StrStr.Find("aaaaa", "bba");
            Assert.Equal(-1, idx);
        }
    }
}
