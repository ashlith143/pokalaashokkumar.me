using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class StringCompressionTests
    {
        [Fact]
        public void Compress_ReturnsNewLength()
        {
            char[] chars = {'a','a','b','b','c','c','c'};
            int len = StringCompression.Compress(chars);
            Assert.Equal(6, len);
        }
    }
}
