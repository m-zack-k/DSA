// public class Solution {
//     public int MaximumLength(int[] nums, int k)
//     {
//         int[] dp = new int[k];
//         int longest = 0;
//         for (int val = 0; val < k; ++val)
//         {
//             foreach (int x in nums)
//             {
//                 int m = x % k;
//                 int want = (val - m) % k;
//                 int best = dp[want];
//                 dp[m] = Math.Max(Math.Max(dp[m], dp[want] + 1), 1);
//                 longest = Math.Max(longest, dp[m]);
//             }
//         }
//         return longest; 
//     }
// }