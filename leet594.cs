// public class Solution {
//     public int FindLHS(int[] nums)
//     {
//          Dictionary<int, int> freq = new Dictionary<int, int>();
//         foreach (int num in nums) {
//             if (freq.ContainsKey(num)) freq[num]++;
//             else freq[num] = 1;
//         }
//         int longest = 0;
//         foreach (int key in freq.Keys)
//         {
//             if (freq.ContainsKey(key + 1))
//             {
//                 int len = freq[key] + freq[key + 1];
//                 if (len > longest) longest = len;
//             }
//         }
//         return longest;
//     }
// }