// Be aware of MOD because in other Solution we have MOD constant
public class Solution
{
    private const int MOD = 1_000_000_007;

    private bool isPowerOfTwo(int n)
    {
        return n != 0 && (n & n - 1) == 0;
    }
    public int ConcatenatedBinary(int n)
    {

        int ans = 0;
        int bitsShifted = 0;
        for (int i = 1; i <= n; ++i)
        {
            if (isPowerOfTwo(i))
            {
                bitsShifted++;
            }
            ans = ((ans << bitsShifted) % MOD + i) % MOD;

        }
        return ans;
    }
}