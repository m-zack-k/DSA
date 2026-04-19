public class Solution
{
    public int MaxDistance(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;
        int i, j;

        for (i = 0, j = 0; i < m && j < n; ++j)
        {
            if (nums1[i] > nums2[j])
            {
                ++i;
            }
        }
        return Math.Max(0, j - i - 1);
    }
}