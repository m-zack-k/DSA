public class Solution
{
    public int MaxRotateFunction(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
        {
            return 0;
        }
        int sum = 0;
        int f = 0;
        for (int i = 0; i < n; ++i)
        {
            sum += nums[i];
            f += i * nums[i];
        }
        int max = f;
        for (int i = 1; i < n; ++i)
        {
            f += sum - nums[n - i] * n;
            max = Math.Max(max, f);
        }
        return max;
    }
}