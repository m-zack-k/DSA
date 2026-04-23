public class Solution
{
    public long[] Distance(int[] nums)
    {
        int n = nums.Length;
        //num, [lastIndex, howManyTimes, Sum]
        var dict = new Dictionary<int, long[]>();
        long[] ans = new long[n];
        for (int i = 0; i < n; ++i)
        {
            int curr = nums[i];
            if (!dict.ContainsKey(curr))
            {
                dict[curr] = new long[3];
                dict[curr][0] = i;
                dict[curr][1] = 1;
                dict[curr][2] = 0;
                ans[i] = 0;
            }
            else
            {
                long sum = dict[curr][1] * (i - dict[curr][0]) + dict[curr][2];
                ans[i] = sum;
                dict[curr][0] = i;
                dict[curr][1]++;
                dict[curr][2] = sum;
            }
        }
        foreach (var kv in dict)
        {
            kv.Value[0] = -1;
            kv.Value[1] = 0;
            kv.Value[2] = 0;
        }

        for (int i = n - 1; i >= 0; --i)
        {
            int curr = nums[i];
            if (dict[curr][0] == -1)
            {
                dict[curr][0] = i;
                dict[curr][1] = 1;
                dict[curr][2] = 0;
            }
            else
            {
                long sum = dict[curr][1] * (dict[curr][0] - i) + dict[curr][2];
                ans[i] += sum;
                dict[curr][0] = i;
                dict[curr][1]++;
                dict[curr][2] = sum;
            }
        }
        return ans;
    }
}