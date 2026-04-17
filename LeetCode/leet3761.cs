public class Solution
{
    public int MinMirrorPairDistance(int[] nums)
    {
        int n = nums.Length;
        int min = int.MaxValue;
        Dictionary<int, int> recentDict = new Dictionary<int, int>();

        for (int i = 0; i < n; ++i)
        {
            int curr = nums[i];
            if (recentDict.ContainsKey(curr))
            {
                int distance = Math.Abs(i - recentDict[curr]);
                min = Math.Min(min, distance);
            }
            recentDict[reverse(nums[i])] = i;
        }
        return min == int.MaxValue ? -1 : min;

    }

    private int reverse(int num)
    {
        int ans = 0;
        while (num > 0)
        {
            ans *= 10;
            ans += num % 10;
            num /= 10;
        }
        return ans;
    }
}