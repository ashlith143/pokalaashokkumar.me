using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class CountAndSayTests
    {
        [Fact]
        public void Generate_ReturnsCorrectTerm()
        {
            string result = CountAndSay.Generate(4);
            Assert.Equal("1211", result);
        }
    }
}
