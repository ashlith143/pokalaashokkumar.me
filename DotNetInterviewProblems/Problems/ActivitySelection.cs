using System;
using System.Linq;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Selects the maximum number of non-overlapping intervals by sorting
    /// intervals by end time and greedily picking the earliest finishing one
    /// that does not conflict with previously selected activities. Runs in
    /// O(n log n) from the sort step.
    /// </summary>
    public static class ActivitySelection
    {
        public static int MaxNonOverlapping(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0) return 0;

            var sorted = intervals.OrderBy(i => i[1]).ToArray();
            int count = 0;
            int lastEnd = int.MinValue;
            foreach (var interval in sorted)
            {
                if (interval[0] >= lastEnd)
                {
                    count++;
                    lastEnd = interval[1];
                }
            }
            return count;
        }
    }
}
