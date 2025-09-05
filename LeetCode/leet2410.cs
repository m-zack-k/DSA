using System;

public class Solution2410 {
    public int MatchPlayersAndTrainers(int[] players, int[] trainers)
    {
        Array.Sort(players);
        Array.Sort(trainers);
        int n = players.Length;
        int max = 0;
        int i = 0;
        foreach (int ability in trainers)
        {
            if (ability >= players[i])
            {
                max++;
                i++;
            }
            if (i >= n) break;
        }
        return max;
    }
}