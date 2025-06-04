using System;
using DotNetInterviewProblems.Problems;

Console.WriteLine("TwoSum example:");
int[] nums = {2, 7, 11, 15};
int target = 9;
var result = TwoSum.Solve(nums, target);
Console.WriteLine($"Indices: {result[0]}, {result[1]}");
