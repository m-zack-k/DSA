public class Solution {
    public int MinimumDistance(string word) {
        int n = word.Length;
        int[,,] dp = new int[301, 26, 26];

        // Initialize dp with large values
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j < 26; j++) {
                for (int k = 0; k < 26; k++) {
                    dp[i, j, k] = 1000000;
                }
            }
        }

        // Base case: no cost before typing anything
        for (int j = 0; j < 26; j++) {
            for (int k = 0; k < 26; k++) {
                dp[0, j, k] = 0;
            }
        }

        for (int i = 0; i < n; i++) {
            int t = word[i] - 'A';

            for (int j = 0; j < 26; j++) {
                for (int k = 0; k < 26; k++) {
                    int current = dp[i, j, k];
                    if (current == 1000000) continue;

                    // Move second finger to t
                    dp[i + 1, j, t] = Math.Min(
                        dp[i + 1, j, t],
                        current + Cal(k, t)
                    );

                    // Move first finger to t
                    dp[i + 1, t, k] = Math.Min(
                        dp[i + 1, t, k],
                        current + Cal(j, t)
                    );
                }
            }
        }

        int ans = 1000000;
        for (int j = 0; j < 26; j++) {
            for (int k = 0; k < 26; k++) {
                ans = Math.Min(ans, dp[n, j, k]);
            }
        }

        return ans;
    }

    private int Cal(int a, int b) {
        return Math.Abs(a / 6 - b / 6) + Math.Abs(a % 6 - b % 6);
    }
}