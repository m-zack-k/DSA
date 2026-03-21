public class Solution
{
    public int[][] ReverseSubmatrix(int[][] grid, int x, int y, int k)
    {
        for (int i = y; i < y + k; ++i)
        {
            int topRow = x;
            int botRow = x + k - 1;
            while (topRow < botRow)
            {
                int temp = grid[topRow][i];
                grid[topRow][i] = grid[botRow][i];
                grid[botRow][i] = temp;
                topRow++;
                botRow--;
            }
        }
        return grid;
    }
}