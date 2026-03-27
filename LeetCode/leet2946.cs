public class Solution {
    public bool AreSimilar(int[][] mat, int k) {
        int m = mat.Length;
        int n = mat[0].Length;
        k %= n;
        for (int i = 0; i < m; ++i){
            for (int j = 0; j < n; ++j){
                if (i % 2 == 0){
                    if (mat[i][j] != mat[i][(j + k) % n]){
                        return false;
                    }
                } else{
                    if (mat[i][j] != mat[i][(j - k + n) % n]){
                        return false;
                    }
                }
            }
        }       
        return true;
    }
}