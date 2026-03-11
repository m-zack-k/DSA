using System.Numerics;

public class Solution
{
    public int BitwiseComplement(int n)
    {
        return n == 0 ? 1 : (1 << (BitOperations.Log2((uint)n) + 1)) - 1 - n;
    }
}