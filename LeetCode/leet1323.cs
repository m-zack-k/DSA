using System;

public class Solution1323
{
    public int Maximum69Number(int num)
    {
        string numStr = num.ToString();
        string ans = "";
        bool checked6 = false;
        foreach (char c in numStr)
        {
            if (checked6)
            {
                ans += c;
            }
            else
            {
                if (c == '6')
                {
                    ans += 9;
                    checked6 = true;
                }
                else
                {
                    ans += c;
                }
            }
        }


        return int.Parse(ans);
        
    }
}