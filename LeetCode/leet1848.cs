public class Solution
{
    public int GetMinDistance(int[] nums, int target, int start)
    {
        int n = nums.Length;

        if (nums[start] == target)
        {
            return 0;
        }
        int left = start - 1;
        int right = start + 1;

        int leftRange = start;
        int rightRange = n - 1 - start;

        int d = 1;
        while (true){
            if (left >= 0 && nums[left] == target)
            {
                return start - left;
            }

            if (right < n && nums[right] == target)
            {
                return right - start;
            }

            left--;
            right++;
        }
    }
}