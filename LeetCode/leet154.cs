public class Solution
{
    public int FindMin(int[] nums)
    {
        return Dnc(0, nums.Length - 1, nums);
    }

    private int Dnc(int left, int right, int[] nums)
    {
        if (left == right)
            return nums[left];

        if (nums[left] < nums[right])
            return nums[left];

        int m = (left + right) >> 1;

        return Math.Min(
            Dnc(left, m, nums),
            Dnc(m + 1, right, nums)
        );
    }
}