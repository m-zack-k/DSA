public class Solution {
    public int[][] ConstructProductMatrix(int[][] grid) {
    
        int MOD = 12345;
        int m = grid.Length;
        int n = grid[0].Length;

        int[][] p = new int[m][];
        for (int i = 0; i < m; ++i){
            p[i] = new int[n];
        }

        long suffix = 1;
        for (int i = m - 1; i >= 0; --i){
            for (int j = n - 1; j >= 0; --j){
                p[i][j] = (int)suffix;
                suffix = (suffix * grid[i][j]) % MOD;
            }
        }

        long prefix = 1;
        for (int i = 0; i < m; ++i){
            for (int j = 0; j < n; ++j){
                p[i][j] = (int)((p[i][j] * prefix) % MOD);
                prefix = (prefix * grid[i][j]) % MOD;
            }
        }

        return p;
    }
}