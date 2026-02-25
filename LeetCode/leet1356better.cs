using System.Numerics;

public class Solution
{
    public int[] SortByBits(int[] arr)
    {
        Array.Sort(arr, (a, b) =>
        {
            int bitCntA = BitOperations.PopCount((uint)a);
            int bitCntB = BitOperations.PopCount((uint)b);

            if (bitCntA != bitCntB)
            {
                return bitCntA - bitCntB;
            }

            return a.CompareTo(b);
        });
        return arr;
    }
}