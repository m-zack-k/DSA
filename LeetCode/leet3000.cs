using System;

public class Solution3000 {
    public int AreaOfMaxDiagonal(int[][] dimensions)
    {
        int n = dimensions.Length;
        int maxDiagonal = int.MinValue;
        int maxArea = int.MinValue;
        for (int i = 0; i < n; ++i)
        {
            int l = dimensions[i][0];
            int w = dimensions[i][1];
            int ds = l * l + w * w;
            if (ds > maxDiagonal)
            {
                maxDiagonal = ds;
                maxArea = l * w;
            }
            if (ds == maxDiagonal)
            {
                maxArea = (l * w > maxArea) ? l * w : maxArea;
            }
        }
        return maxArea;
    }
}