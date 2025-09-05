using System;

public class Solution1512
{
    public int NumIdenticalPairs(int[] nums)
    {
        int n = nums.Length;
        if (n == 1) return 0;
        var dict = new Dictionary<int, int>();
        foreach (int num in nums)
        {
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict[num] = 1;
            }
        }
        int ans = 0;
        foreach (var item in dict)
        {
            if (item.Value > 1)
            {
                int a = item.Value;
                ans += a * (a- 1) / 2;
            }
        }
        return ans;
    }

    public int combs(int n, int k)
    {
        int ans = 1;
        for (int i = 1; i <= k; ++i)
        {
            ans *= n--;
            ans /= i;
        }
        return ans;
    }
}