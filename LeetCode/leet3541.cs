using System;

public class Solution3541 {
    public int MaxFreqSum(string s)
    {
        int[] freq = new int[26];
        foreach (char c in s) freq[c - 'a']++;
        int maxV = 0;
        int maxC = 0;
        for (int i = 0; i < 26; ++i)
        {
            int curr = freq[i];
            if (i == 0 || i == 4 || i == 8 || i == 14 || i == 20)
            {
                if (curr > maxV) maxV = curr;
            }
            else
            {
                if (curr > maxC) maxC = curr;
            }
        }
        return maxC + maxV;
        
    }
}