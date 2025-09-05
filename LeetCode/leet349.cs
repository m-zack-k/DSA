using System;
using System.Globalization;

public class Solution349
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        bool[] seen = new bool[1001];


        foreach (int num in nums1) seen[num] = true;

        List<int> intersected = new List<int>();

        foreach (int num in nums2)
        {
            if (seen[num])
            {
                intersected.Add(num);
                seen[num] = false;
            }
        }
        int n = intersected.Count;
        int[] ans = new int[n];
        for (int i = 0; i < n; ++i) ans[i] = intersected[i];

        return ans;
    }
    
}