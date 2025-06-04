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

Console.WriteLine("Longest Substring Without Repeating Characters example:");
string str = "abcabcbb";
int len = LongestSubstringWithoutRepeatingCharacters.LengthOfLongestSubstring(str);
Console.WriteLine($"Length: {len}");

Console.WriteLine("Minimum Window Substring example:");
string s = "ADOBECODEBANC";
string tStr = "ABC";
string window = MinimumWindowSubstring.MinWindow(s, tStr);
Console.WriteLine($"Window: {window}");

Console.WriteLine("Trapping Rain Water example:");
int[] bars = {0,1,0,2,1,0,1,3,2,1,2,1};
int water = TrappingRainWater.Trap(bars);
Console.WriteLine($"Trapped water: {water}");

Console.WriteLine("Valid Anagram example:");
Console.WriteLine(ValidAnagram.IsAnagram("anagram", "nagaram"));

Console.WriteLine("Valid Palindrome example:");
Console.WriteLine(ValidPalindrome.IsPalindrome("A man, a plan, a canal: Panama"));

Console.WriteLine("Group Anagrams example:");
string[] words = {"eat", "tea", "tan", "ate", "nat", "bat"};
var grouped = GroupAnagrams.Group(words);
foreach (var group in grouped)
{
    Console.WriteLine(string.Join(",", group));
}

Console.WriteLine("Longest Palindromic Substring example:");
Console.WriteLine(LongestPalindromicSubstring.LongestPalindrome("babad"));

Console.WriteLine("String Compression example:");
char[] chars = {'a','a','b','b','c','c','c'};
int newLen = StringCompression.Compress(chars);
Console.WriteLine($"{newLen}: {new string(chars,0,newLen)}");

Console.WriteLine("Reverse Words in a String example:");
Console.WriteLine(ReverseWordsInAString.ReverseWords("the sky is blue"));

Console.WriteLine("strStr example:");
Console.WriteLine(StrStr.Find("hello", "ll"));

Console.WriteLine("Count and Say example:");
Console.WriteLine(CountAndSay.Generate(4));
