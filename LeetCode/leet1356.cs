using System.Numerics;

public class Solution
{
    public int[] SortByBits(int[] arr)
    {
        arr = arr.OrderBy(num => BitOperations.PopCount((uint)num)).ThenBy(num => num).ToArray();
        return arr;
    }
}