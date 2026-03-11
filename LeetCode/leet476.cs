public class Solution
{
    public int FindComplement(int num)
    {
        return num == 0 ? 1 : (1 << (BitOperations.Log2((uint)num) + 1)) - 1 - num;
    }
}