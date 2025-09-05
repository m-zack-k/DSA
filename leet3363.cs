using System;

public class Solution3363
{
    public int MaxCollectedFruits(int[][] fruits)
    {
        int n = fruits.Length;
        int maxFruits = fruits[0][0] + fruits[0][n - 1] + fruits[n - 1][0] + fruits[n - 1][n - 1];
        if (n == 2) return maxFruits;
        maxFruits += fruits[n - 2][n - 2] + fruits[n - 1][n - 2] + fruits[n - 2][n - 1];
        if (n == 3) return maxFruits;
        maxFruits += fruits[1][1];
        bool odd = n%2 == 1 ? true: false;
        int center = odd ? n/2 + 1 : n/2;
        for (int i = 2; i < n - 2; ++i)
        {
            maxFruits += fruits[i][i];
            if (i < center)
            {
                for (int j = n - 1; j > n - i - 2; --j) {
                    if (j == n - 1)
                    {
                        fruits[j][i] += Math.Max(fruits[j][i - 1], fruits[j - 1][i - 1]);
                        fruits[i][j] += Math.Max(fruits[i - 1][j], fruits[i - 1][j - 1]);
                    }
                    else if (j == n - i - 1)
                    {
                        fruits[j][i] += (odd&& i == n/2) ? Math.Max(fruits[j + 1][i - 1], fruits[j][i - 1]):fruits[j + 1][i - 1];
                        fruits[i][j] += (odd&& i == n/2) ? Math.Max(fruits[i - 1][j + 1], fruits[i - 1][j]):fruits[i - 1][j + 1];
                    }
                    else
                    {
                        fruits[j][i] += Math.Max(fruits[j + 1][i - 1], Math.Max(fruits[j][i - 1], fruits[j - 1][i - 1]));
                        fruits[i][j] += Math.Max(fruits[i - 1][j + 1], Math.Max(fruits[i - 1][j], fruits[i - 1][j - 1]));
                    }
                }
            }
            else
            {
                for (int j = n - 1; j > i; --j) {
                    if (j == n - 1)
                    {
                        fruits[j][i] += Math.Max(fruits[j][i - 1], fruits[j - 1][i - 1]);
                        fruits[i][j] += Math.Max(fruits[i - 1][j], fruits[i - 1][j - 1]);
                    }
                    else
                    {
                        fruits[j][i] += Math.Max(fruits[j + 1][i - 1], Math.Max(fruits[j][i - 1], fruits[j - 1][i - 1]));
                        fruits[i][j] += Math.Max(fruits[i - 1][j + 1], Math.Max(fruits[i - 1][j], fruits[i - 1][j - 1]));
                    }
                }
            }
        }
        maxFruits += Math.Max(fruits[n - 1][n - 3], fruits[n - 2][n - 3]);
        maxFruits += Math.Max(fruits[n - 3][n - 1], fruits[n - 3][n - 2]);

        return maxFruits;
    }
}