public class Solution
{
    public int MinOperations(int[][] grid, int x)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[] freq = new int[10001];
        int min = int.MaxValue;
        int max = -1;
        int targetRemainder = grid[0][0] % x;

        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                int curr = grid[i][j];
                if (curr % x != targetRemainder)
                {
                    return -1;
                }
                freq[curr]++;
                min = Math.Min(curr, min);
                max = Math.Max(curr, max);
            }
        }
        int med = (m * n + 1) / 2;
        int acc = 0;
        int idx = 0;
        for (int i = min; i <= max; i += x)
        {
            acc += freq[i];
            if (acc >= med)
            {
                idx = i;
                break;
            }
        }
        int ans = 0;
        for (int i = min; i <= max; i += x)
        {
            ans += Math.Abs(i - idx) / x * freq[i];
        }
        return ans;


    }
}