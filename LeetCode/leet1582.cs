public class Solution
{
    public int NumSpecial(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        int[] rows = new int[m];
        int[] cols = new int[n];
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                int curr = mat[i][j];
                if (curr == 1)
                {
                    rows[i]++;
                    cols[j]++;
                }
            }
        }

        int count = 0;

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (mat[i][j] == 1 && rows[i] == 1 && cols[j] == 1)
                {
                    count++;
                }
            }
        }
        return count;


    }
}