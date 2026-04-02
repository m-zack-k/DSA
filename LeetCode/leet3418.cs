public class Solution {
    public int MaximumAmount(int[][] coins) {
        int m = coins.Length;
        int n = coins[0].Length;

        int[, , ] dp = new int[m,n,3];

        for (int i = 0; i < m; ++i){
            for (int j = 0; j < n; ++j){
                dp[i,j, 0] = int.MinValue /2;
                dp[i,j, 1] = int.MinValue/2;
                dp[i,j, 2] = int.MinValue/2;
            }
        }

        dp[0,0,0] = coins[0][0];

        for (int k = 1; k <= 2; ++k){
            dp[0,0,k] = Math.Max(coins[0][0], 0);

        }

        for (int j = 1; j < n; ++j){
            dp[0,j,0] = dp[0,j-1,0] + coins[0][j];
            for (int k = 1; k <= 2; ++k){
                dp[0,j,k] = Math.Max(
                    dp[0,j-1,k] + coins[0][j],
                    dp[0,j-1,k-1] + Math.Max(coins[0][j], 0)
                );
            }
        }

        for (int i = 1; i < m; ++i){
            dp[i,0,0] = dp[i-1,0,0] + coins[i][0];
            for (int k = 1; k <= 2; ++k){
                dp[i,0,k] = Math.Max(
                    dp[i-1,0,k] + coins[i][0],
                    dp[i-1,0,k-1] + Math.Max(coins[i][0], 0)
                );
            }
        }

        for (int i = 1; i < m; ++i){
            for (int j = 1; j < n; ++j){
                dp[i,j,0] = Math.Max(dp[i-1,j,0], dp[i,j-1,0])+ coins[i][j];

                for (int k = 1; k <= 2; ++k){
                    dp[i,j,k] = Math.Max(
                        Math.Max(dp[i-1, j, k], dp[i,j-1,k])+coins[i][j], Math.Max(dp[i-1,j,k-1],dp[i,j-1,k-1]));
                    
                }
            }
        }
        return dp[m-1,n-1,2];
    }
}