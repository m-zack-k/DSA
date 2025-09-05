using System;

public class Solution2220
{
    public int MinBitFlips(int start, int goal)
    {
        // string s = Convert.ToString(start, 2);
        // string g = Convert.ToString(goal, 2);
        // int m = s.Length;
        // int n = g.Length;
        // int ans = 0;
        // s = s.PadLeft(Math.Max(m, n), '0');
        // g = g.PadLeft(Math.Max(m, n), '0');
        // for (int i = 0; i < s.Length; ++i)
        // {
        //     if (s[i] != g[i]) ans++;
        // }
        // return ans;
        int xor = start ^ goal;
        

    }
}