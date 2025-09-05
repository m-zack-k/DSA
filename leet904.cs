using System;
using System.ComponentModel.DataAnnotations;

public class Solution904 {

    static void Main()
    {
        int[] fruits = [1, 2, 1];
        Console.WriteLine(fruits);
    }
    public int TotalFruit(int[] fruits)
    {
        int n = fruits.Length;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int start = 0;
        int max = 0;

        for (int end = 0; end < n; ++end)
        {
            int curr = fruits[end];
            if (!dict.ContainsKey(curr)) dict[curr] = 0;

            dict[curr]++;

            while (dict.Count > 2)
            {
                int startElement = fruits[start];
                dict[startElement]--;
                if (dict[startElement] == 0) dict.Remove(startElement);

                start++;
            }
            max = Math.Max(max, end - start + 1);
        }


        return max;
    }
}