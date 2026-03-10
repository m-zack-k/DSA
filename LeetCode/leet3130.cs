public class Solution {
    private const long MOD = 1_000_000_007;

    public int NumberOfStableArrays(int zero, int one, int limit)
    {
        long[,,] dp = new long[zero + 1, one + 1, 2];

        // Base cases: sequences consisting of only zeros
        for (int z = 0; z <= Math.Min(zero, limit); z++)
            dp[z, 0, 0] = 1;

        // Base cases: sequences consisting of only ones
        for (int o = 0; o <= Math.Min(one, limit); o++)
            dp[0, o, 1] = 1;

        for (int z = 1; z <= zero; z++)
        {
            for (int o = 1; o <= one; o++)
            {
                // End with 0
                long waysEndWithZero = dp[z - 1, o, 0] + dp[z - 1, o, 1];

                if (z > limit)
                    waysEndWithZero -= dp[z - limit - 1, o, 1];

                dp[z, o, 0] = Normalize(waysEndWithZero);

                // End with 1
                long waysEndWithOne = dp[z, o - 1, 1] + dp[z, o - 1, 0];

                if (o > limit)
                    waysEndWithOne -= dp[z, o - limit - 1, 0];

                dp[z, o, 1] = Normalize(waysEndWithOne);
            }
        }

        return (int)((dp[zero, one, 0] + dp[zero, one, 1]) % MOD);
    }

    private long Normalize(long value)
    {
        value %= MOD;
        if (value < 0) value += MOD;
        return value;
    }
}