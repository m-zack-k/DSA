using System;

public class Solution {
    public bool ReorderedPowerOf2(int n)
    {
        string target = SortNum(n);

        for (int i = 0; i < 31; ++i)
        {
            int power = 1 << i;
            if (SortNum(power) == target) return true;
        }
        return false;
    }

    public string SortNum(int n)
    {
        char[] chars = n.ToString().ToCharArray();
        Array.Sort(chars);
        return new string(chars);
    }
}