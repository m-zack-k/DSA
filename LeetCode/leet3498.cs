using System;

class Solution3498 {
    public int reverseDegree(String s)
    {
        int n = s.Length;
        int sum = 0;
        for (int i = 0; i < n; ++i)
        {
            sum += ('z' - s[i] + 1) * (i + 1);
        }
        return sum;
    }
}