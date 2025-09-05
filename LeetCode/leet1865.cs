using System;
using System.Diagnostics.Contracts;

public class FindSumPairs {
    private int[] nums1;
    private int[] nums2;
    Dictionary<int, int> freq = new Dictionary<int, int>();

    public FindSumPairs(int[] nums1, int[] nums2)
    {
        this.nums1 = nums1;
        this.nums2 = nums2;
        foreach (int num in nums2)
        {
            if (freq.ContainsKey(num)) freq[num]++;
            else freq[num] = 1;
        }
    }

    public void Add(int index, int val)
    {
        int prevVal = nums2[index];
        freq[prevVal]--;
        if (freq[prevVal] == 0)
        {
            freq.Remove(prevVal);
        }
        nums2[index] += val;
        if (freq.ContainsKey(nums2[index])) freq[nums2[index]]++;
        else freq[nums2[index]] = 1;
    }

    public int Count(int tot)
    {
        int res = 0;
        foreach (int num in nums1)
        {
            int diff = tot - num;
            if (freq.ContainsKey(diff)) res += freq[diff];
        }
        return res;
    }
}