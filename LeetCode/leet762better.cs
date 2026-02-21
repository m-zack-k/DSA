using System.Numerics;

public class Solution
{
    public int CountPrimeSetBits(int left, int right)
    {
        //binary representataton where ith dgit is 1 if i is prime
        int magic = 665772;

        int ans = 0;
        for (int i = left; i <= right; ++i)
        {
            int count = BitOperations.PopCount((uint)i);
            ans += (magic >> count) & 1;
        }
        return ans;
    }
}