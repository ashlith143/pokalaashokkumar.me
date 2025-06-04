using System;
using System.Collections.Generic;

namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Groups words that are anagrams of each other. Sorts each word to create
    /// a canonical key and collects words with the same key using a
    /// dictionary. Complexity is O(n k log k) where k is the average word
    /// length.
    /// </summary>
    public static class GroupAnagrams
    {
        public static IList<IList<string>> Group(string[] strs)
        {
            var map = new Dictionary<string, List<string>>();
            foreach (var word in strs)
            {
                char[] chars = word.ToCharArray();
                Array.Sort(chars);
                string key = new string(chars);
                if (!map.ContainsKey(key))
                    map[key] = new List<string>();
                map[key].Add(word);
            }
            return new List<IList<string>>(map.Values);
        }
    }
}
