using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class ProductOfArrayExceptSelfTests
    {
        [Fact]
        public void Solve_ReturnsExpectedProductArray()
        {
            int[] nums = {1,2,3,4};
            int[] result = ProductOfArrayExceptSelf.Solve(nums);
            Assert.Equal(new[] {24,12,8,6}, result);
        }
    }
}
