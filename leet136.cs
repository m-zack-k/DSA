using System;

public class Solution136 {
    public int SingleNumber(int[] nums)
    {
        int ans = 0;
        foreach (int num in nums) ans ^= num;

        return ans; 
    }
}