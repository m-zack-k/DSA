using System;
using System.Collections.Generic;

public class Solution
{
    private const int MOD = 1_000_000_007;

    // Helper: Fast Exponentiation to compute (baseVal^exp) % MOD
    private long ModPow(long baseVal, long exp)
    {
        long res = 1;
        baseVal %= MOD;
        while (exp > 0)
        {
            if ((exp & 1) == 1) res = (res * baseVal) % MOD;
            baseVal = (baseVal * baseVal) % MOD;
            exp >>= 1;
        }
        return res;
    }

    // Helper: Modular Inverse using Fermat's Little Theorem
    private long ModInverse(long n)
    {
        return ModPow(n, MOD - 2);
    }

    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int T = (int)Math.Sqrt(n);

        List<int[]>[] smallK = new List<int[]>[T];
        for (int i = 0; i < T; i++)
        {
            smallK[i] = new List<int[]>();
        }

        foreach (var q in queries)
        {
            int l = q[0], r = q[1], k = q[2], v = q[3];

            if (k >= T)
            {
                for (int i = l; i <= r; i += k)
                {
                    nums[i] = (int)(((long)nums[i] * v) % MOD);
                }
            }
            else
            {
                smallK[k].Add(q);
            }
        }

        long[] diff = new long[n];
        for (int k = 1; k < T; k++)
        {
            if (smallK[k].Count == 0) continue;

            Array.Fill(diff, 1L);

            foreach (var q in smallK[k])
            {
                int l = q[0], r = q[1], v = q[3];

                diff[l] = (diff[l] * v) % MOD;

                int jumps = (r - l) / k;
                int R = l + (jumps + 1) * k;

                if (R < n)
                {
                    long inv = ModInverse(v);
                    diff[R] = (diff[R] * inv) % MOD;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (i >= k)
                {
                    diff[i] = (diff[i] * diff[i - k]) % MOD;
                }

                if (diff[i] != 1L)
                {
                    nums[i] = (int)(((long)nums[i] * diff[i]) % MOD);
                }
            }
        }

        int ans = 0;
        foreach (int num in nums)
        {
            ans ^= num;
        }
        return ans;
    }
}