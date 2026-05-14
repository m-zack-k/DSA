public class Solution
{
    public bool IsGood(int[] nums)
    {
        int n = nums.Length;
        int[] count = new int[n];

        foreach (int num in nums)
        {
            if (num < 1 || num > n - 1)
            {
                return false;
            }
            if (num < n - 1 && count[num] >= 1)
            {
                return false;
            }
            if (num == n - 1 && count[num] >= 2)
            {
                return false;
            }
            count[num]++;
        }
        return true;
    }
}