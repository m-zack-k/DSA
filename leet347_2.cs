using System;

public class Solution {
    public int[] TopKFrequent(int[] nums, int k)
    {
        int n = nums.Length;
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
        List<int>[] freq = new List<int>[n + 1];
        foreach (var item in dict)
        {
            if (freq[item.Value] == null)
            {
                freq[item.Value] = new List<int>();
            }
            freq[item.Value].Add(item.Key);
        }
        int[] ans = new int[k];
        int i = 0;
        for (int j = n; j > 0 && i < k; --j)
        {
            if (freq[j] != null)
            {
                foreach (int a in freq[j])
                {
                    ans[i++] = a;
                    if (i >= k) break;
                }
            }
        }
        return ans;
    }
}