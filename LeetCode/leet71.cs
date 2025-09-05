using System;

public class Solution71 {
    public int NumJewelsInStones(string jewels, string stones) {
        char[] jewelsArr = jewels.ToCharArray();
        char[] stonesArr = stones.ToCharArray();
        // Array.Sort(jewelsArr);
        // Array.Sort(stonesArr);
        // int size = stonesArr.Length;
        // int i = 0;
        // int res = 0;
        // foreach (char jewel in jewelsArr)
        // {
        //     while (i < size && stonesArr[i] - 'a' <= jewel - 'a')
        //     {
        //         if (stonesArr[i] - 'a' <= jewel - 'a') res++;
        //         i++;
        //     }
        // }
        int[] ascii = new int[58];
        int res = 0;
        foreach (char jewel in jewelsArr)
        {
            ascii[jewel - 'A'] = 1;
        }
        foreach (char stone in stonesArr)
        {
            res += ascii[stone - 'A'];
        }

        return res;
    }
}