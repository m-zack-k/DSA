using System.Numerics;

public class Solution
{
    public int BinaryGap(int n)
    {
        n >>= BitOperations.TrailingZeroCount((uint)n);
        if (n == 1)
        {
            return 0;
        }

        int max = 0;
        int curr = 0;

        while (n > 0)
        {
            if ((n & 1) == 1)
            {
                max = Math.Max(curr, max);
                curr = 0;
            }
            else
            {
                curr++;
            }
            n >>= 1;
        }

        return max + 1;
    }
}