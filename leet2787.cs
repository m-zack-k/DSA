using System;

public class Solution
{
    private const int MOD = (int)1e9 + 7;

    public int NumberOfWays(int n, int x)
    {
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
            dp[i] = new int[n + 1];
        dp[0][0] = 1;

        for (int i = 1; i <= n; ++i)
        {
            long p = (long)Math.Pow(i, x);
            for (int j = 0; j <= n; ++j)
            {
                dp[i][j] = dp[i - 1][j];
                if (p <= j)
                {
                    dp[i][j] = (dp[i][j] + dp[i - 1][j - (int)p]) % MOD;

                }
            }
        }
        return dp[n][n];
    }
}