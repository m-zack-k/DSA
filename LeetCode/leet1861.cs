public class Solution
{
    public char[][] RotateTheBox(char[][] boxGrid)
    {
        int m = boxGrid.Length;
        int n = boxGrid[0].Length;

        for (int i = 0; i < m; ++i)
        {
            int pos = 0;
            for (int j = 0; j < n; ++j)
            {
                if (boxGrid[i][j] == '.')
                {
                    boxGrid[i][j] = boxGrid[i][pos];
                    boxGrid[i][pos] = '.';
                    pos++;
                }
                if (boxGrid[i][j] == '*')
                {
                    pos = j + 1;
                }
            }
        }
        char[][] ans = new char[n][];
        for (int i = 0; i < n; ++i)
        {
            ans[i] = new char[m];
        }
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                ans[j][m - 1 - i] = boxGrid[i][j];
            }
        }
        return ans;

    }
}