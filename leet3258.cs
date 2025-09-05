using System;

public class Solution3258 {
    public int CountKConstraintSubstrings(string s, int k)
    {
        int countZero = 0;
        int countOne = 0;
        int ans = 0;
        int n = s.Length;
        int start = 0;
        for (int i = 0; i < n; ++i)
        {
            if (s[i] == '0') countZero++;
            else countOne++;
            while (countOne > k && countZero > k)
            {
                if (s[start] == '0') countZero--;
                else countOne--;
                start++;
            }
            ans++;
        } 
        return ans;
        
    }
}