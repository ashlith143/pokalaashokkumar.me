using System;
using System.Collections.Generic;

namespace DotNetInterviewProblems.Problems
{
    public static class GroupAnagrams
    {
        // Groups anagrams together
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
