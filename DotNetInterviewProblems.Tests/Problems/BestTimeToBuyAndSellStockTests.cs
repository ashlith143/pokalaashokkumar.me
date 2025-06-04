using DotNetInterviewProblems.Problems;
using Xunit;

namespace DotNetInterviewProblems.Tests.Problems
{
    public class BestTimeToBuyAndSellStockTests
    {
        [Fact]
        public void MaxProfit_ReturnsExpectedProfit()
        {
            int[] prices = {7,1,5,3,6,4};
            int profit = BestTimeToBuyAndSellStock.MaxProfit(prices);
            Assert.Equal(5, profit); // Buy at 1, sell at 6
        }
    }
}
