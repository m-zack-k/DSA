using System.Text;

public class Solution
{
    public bool RotateString(string s, string goal)
    {
        if (s.Length != goal.Length)
        {
            return false;
        }
        var sb = new StringBuilder(s);
        sb.Append(s);
        return sb.ToString().Contains(goal);
    }
}