using System;

namespace DotNetInterviewProblems.Problems
{
    public static class BestTimeToBuyAndSellStock
    {
        // Returns the maximum profit achievable with one transaction
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
