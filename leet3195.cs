using System.Globalization;

public class Solution3195 {
    public int MinimumArea(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int up = -1, down = -1, right = -1, left = -1;
        bool found = false;
        for (int i = 0; i < m && !false; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == 1)
                {
                    up = i;
                    found = true;
                    break;
                }
            }
        }
        found = false;
        for (int i = m - 1; i >= 0 && !false; --i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == 1)
                {
                    down = i;
                    found = true;
                    break;
                }
            }
        }
        found = false;
        for (int j = 0; j < n && !found; ++j)
        {
            for (int i = 0; i < m; ++i)
            {
                if (grid[i][j] == 1)
                {
                    left = j;
                    found = true;
                    break;
                }
            }
        }
        found = false;
        for (int j = n - 1; j >= 0 && !found; --j)
        {
            for (int i = 0; i < m; ++i)
            {
                if (grid[i][j] == 1)
                {
                    right = j;
                    found = true;
                    break;
                }
            }
        }
        return (up - down + 1) * (right - left + 1);



        
    }
}