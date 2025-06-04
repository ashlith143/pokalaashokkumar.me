using System;
using DotNetInterviewProblems.Problems;

Console.WriteLine("TwoSum example:");
int[] nums = {2, 7, 11, 15};
int target = 9;
var result = TwoSum.Solve(nums, target);
Console.WriteLine($"Indices: {result[0]}, {result[1]}");

Console.WriteLine("Best Time to Buy and Sell Stock example:");
int[] prices = {7, 1, 5, 3, 6, 4};
int profit = BestTimeToBuyAndSellStock.MaxProfit(prices);
Console.WriteLine($"Profit: {profit}");

Console.WriteLine("Product of Array Except Self example:");
int[] arr = {1, 2, 3, 4};
int[] products = ProductOfArrayExceptSelf.Solve(arr);
Console.WriteLine($"[{string.Join(", ", products)}]");
