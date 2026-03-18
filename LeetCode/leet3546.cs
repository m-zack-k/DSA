public class Solution
{
    public bool CanPartitionGrid(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        long total = 0;
        long[] rows = new long[m];
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                total += grid[i][j];
                rows[i] += grid[i][j];
            }
        }
        if (total % 2 == 1)
        {
            return false;
        }
        long half = total / 2;
        if (rows[0] == half)
        {
            return true;
        }
        else
        {
            for (int i = 1; i < m; ++i)
            {
                rows[i] += rows[i - 1];
                if (rows[i] == half)
                {
                    return true;
                }
                if (rows[i] > half)
                {
                    break;
                }
            }
        }
        long col = 0;
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < m; ++j)
            {
                col += grid[j][i];
            }
            if (col == half)
            {
                return true;
            }
            if (col > half)
            {
                break;
            }
        }
        return false;
    }
}