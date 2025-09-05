using System;

public class Solution498 {
    public int[] FindDiagonalOrder(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        int i = 0, j = 0;

        int[] ans = new int[m * n];
        int count = 0;
        bool upward = true;
        while (count < m * n)
        {
            if (upward)
            {
                while (i >= 0 && j < n)
                {
                    ans[count] = mat[i][j];
                    count++;
                    i--;
                    j++;
                }
                if (j == n)
                {
                    i += 2;
                    j--;
                }
                else
                {
                    i++;
                }
                upward = false;
            }
            else
            {
                while (j >= 0 && i < m)
                {
                    ans[count] = mat[i][j];
                    count++;
                    i++;
                    j--;
                }
                if (i == m)
                {
                    j += 2;
                    i--;
                }
                else
                {
                    j++;
                }
                upward = true;
            }

        }
        return ans; 

    }
}