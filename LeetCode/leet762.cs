using System.Numerics;

public class Solution
{
    public int CountPrimeSetBits(int left, int right)
    {
        var set = new HashSet<int>() { 2, 3, 5, 7, 11, 13, 17, 19 };
        int ans = 0;
        for (int i = left; i <= right; ++i)
        {
            int count = BitOperations.PopCount((uint)i);
            if (set.Contains(count))
            {
                ans++;
            }
        }
        return ans;
    }
}