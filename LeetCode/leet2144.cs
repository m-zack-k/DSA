public class Solution
{
    public int MinimumCost(int[] cost)
    {
        int n = cost.Length;
        cost = cost.OrderByDescending(a => a).ToArray();
        int sum = 0;
        for (int i = 0; i < n; ++i)
        {
            if (i % 3 != 2)
            {
                sum += cost[i];
            }
        }
        return sum;
    }
}