public class Solution
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
                    for (int k = j + 1; k < cnt - 1; ++k)
                    {
                        for (int l = k + 1; l < cnt; ++l)
                        {
                            int b = distance(a[i][j], a[i][k], a[i][l]);
                            min = Math.Min(min, b);
                        }
                    }
                }
            }
        }

        return (!threeElementsExist) ? -1 : min;
    }

    private int distance(int i, int j, int k)
    {
        return Math.Abs(i - j) + Math.Abs(j - k) + Math.Abs(k - i);
    }

}