using System;

public class Solution1248 {
    public int NumberOfSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        int oddCount = 0;
        int ans = 0;
        int left = 0, middle = 0;
        for (int right = 0; right < n; ++right)
        {
            oddCount += nums[right] % 2;
            while (oddCount > k)
            {
                oddCount -= nums[left] % 2;
                left++;
                middle = left;
            }
            if (oddCount == k)
            {
                while (nums[middle] % 2 == 0)
                {
                    middle++;
                }
                ans += middle - left + 1; 
            }
        }
        return ans;
    }
}