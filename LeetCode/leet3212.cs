public class Solution
{
    public int NumberOfSubmatrices(char[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int count = 0;


        int[] xSum = new int[n];
        int[] ySum = new int[n];
        for (int i = 0; i < m; ++i)
        {
            int xRow = 0, yRow = 0;
            for (int j = 0; j < n; ++j)
            {
                if (grid[i][j] == 'X')
                {
                    xRow++;
                }
                if (grid[i][j] == 'Y')
                {
                    yRow++;
                }

                xSum[j] += xRow;
                ySum[j] += yRow;

                if (xSum[j] > 0 && xSum[j] == ySum[j])
                {
                    count++;
                }
            }
        }
        return count;
    }
}