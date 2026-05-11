public class Solution
{
    public int[] SeparateDigits(int[] nums)
    {
        int n = nums.Length;
        var list = new List<int>();
        for (int i = n - 1; i >= 0; --i)
        {
            int curr = nums[i];
            while (curr > 0)
            {
                list.Add(curr % 10);
                curr /= 10;
            }
        }
        int m = list.Count;
        int[] ans = new int[m];
        for (int i = 0; i < m; ++i)
        {
            ans[i] = list[m - 1 - i];
        }
        return ans;
    }
}