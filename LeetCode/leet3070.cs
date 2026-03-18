/*
public class Solution
{
    public int CountSubmatrices(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int count = grid[0][0] <= k ? 1 : 0;
        for (int i = 1; i < m; ++i)
        {
            grid[i][0] += grid[i - 1][0];
            if (grid[i][0] <= k)
            {
                count++;
            }
        }
        for (int i = 1; i < n; ++i)
        {
            grid[0][i] += grid[0][i - 1];
            if (grid[0][i] <= k)
            {
                count++;
            }
        }
        for (int i = 1; i < m; ++i)
        {
            for (int j = 1; j < n; ++j)
            {
                grid[i][j] += grid[i - 1][j] + grid[i][j - 1] - grid[i - 1][j - 1];
                if (grid[i][j] <= k)
                {
                    count++;
                }
            }
        }
        return count;
    }
}
*/
// memory optimization
public class Solution
{
    public int CountSubmatrices(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int count = 0;
        int[] col = new int[n];
        for (int i = 0; i < m; ++i)
        {
            int rows = 0;
            for (int j = 0; j < n; ++j)
            {
                col[j] += grid[i][j];
                rows += col[j];
                if (rows <= k)
                {
                    count++;
                }
            }
        }
        return count;
    }
}