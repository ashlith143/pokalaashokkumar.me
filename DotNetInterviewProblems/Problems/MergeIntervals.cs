using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Merges overlapping intervals by first sorting them by start time and
    /// then iteratively combining any that overlap. Runs in O(n log n) due to
    /// the initial sort.
    /// </summary>
    public static class MergeIntervals
    {
        public static int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return Array.Empty<int[]>();

            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            var merged = new List<int[]> { intervals[0] };

            foreach (var current in intervals.Skip(1))
            {
                var last = merged[^1];
                if (current[0] <= last[1])
                {
                    last[1] = Math.Max(last[1], current[1]);
                }
                else
                {
                    merged.Add(new[] { current[0], current[1] });
                }
            }
            return merged.ToArray();
        }
    }
}
