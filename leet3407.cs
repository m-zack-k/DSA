using System;

public class Solution {
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
    {
        int n = fruits.Length;
        bool[] visited = new bool[n];
        int unplaced = n;

        foreach (int fruit in fruits)
        {
            for (int i = 0; i < n; ++i)
            {
                if (!visited[i] && fruit <= baskets[i])
                {
                    visited[i] = true;
                    --unplaced;
                    break;
                }
            }
        }
        return unplaced;
    }
}