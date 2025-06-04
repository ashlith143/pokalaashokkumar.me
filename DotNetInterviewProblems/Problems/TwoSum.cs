using System;
using System.Collections.Generic;
namespace DotNetInterviewProblems.Problems
{
    public static class TwoSum
    {
        // Returns indices of the two numbers such that they add up to target
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
