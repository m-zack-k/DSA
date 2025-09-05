using System;

public class Solution1863 {
    public int SubsetXORSum(int[] nums)
    {
        int sum = 0;
        int n = nums.Length;
        if (n == 0) return sum;
        if (n == 1) return nums[0];
        for (int mask = 0; mask < (1 << n); ++mask)
        {
            int xor = 0;

            for (int j = 0; j < n; ++j)
            {
                if ((mask & (1 << j)) !=0) xor ^= nums[j];
            }
            sum += xor;
        }
        return sum; 
    }
}