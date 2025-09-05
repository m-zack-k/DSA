using System;
using System.Net.NetworkInformation;

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dict = new Dictionary<string, List<string>>();
        foreach (string s in strs)
        {
            int[] count = new int[26];
            foreach (char c in s)
            {
                count[c - 'a']++;
            }

            string key = string.Join("#", count); 
            if (!dict.ContainsKey(key))
            {
                dict[key] = new List<string>();
            }
            dict[key].Add(s);
        }
        var ans = new List<IList<string>>();
        foreach (List<string> list in dict.Values)
        {
            ans.Add(list);
        }
        return ans;
    }
}