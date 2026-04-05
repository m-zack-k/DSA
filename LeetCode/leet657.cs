public class Solution
{
    public bool JudgeCircle(string moves)
    {
        int verticalSum = 0;
        int horizontalSum = 0;
        foreach (char move in moves)
        {
            switch (move)
            {
                case 'U':
                    verticalSum++;
                    break;
                case 'D':
                    verticalSum--;
                    break;
                case 'R':
                    horizontalSum++;
                    break;
                case 'L':
                    horizontalSum--;
                    break;
                default:
                    break;
            }
        }
        return verticalSum == 0 && horizontalSum == 0;
    }
}