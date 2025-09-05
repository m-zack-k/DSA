using System;


public class Solution3487 {

    static void Main()
    {
        int[] a = [1, 2, 3, 4, 5];
        Console.WriteLine(MaxSum(a));
    }
    static public int MaxSum(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums, (a, b) => b.CompareTo(a));
        int max = 0;
        HashSet<int> uniqueSet = new HashSet<int>();
        for (int i = 0; i < n; ++i)
        {
            int curr = nums[i];
            if (i == 0)
            {
                if (curr <= 0)
                {
                    return curr;
                }
                else
                {
                    max += curr;
                    uniqueSet.Add(curr);
                }
            }
            else
            {
                if (curr <= 0) return max;
                else
                {
                    if (!uniqueSet.Contains(curr))
                    {
                        max += curr;
                        uniqueSet.Add(curr);
                    }
                }
            }

        }
        return max;
    }
}