using System;

public class Solution
{
    // Memoization table: [idx, prev, prev2, isTight, isZero]
    // Stores tuples of (count, totalWaviness)
    private (int count, int wave)[,,,,] memo;
    private string limitStr;

    public int TotalWaviness(int num1, int num2)
    {
        return Calc(num2) - Calc(num1 - 1);
    }

    private int Calc(int num)
    {
        if (num <= 0) return 0;

        limitStr = num.ToString();
        int len = limitStr.Length;

        // 11 sizes for prev/prev2 cover digits 0-9, and index 10 represents the -1 state.
        memo = new (int, int)[len, 11, 11, 2, 2];

        // Initialize the memo table with -1 to indicate unvisited states
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                for (int k = 0; k < 11; k++)
                {
                    for (int l = 0; l < 2; l++)
                    {
                        for (int m = 0; m < 2; m++)
                        {
                            memo[i, j, k, l, m] = (-1, -1);
                        }
                    }
                }
            }
        }

        // Start DP from index 0, with no previous digits (-1), tightly bound, and currently leading zeros
        return Dp(0, -1, -1, true, true).wave;
    }

    private (int count, int wave) Dp(int idx, int prev, int prev2, bool isTight, bool isZero)
    {
        // Base case: If we've constructed a full number, it represents 1 valid combination and 0 remaining waviness
        if (idx == limitStr.Length) return (1, 0);

        // Map the -1 empty states to index 10 for array access
        int p = prev == -1 ? 10 : prev;
        int p2 = prev2 == -1 ? 10 : prev2;
        int t = isTight ? 1 : 0;
        int z = isZero ? 1 : 0;

        if (memo[idx, p, p2, t, z].count != -1)
        {
            return memo[idx, p, p2, t, z];
        }

        int limit = isTight ? (limitStr[idx] - '0') : 9;
        int totalCount = 0;
        int totalWave = 0;

        for (int d = 0; d <= limit; d++)
        {
            bool nextZero = isZero && (d == 0);
            bool nextTight = isTight && (d == limit);

            // If we are still placing leading zeros, we haven't officially started our number, so previous stays -1
            int nextPrev = nextZero ? -1 : d;
            int nextPrev2 = nextZero ? -1 : prev;

            var res = Dp(idx + 1, nextPrev, nextPrev2, nextTight, nextZero);

            int addWave = 0;
            // Check if the `prev` digit creates a peak or valley
            if (!nextZero && prev != -1 && prev2 != -1)
            {
                bool isPeak = prev2 < prev && prev > d;
                bool isValley = prev2 > prev && prev < d;

                if (isPeak || isValley)
                {
                    addWave = 1;
                }
            }

            totalCount += res.count;
            // The waviness from the suffix + the peak/valley we just found multiplied by the valid suffix variations
            totalWave += res.wave + (addWave * res.count);
        }

        return memo[idx, p, p2, t, z] = (totalCount, totalWave);
    }
}