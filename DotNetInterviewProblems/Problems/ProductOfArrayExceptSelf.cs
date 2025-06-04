using System;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Returns a new array where each element is the product of all other
    /// elements in the input array. Utilizes prefix and suffix products for an
    /// O(n) solution without using division.
    /// </summary>
    public static class ProductOfArrayExceptSelf
    {
        public static int[] Solve(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            int[] left = new int[n];
            int[] right = new int[n];

            left[0] = 1;
            for (int i = 1; i < n; i++)
            {
                left[i] = left[i - 1] * nums[i - 1];
            }

            right[n - 1] = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                right[i] = right[i + 1] * nums[i + 1];
            }

            for (int i = 0; i < n; i++)
            {
                result[i] = left[i] * right[i];
            }

            return result;
        }
    }
}
