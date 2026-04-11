public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        int n = nums.Length;
        if (n < 3)
        {
            return -1;
        }
        int[] last = new int[n + 1];
        int[] secondLast = new int[n + 1];
        Array.Fill(last, -1);
        Array.Fill(secondLast, -1);
        int min = int.MaxValue;

        for (int i = 0; i < n; ++i)
        {
            int curr = nums[i];
            if (secondLast[curr] != -1)
            {
                min = Math.Min(min, i - secondLast[curr]);
            }
            secondLast[curr] = last[curr];
            last[curr] = i;
        }
        return min == int.MaxValue ? -1 : 2 * min;
    }



}

/*public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        int n = nums.Length;
        if (n < 3)
        {
            return -1;
        }
        List<int>[] a = new List<int>[n + 1];
        for (int i = 1; i <= n; ++i)
        {
            a[i] = new List<int>();
        }
        int min = int.MaxValue;
        bool threeElementsExist = false;
        for (int i = 0; i < n; ++i)
        {
            int curr = nums[i];
            a[curr].Add(i);
        }
        for (int i = 1; i <= n; ++i)
        {
            int cnt = a[i].Count;
            if (cnt > 2)
            {
                threeElementsExist = true;
                for (int j = 0; j < cnt - 2; ++j)
                {
                    int curr = a[i][j + 2] - a[i][j];
                    min = Math.Min(min, curr);
                }
            }
        }

        return (!threeElementsExist) ? -1 : 2 * min;
    }

    private int distance(int i, int k)
    {
        return 2 * Math.Abs(k - i);
    }

}
*/