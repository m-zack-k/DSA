using System;

public class Solution
{
    public int[] MaxValue(int[] nums)
    {
        if (nums == null || nums.Length == 0) return new int[0];

        int n = nums.Length;
        int[] ans = new int[n];
        int[] preMax = new int[n];

        preMax[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            preMax[i] = Math.Max(preMax[i - 1], nums[i]);
        }

        int sufMin = int.MaxValue;

        for (int i = n - 1; i >= 0; i--)
        {

            if (preMax[i] > sufMin)
            {

                ans[i] = ans[i + 1];
            }
            else
            {
                ans[i] = preMax[i];
            }

            sufMin = Math.Min(sufMin, nums[i]);
        }

        return ans;
    }
}