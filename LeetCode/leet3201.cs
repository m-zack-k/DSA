using System;


public class Solution3201 {
    public int MaximumLength(int[] nums)
    {
        int lenEvenOdd = 0, lenOdd = 0, lenEven = 0;
        bool prevOdd;
        int n = nums.Length;
        if (nums[0] % 2 == 1)
        {
            lenOdd++;
            lenEvenOdd++;
            prevOdd = true;
        }
        else
        {
            lenEven++;
            lenEvenOdd++;
            prevOdd = false;
        }
        for (int i = 1; i < n; ++i)
        {
            if (nums[i] % 2 == 1)
            {
                lenOdd++;
                if (!prevOdd)
                {
                    lenEvenOdd++;
                    prevOdd = true;
                }
            }
            else
            {
                lenEven++;
                if (prevOdd)
                {
                    lenEvenOdd++;
                    prevOdd = false;
                }
            }
        }
        return Math.Max(lenOdd, Math.Max(lenEven, lenEvenOdd));
    }
}