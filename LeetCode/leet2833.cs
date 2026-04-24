public class Solution
{
    public int FurthestDistanceFromOrigin(string moves)
    {
        int n = moves.Length;
        int total = 0;
        int choices = 0;
        foreach (char c in moves)
        {
            if (c == 'L')
            {
                total--;
            }
            else if (c == 'R')
            {
                total++;
            }
            else
            {
                choices++;
            }
        }
        return Math.Abs(total) + choices;

    }
}