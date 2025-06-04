using System;
using System.Collections.Generic;
namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Given an array of integers and a target value, returns the indices of
    /// the two numbers that sum to the target. Uses a dictionary to store the
    /// complement of each element for an overall O(n) solution.
    /// </summary>
    public static class TwoSum
    {
        public static int[] Solve(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.TryGetValue(complement, out int index))
                {
                    return new[] { index, i };
                }
                map[nums[i]] = i;
            }
            return Array.Empty<int>();
        }
    }
}
