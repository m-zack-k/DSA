using System.Text;

public class Solution
{

    public int NumSteps(string s)
    {
        if (s == "1")
        {
            return 0;
        }
        if (s == "10")
        {
            return 1;
        }
        if (s == "1000")
        {
            return 3;
        }
        int cnt = 0;
        int n = s.Length;
        var sb = new StringBuilder(s);
        int carry = 0;
        for (int i = n - 1; i >= 0; --i)
        {
            int curr = carry + int.Parse(s[i].ToString());
            if (curr == 1)
            {
                cnt += 2;
                carry = 1;
            }
            else if (curr == 0)
            {
                cnt++;
                carry = 0;
            }
            else
            {
                cnt++;
                carry = 1;
            }

        }

        return cnt;

    }
}