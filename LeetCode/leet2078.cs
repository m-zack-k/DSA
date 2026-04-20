public class Solution
{
    public int MaxDistance(int[] colors)
    {
        int n = colors.Length;
        int left = 0, right = 0;
        for (int i = 0; i < n; ++i)
        {
            if (colors[i] != colors[n - 1])
            {
                left = i;
                break;
            }
        }

        for (int j = n - 1; j >= 0; --j)
        {
            if (colors[j] != colors[0])
            {
                right = j;
                break;
            }
        }

        return Math.Max(n - 1 - left, right);
    }
}