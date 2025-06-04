using System;
using System.Collections.Generic;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Calculates the largest rectangle area in a histogram using a monotonic
    /// stack to track increasing bars. This achieves O(n) time by ensuring each
    /// bar is pushed and popped at most once.
    /// </summary>
    public static class LargestRectangleInHistogram
    {
        public static int LargestRectangleArea(int[] heights)
        {
            if (heights == null || heights.Length == 0) return 0;
            int maxArea = 0;
            var stack = new Stack<int>();
            int n = heights.Length;
            for (int i = 0; i <= n; i++)
            {
                int h = i == n ? 0 : heights[i];
                while (stack.Count > 0 && h < heights[stack.Peek()])
                {
                    int height = heights[stack.Pop()];
                    int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, height * width);
                }
                stack.Push(i);
            }
            return maxArea;
        }
    }
}
