public class Solution
{
    public int FindMin(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
        {
            return nums[0];
        }
        int getNext(int k)
        {
            return nums[(k + 1 + n) % n];
        }
        int getPrev(int k)
        {
            return nums[(k - 1 + n) % n];
        }


        int lo = 0;
        int hi = n - 1;
        while (lo <= hi)
        {
            int mid = (lo + hi) / 2;
            int curr = nums[mid];
            int next = getNext(mid);
            int prev = getPrev(mid);
            if (next < curr)
            {
                return next;
            }
            if (prev > curr)
            {
                return curr;
            }
            if (curr < nums[hi])
            {
                hi = mid - 1;
            }
            else
            {
                lo = mid + 1;
            }
        }

        lo = 0;
        hi = n - 1;

        while (lo <= hi)
        {
            int mid = (lo + hi) / 2;
            int curr = nums[mid];
            int next = getNext(mid);
            int prev = getPrev(mid);
            if (next < curr)
            {
                return next;
            }
            if (prev > curr)
            {
                return curr;
            }
            hi = mid - 1;
        }

        return int.MinValue;
    }
}