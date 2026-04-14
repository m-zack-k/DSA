using System;

public class Solution
{
    public long MinimumTotalDistance(IList<int> robot, int[][] factory)
    {
        List<int> robots = new List<int>(robot);
        robots.Sort();
        Array.Sort(factory, (a, b) => a[0].CompareTo(b[0]));
        int n = robots.Count;
        int m = factory.Length;

        long[,] dp = new long[n + 1, m + 1];

        long INF = (long)1e15;
        for (int i = 0; i <= n; ++i)
        {
            for (int j = 0; j <= m; ++j)
            {
                dp[i, j] = INF;
            }
        }
        for (int j = 0; j <= m; ++j)
        {
            dp[0, j] = 0;
        }

        for (int j = 1; j <= m; ++j)
        {
            int factoryPos = factory[j - 1][0];
            int factoryLimit = factory[j - 1][1];

            for (int i = 1; i <= n; ++i)
            {
                dp[i, j] = dp[i, j - 1];

                long currentCost = 0;

                for (int k = 1; k <= Math.Min(i, factoryLimit); k++)
                {
                    currentCost += Math.Abs((long)robots[i - k] - factoryPos);

                    dp[i, j] = Math.Min(dp[i, j], dp[i - k, j - 1] + currentCost);
                }
            }
        }

        return dp[n, m];
    }
}
