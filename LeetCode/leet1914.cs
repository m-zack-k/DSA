public class Solution
{
    public int[][] RotateGrid(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int layers = Math.Max(m, n) / 2 - Math.Abs(m - n) % 2;
        int temp;
        for (int i = 0; i < layers; ++i)
        {
            int prev = grid[i][1];
            for (int j = i; j < m - i; ++j)
            {
                temp = grid[j][i];
                grid[j][i] = prev;
                prev = temp;
            }
            for (int j = i + 1; j < n - i; ++j)
            {
                temp = grid[m - i][j];
                grid[m - i][j] = prev;
                prev = temp;
            }
            for (int j = m - 1 - i; j >= i; j--)
            {
                temp = grid[j][n - i];
                grid[j][n - i] = prev;
                prev = temp;
            }
            for (int j = m - 1 - i; j > i; j--)
            {
                temp = grid[i][j];
                grid[i][j] = prev;
                prev = temp;
            }
        }
        return grid;
    }
}