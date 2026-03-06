public class Solution
{
    public bool CheckOnesSegment(string s)
    {
        int n = s.Length;
        if (n == 1)
        {
            return true;
        }
        int cnt = 0;
        bool inside = true;
        for (int i = 1; i < n; ++i)
        {
            int curr = s[i] - '0';
            if (curr == 1)
            {
                inside = true;
            }
            else
            {
                if (inside)
                {
                    cnt++;
                    inside = false;
                }
            }

        }
        if (inside)
        {
            cnt++;
        }
        return cnt <= 1;
    }
}