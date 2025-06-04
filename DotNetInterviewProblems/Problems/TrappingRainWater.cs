using System;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Calculates how much rain water can be trapped between elevation bars.
    /// Uses a two-pointer technique that tracks the maximum height from both
    /// ends. Runs in O(n) time with constant space.
    /// </summary>
    public static class TrappingRainWater
    {
        public static int Trap(int[] height)
        {
            if (height == null || height.Length == 0) return 0;

            int left = 0;
            int right = height.Length - 1;
            int leftMax = 0;
            int rightMax = 0;
            int water = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        water += leftMax - height[left];
                    }
                    left++;
                }
                else
                {
                    if (height[right] >= rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        water += rightMax - height[right];
                    }
                    right--;
                }
            }

            return water;
        }
    }
}

