using System.Numerics;

public class Solution
{
    public int BitwiseComplement(int n)
    {
        return n == 0 ? 1 : (1 << (BitOperations.Log2((uint)n) + 1)) - 1 - n;
    }
}


// Possible soltion 
/*
public class Solution 
{ 
    public int BitwiseComplement(int n) 
    { 
        int bits = 32 - BitOperations.LeadingZeroCount((uint)(n | 1));
        int mask = (1 << bits) - 1;
        return ~n & mask;
    }
}
*/