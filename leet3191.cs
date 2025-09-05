using System;

public class Solution3191
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        int count = 0;
        for (int i = 0; i < n; ++i)
        {
            if (nums[i] == 0)
            {
                if (i <= n - 3)
                {
                    nums[i] = 1;
                    nums[i + 1] = (nums[i + 1] == 0) ? 1 : 0;
                    nums[i + 2] = (nums[i + 2] == 0) ? 1 : 0;
                    count++;
                }
                else
                {
                    return -1;
                }
            }
        }
        return count; 
    }
}