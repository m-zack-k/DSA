using System;

public class Solution898 {
    public int SubarrayBitwiseORs(int[] arr)
    {
        HashSet<int> ans = new HashSet<int>();
        HashSet<int> prev = new HashSet<int>();

        foreach (int num in arr)
        {
            HashSet<int> curr = new HashSet<int>();
            curr.Add(num);

            foreach (int a in prev)
            {
                curr.Add(a | num);
            }
            ans.UnionWith(curr);
            prev = curr;
        }
        return ans.Count();
    }
}