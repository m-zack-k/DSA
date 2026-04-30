public class Solution
{
    public int MaxPathScore(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        int[,,] dp = new int[m, n, k + 1];
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                for (int l = 0; l <= k; ++l)
                {
                    dp[i, j, l] = -1;
                }
            }
        }
        int first = grid[0][0];
        int firstCost = (first == 0) ? 0 : 1;
        if (firstCost > k)
        {
            return -1;
        }
        dp[0, 0, firstCost] = first;

        for (int i = 1; i < m; ++i)
        {
            int curr = grid[i][0];
            int cost = (curr == 0) ? 0 : 1;
            for (int j = 0; j <= k - cost; ++j)
            {
                if (dp[i - 1, 0, j] != -1)
                {
                    dp[i, 0, j + cost] = curr + dp[i - 1, 0, j];
                }
            }
        }

        for (int i = 1; i < n; ++i)
        {
            int curr = grid[0][i];
            int cost = (curr == 0) ? 0 : 1;
            for (int j = 0; j <= k - cost; ++j)
            {
                if (dp[0, i - 1, j] != -1)
                {
                    dp[0, i, j + cost] = curr + dp[0, i - 1, j];
                }
            }
        }

        for (int i = 1; i < m; ++i)
        {
            for (int j = 1; j < n; ++j)
            {
                int curr = grid[i][j];
                int cost = (curr == 0) ? 0 : 1;
                for (int l = 0; l <= k - cost; ++l)
                {
                    int prev = Math.Max(dp[i - 1, j, l], dp[i, j - 1, l]);
                    if (prev != -1)
                    {
                        dp[i, j, l + cost] = curr + prev;
                    }
                }
            }
        }
        int max = -1;

        for (int i = 0; i <= k; ++i)
        {
            max = Math.Max(max, dp[m - 1, n - 1, i]);
        }
        return max;
    }
}