using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class TrappingRainWaterTests
    {
        [Fact]
        public void Trap_ReturnsCorrectWaterAmount()
        {
            int[] height = {0,1,0,2,1,0,1,3,2,1,2,1};
            int water = TrappingRainWater.Trap(height);
            Assert.Equal(6, water);
        }
    }
}

