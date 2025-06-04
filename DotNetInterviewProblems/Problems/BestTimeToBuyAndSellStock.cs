using System;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Calculates the maximum profit from a single buy/sell transaction given
    /// a list of stock prices. Iterates once while tracking the minimum price
    /// seen so far for an O(n) solution.
    /// </summary>
    public static class BestTimeToBuyAndSellStock
    {
        public static int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;
            int minPrice = prices[0];
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }
                else
                {
                    int profit = prices[i] - minPrice;
                    if (profit > maxProfit)
                    {
                        maxProfit = profit;
                    }
                }
            }
            return maxProfit;
        }
    }
}
