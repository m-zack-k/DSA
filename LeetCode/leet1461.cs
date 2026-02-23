using System.Text;

public class Solution
{
    public bool HasAllCodes(string s, int k)
    {
        var set = new HashSet<string>();
        var sb = new StringBuilder();
        for (int i = 0; i < k; ++i)
        {
            sb.Append(s[i]);
        }
        set.Add(sb.ToString());

        for (int i = k; i < s.Length; ++i)
        {
            sb.Remove(0, 1);
            sb.Append(s[i]);
            set.Add(sb.ToString());
        }

        return set.Count == 1 << k;
    }
}