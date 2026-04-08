public class Solution
{
    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        const int MOD = 1_000_000_007;
        int n = nums.Length;
        foreach (var q in queries)
        {
            int l = q[0], r = q[1], k = q[2], v = q[3];
            for (int i = l; i <= r; i += k)
            {
                nums[i] = (int)(((long)nums[i] * v) % MOD);
            }
        }
        int ans = nums[0];
        for (int i = 1; i < n; ++i)
        {
            ans ^= nums[i];
        }
        return ans;
    }
}