using System;


public class Solution1876 {
    public int CountGoodSubstrings(string s)
    {
        int n = s.Length;
        if (n < 3) return 0;
        int count = 0;
        for (int i = 0; i < n - 2; ++i)
        {
            if (s[i] != s[i + 1] && s[i + 1] != s[i + 2] && s[i] != s[i + 2])
            {
                count++;
            }
        }
        return count;
    }
}