public class Solution
{
    public int MaximumJumps(int[] nums, int target)
    {
        int n = nums.Length;
        int[] dp = new int[n];
        for (int i = 1; i < n; ++i)
        {
            int prev = nums[i - 1];
            for (int j = i; j < n; ++j)
            {
                if (Math.Abs(nums[j] - prev) <= target && ((dp[i - 1] == 0 && i == 1) || (dp[i - 1] != 0 && i != 1)))
                {
                    dp[j] = Math.Max(dp[j], dp[i - 1] + 1);
                }
            }
        }
        return dp[n - 1] == 0 ? -1 : dp[n - 1];
    }
}