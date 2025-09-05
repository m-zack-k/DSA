using System;

public class Solution1277 {
    public int CountSquares(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int[,] dp = new int[m, n];
        for (int i = 0; i < n; ++i)
        {
            dp[0, i] += matrix[0][i];
        }
        for (int i = 1; i < m; ++i)
        {
            dp[i, 0] += matrix[i][0];
        }
        for (int i = 1; i < m; ++i)
        {
            for (int j = 1; j < n; ++j)
            {
                if (matrix[i][j] == 1)
                {
                    if (dp[i - 1, j - 1] > 0 && dp[i, j - 1] > 0 && dp[i - 1, j] > 0)
                    {
                        dp[i, j] += Math.Min(dp[i - 1, j - 1], Math.Min(dp[i, j - 1], dp[i - 1, j])) + 1;
                    }
                    else
                    {
                        dp[i, j] += 1;
                    }
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                ans += dp[i, j];
            }
        }
        return ans;
    }
}