using System.Numerics;

public class Solution
{
    public int[] SortByBits(int[] arr)
    {
        Array.Sort(arr, (a, b) =>
        {
            int bitCntA = BitOperations.PopCount((uint)a);
            int bitCntB = BitOperations.PopCount((uint)b);
            int bitComparison = bitCntA.CompareTo(bitCntB);

            if (bitComparison != 0)
            {
                return bitComparison;
            }

            return a.CompareTo(b);
        });
        return arr;
    }
}