using System;
using System.Collections.Generic;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Determines if a string containing parentheses is valid. Uses a stack to
    /// ensure every opening bracket has a corresponding closing bracket in the
    /// correct order.
    /// </summary>
    public static class ValidParentheses
    {
        public static bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            var stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c is '(' or '[' or '{')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    char open = stack.Pop();
                    if ((c == ')' && open != '(') ||
                        (c == ']' && open != '[') ||
                        (c == '}' && open != '{'))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
    }
}
