public class Solution {
    public int[][] SortMatrix(int[][] grid)
    {
        int n = grid.Length;
        for (int k = 0; k < n - 1; ++k)
        {
            int length = n - k;
            int[] d = new int[length];
            for (int i = k, j = 0; j < length; ++i, ++j)
            {
                d[j] = grid[i][j];
            }
            Array.Sort(d, (a, b) => b.CompareTo(a));
            for (int i = k, j = 0; j < length; ++i, ++j)
            {
                grid[i][j] = d[j];
            }

        }
        for (int k = 1; k < n - 1; ++k)
        {
            int length = n - k;
            int[] d = new int[length];
            for (int i = 0, j = k; i < length; ++i, ++j)
            {
                d[j] = grid[i][j];
            }
            Array.Sort(d);
            for (int i = 0, j = k; i < length; ++i, ++j)
            {
                grid[i][j] = d[j];
            }
        }
        return grid;
    }
}