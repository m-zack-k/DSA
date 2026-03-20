public class Solution
{
    public int[][] MinAbsDiff(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;

        // Initialize the result matrix
        int[][] ans = new int[m - k + 1][];

        for (int i = 0; i <= m - k; i++)
        {
            ans[i] = new int[n - k + 1];
            SortedDictionary<int, int> window = new SortedDictionary<int, int>();

            // 1. Build the initial k x k window for the current row
            for (int r = i; r < i + k; r++)
            {
                for (int c = 0; c < k; c++)
                {
                    int val = grid[r][c];
                    if (!window.ContainsKey(val))
                    {
                        window[val] = 0;
                    }
                    window[val]++;
                }
            }

            // Record the answer for the first column
            ans[i][0] = GetMinDifference(window);

            // 2. Slide the window horizontally
            for (int j = 1; j <= n - k; j++)
            {
                // Remove the left column that is sliding out of bounds
                for (int r = i; r < i + k; r++)
                {
                    int valToRemove = grid[r][j - 1];
                    window[valToRemove]--;
                    if (window[valToRemove] == 0)
                    {
                        window.Remove(valToRemove);
                    }
                }

                // Add the new right column sliding into bounds
                for (int r = i; r < i + k; r++)
                {
                    int valToAdd = grid[r][j + k - 1];
                    if (!window.ContainsKey(valToAdd))
                    {
                        window[valToAdd] = 0;
                    }
                    window[valToAdd]++;
                }

                // Record the answer for the current column
                ans[i][j] = GetMinDifference(window);
            }
        }

        return ans;
    }

    // Helper method to find the min absolute difference between distinct elements
    private int GetMinDifference(SortedDictionary<int, int> window)
    {
        // If all elements are the same, or k=1 (less than 2 distinct elements)
        if (window.Count < 2)
        {
            return 0;
        }

        int minDiff = int.MaxValue;
        int prevKey = -1;
        bool isFirst = true;

        // Keys are natively retrieved in ascending order
        foreach (int currentKey in window.Keys)
        {
            if (isFirst)
            {
                prevKey = currentKey;
                isFirst = false;
            }
            else
            {
                int diff = currentKey - prevKey;
                if (diff < minDiff)
                {
                    minDiff = diff;
                }
                prevKey = currentKey;
            }
        }

        return minDiff;
    }
}