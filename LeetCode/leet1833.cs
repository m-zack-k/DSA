public class Solution
{
    public int MaxIceCream(int[] costs, int coins)
    {
        int[] nums = new int[100001];

        foreach (int cost in costs)
        {
            nums[cost]++;
        }
        int remaining = coins;
        int ans = 0;

        for (int i = 1; i <= 100001; ++i)
        {
            if (nums[i] == 0)
            {
                continue;
            }
            else
            {
                if (nums[i] * i <= remaining)
                {
                    remaining -= nums[i] * i;
                    ans += nums[i];
                }
                else
                {
                    while (i <= remaining && nums[i] > 0)
                    {
                        remaining -= i;
                        ans++;
                        nums[i]--;
                    }
                    return ans;
                }
            }
        }
        return ans;
    }
}