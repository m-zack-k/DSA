public class Solution
{
    public int LongestCommonPrefix(int[] arr1, int[] arr2)
    {
        var set = new HashSet<int>();
        int longest = 0;

        foreach (int num in arr1)
        {
            int curr = num;
            while (!set.Contains(curr) && curr > 0)
            {
                set.Add(curr);
                curr /= 10;
            }
        }

        foreach (int num in arr2)
        {
            int curr = num;
            while (!set.Contains(curr) && curr > 0)
            {
                curr /= 10;
            }
            if (curr > 0)
            {
                longest = Math.Max(longest, (int)Math.Log10(curr) + 1);
            }
        }
        return longest;
    }
}