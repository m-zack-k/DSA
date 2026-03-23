public class Solution1594
{
    int MOD = 1_000_000_007;
    public int MaxProductPath(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        long[,,] dp = new long[m, n, 2];
        dp[0, 0, 0] = grid[0][0];
        dp[0, 0, 1] = grid[0][0];
        for (int i = 1; i < m; ++i)
        {
            long product = dp[i - 1, 0, 0] * grid[i][0];
            dp[i, 0, 0] = product;
            dp[i, 0, 1] = product;
        }
        for (int i = 1; i < n; ++i)
        {
            long product = dp[0, i - 1, 0] * grid[0][i];
            dp[0, i, 0] = product;
            dp[0, i, 1] = product;
        }
        for (int i = 1; i < m; ++i)
        {
            for (int j = 1; j < n; ++j)
            {
                long curr = grid[i][j];
                long min = 0, max = 0;
                if (curr > 0)
                {
                    min = curr * Math.Min(dp[i - 1, j, 0], dp[i, j - 1, 0]);
                    max = curr * Math.Max(dp[i - 1, j, 1], dp[i, j - 1, 1]);
                }
                if (curr < 0)
                {
                    min = Math.Min(curr * dp[i - 1, j, 1], curr * dp[i, j - 1, 1]);
                    max = Math.Max(curr * dp[i - 1, j, 0], curr * dp[i, j - 1, 0]);
                }
                dp[i, j, 0] = min;
                dp[i, j, 1] = max;
            }
        }
        return dp[m - 1, n - 1, 1] >= 0 ? (int)(dp[m - 1, n - 1, 1] % MOD) : -1;
    }
}