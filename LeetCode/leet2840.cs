public class Solution {
    public bool CheckStrings(string s1, string s2) {
        int n = s1.Length;
        int[] counter = new int[52];
        for (int i = 0; i < n; ++i){
            int plus = (i & 1) * 26;
            counter[s1[i] - 'a' + plus]++;
            counter[s2[i] - 'a' + plus]--;
        }
        for (int i = 0; i < 52; ++i){
            if (counter[i] != 0){
                return false;
            }
        }
        return true;
    }
}