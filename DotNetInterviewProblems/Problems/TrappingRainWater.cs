using System;

namespace DotNetInterviewProblems.Problems
{
    public static class TrappingRainWater
    {
        // Returns amount of trapped rain water given bar heights
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

