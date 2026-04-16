public class Solution
{
    public IList<int> SolveQueries(int[] nums, int[] queries)
    {
        int n = nums.Length;
        int m = queries.Length;
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; ++i)
        {
            int curr = nums[i];
            if (!dict.ContainsKey(curr))
            {
                dict[curr] = new List<int>();

            }
            dict[curr].Add(i);
        }
        int[] ans = new int[m];

        for (int i = 0; i < m; ++i)
        {
            int q = queries[i];
            int num = nums[q];
            int min = int.MaxValue;
            int count = dict[num].Count;
            if (count <= 1)
            {
                ans[i] = -1;
                continue;
            }
            int lo = 0;
            int hi = count - 1;
            int mid = 0;
            while (lo <= hi)
            {
                mid = (lo + hi) / 2;

                if (dict[num][mid] == q)
                {
                    break;
                }

                if (dict[num][mid] > q)
                {
                    hi = mid - 1;
                }
                else if (dict[num][mid] < q)
                {
                    lo = mid + 1;
                }
            }
            int leftVal = dict[num][(mid - 1 + count) % count];
            int rightVal = dict[num][(mid + 1) % count];

            int distLeft = Math.Min(Math.Abs(leftVal - q), n - Math.Abs(leftVal - q));
            int distRight = Math.Min(Math.Abs(rightVal - q), n - Math.Abs(rightVal - q));

            ans[i] = Math.Min(distLeft, distRight);
        }
        return ans;
    }
}

