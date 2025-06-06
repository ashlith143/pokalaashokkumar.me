# DotNetInterviewProblems

This console application contains solutions for various LeetCode problems, implemented in C# using .NET 8.

## Build and Run

```bash
cd DotNetInterviewProblems
# Restore dependencies and build
dotnet build

# Run the console app
dotnet run
```

### Running with Custom Data

Edit `Program.cs` to call any algorithm with your own input. For example:

```csharp
int[] prices = {7, 1, 5, 3, 6, 4};
int profit = BestTimeToBuyAndSellStock.MaxProfit(prices);
Console.WriteLine($"Profit: {profit}");

string s = "ADOBECODEBANC";
string t = "ABC";
string window = MinimumWindowSubstring.MinWindow(s, t);
Console.WriteLine($"Window: {window}");
```

Rebuild and run to see the result.

For a visual overview, see the [workflow diagram](docs/WORKFLOW.md).

## Problems Reference

Below is a list of classic LeetCode problems that this project aims to cover.
Each entry briefly describes the goal of the algorithm. Implementations may be
found under the `Problems/` folder.

### Arrays & Hashing

1. **Two Sum** – Find indices of two numbers that sum to a target.
2. **Best Time to Buy and Sell Stock** – Max profit with one buy and one sell.
3. **Product of Array Except Self** – Return an array where each element is the
   product of all other elements.

### Sliding Window & Two Pointers

4. **Longest Substring Without Repeating Characters** – Length of the longest
   substring with unique characters.
5. **Minimum Window Substring** – Smallest substring in `s` containing all of
   `t`.
6. **Trapping Rain Water** – Calculate trapped water between bars.

### Strings

7. **Valid Anagram** – Determine if one string is an anagram of another.
8. **Valid Palindrome** – Check if a string reads the same forward and backward.
9. **Group Anagrams** – Group words that are anagrams of each other.
10. **Longest Palindromic Substring** – Find the longest palindrome in a string.
11. **String Compression** – Compress consecutive duplicate characters in place.
12. **Reverse Words in a String** – Reverse the order of words separated by spaces.
13. **Implement strStr** – Return the index of the first occurrence of a substring.
14. **Count and Say Sequence** – Generate the n‑th term of the sequence.

### Greedy

15. **Merge Intervals** – Merge overlapping intervals.
16. **Activity Selection (Non-overlapping Intervals)** – Max number of
   non-overlapping intervals.

### Stack & Monotonic Stack

17. **Valid Parentheses** – Check if a parentheses string is valid.
18. **Largest Rectangle in Histogram** – Find the largest rectangle area in a
    histogram.

### Linked List

19. **Reverse Linked List** – Reverse a singly linked list.
20. **Cycle Detection (Linked List)** – Detect if a cycle exists in a linked
    list.

### Trees & Graphs

21. **Binary Tree Level Order Traversal** – Print a tree level by level.
22. **Lowest Common Ancestor of Binary Tree** – Find the lowest common ancestor
    of two nodes.
23. **Number of Islands** – Count the number of islands in a grid.
24. **Course Schedule (Topological Sort)** – Determine if all courses can be
    completed.

### Dynamic Programming

25. **Climbing Stairs** – Number of ways to reach the top of a staircase.
26. **Longest Increasing Subsequence** – Length of the longest increasing
    subsequence.
27. **Coin Change** – Minimum number of coins to make an amount.

### Backtracking

28. **Subsets** – Generate all subsets of an array.

## Running Tests

Unit tests are located in the `DotNetInterviewProblems.Tests` project. Run them with:

```bash
dotnet test DotNetInterviewProblems.Tests
```
