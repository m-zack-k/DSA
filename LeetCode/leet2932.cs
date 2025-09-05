using System;

public class Solution2932 {
    public int MaximumStrongPairXor(int[] nums)
    {
        int max = int.MinValue;
        int n = nums.Length;
        for (int i = 0; i < n; ++i)
        {
            for (int j = i; j < n; ++j)
            {
                int a = nums[i];
                int b = nums[j];
                if (Math.Abs(a - b) <= Math.Min(a, b))
                {
                    int xor = a ^ b;
                    if (xor > max) max = xor;

                }
            }
        }
        return max;
    }
}