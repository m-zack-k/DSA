public class Solution
{
    public int Search(int[] nums, int target)
    {
        int n = nums.Length;

        int lo = 0;
        int hi = n - 1;

        while (lo < hi)
        {
            int mid = (lo + hi) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] > target)
            {
                if (nums[hi] < target)
                {

                }
            }
            else
            {

            }

        }

        return -1;
    }
}