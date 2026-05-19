public class Solution
{
    public int GetCommon(int[] nums1, int[] nums2)
    {
        int m = nums1.Length;
        int n = nums2.Length;
        int p1 = 0;
        int p2 = 0;
        while (p1 < m && p2 < n)
        {
            if (nums1[p1] == nums2[p2])
            {
                return nums1[p1];
            }
            else if (nums1[p1] < nums2[p2])
            {
                p1++;
            }
            else
            {
                p2++;
            }
        }
        return -1;
    }
}