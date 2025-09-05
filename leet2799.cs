using System;

public class Solution2799 {
    public int CountCompleteSubarrays(int[] nums)
    {
        var set = new HashSet<int>();
        int n = nums.Length;
        foreach (int num in nums)
        {
            set.Add(num);
        }
        int unique = set.Count;
        var dict = new Dictionary<int, int>();
        int ans = 0; 
        for (int left = 0, right = 0; right < n; ++right)
        {
            if (dict.ContainsKey(nums[right]))
            {
                dict[nums[right]]++;
            }
            else
            {
                dict[nums[right]] = 1;
            }
            while (dict.Count == unique)
            {
                ans += n - right;
                dict[nums[left]]--;
                if (dict[nums[left]] == 0)
                {
                    dict.Remove(nums[left]);
                }
                left++;
            }
        }
        return ans;
    }
}