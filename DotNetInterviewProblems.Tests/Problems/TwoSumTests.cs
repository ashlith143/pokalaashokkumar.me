using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class TwoSumTests
    {
        [Fact]
        public void Solve_ReturnsCorrectIndices()
        {
            int[] nums = {2,7,11,15};
            int target = 9;
            var result = TwoSum.Solve(nums, target);
            Assert.Equal(new[] {0,1}, result);
        }
    }
}
