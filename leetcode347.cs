using System;

public class Solution {
    public int[] TopKFrequent(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            if (!dict.ContainsKey(num))
            {
                dict[num] = 1;
            }
            else
            {
                dict[num]++;
            }
        }
        var sorted = dict.OrderByDescending(a => a.Value).Take(k);
        int[] ans = new int[k];
        int i = 0;
        foreach (var s in sorted)
        {
            ans[i++] = s.Key;
        }
        return ans;
    }
}