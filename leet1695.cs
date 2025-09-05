using System;

public class Solution1695 {
    public int MaximumUniqueSubarray(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int left = 0, right = 0, maxSum = 0, currSum = 0;
        for (int i = 0; i < n; ++i)
        {
            int num = nums[i];
            if (dict.ContainsKey(num))
            {
                for (int j = left; j < dict[num]; ++j)
                {
                    currSum -= nums[j];
                }
                left = dict[num] + 1;
                dict.Remove(num);
            }
            else
            {
                right++;
                currSum += num;
                dict[num] = i;
            }
            maxSum = Math.Max(maxSum, currSum);
        }
        return maxSum;
    }
}