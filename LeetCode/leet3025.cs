using System;

public class Solution3025 {
    public int NumberOfPairs(int[][] points)
    {
        int n = points.Length;
        Array.Sort(points, (a, b) =>
        {
            int c = a[0].CompareTo(b[0]);
            if (c == 0)
            {
                c = b[1].CompareTo(a[1]);
            }
            return c;
        });
        int ans = 0;

        for (int i = 0; i < n; ++i)
        {
            int leftUpperY = points[i][1];
            int maxY = int.MinValue;
            for (int j = i + 1; j < n; ++j)
            {
                int rightLowerY = points[j][1];
                if (leftUpperY >= rightLowerY & maxY < rightLowerY)
                {
                    maxY = rightLowerY;
                    ans++;
                }
            }
        }
        return ans;
    }
}