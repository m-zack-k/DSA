using System;

public class Solution3280
{
    public string ConvertDateToBinary(string date)
    {
        string y = date.Substring(0, 4);
        int yInt = int.Parse(y);

        string m = date.Substring(5, 2);
        int mInt = int.Parse(m);

        string d = date.Substring(8, 2);
        int dInt = int.Parse(d);

        string year = Convert.ToString(yInt, 2);
        string month = Convert.ToString(mInt, 2);
        string day = Convert.ToString(dInt, 2);

        return year + "-" + month + "-" + day;



    }
}

// public class Solution {
//     public string ConvertDateToBinary(string date) {
//         string y = date.Substring(0, 4);
//         int yInt = int.Parse(y);
//         string m = date.Substring(5, 2);
//         int mInt = (m[0] == '0') ? int.Parse(m[1].ToString()) : int.Parse(m);
//         string d = date.Substring(8, 2);
//         int dInt = (d[0] == '0') ? int.Parse(d[1].ToString()) : int.Parse(d);
//         string year = "";
//         string month = "";
//         string day = "";
//         int power = 1 << 10;
//         if (yInt > 1 << 11)
//         {
//             year += 1;
//             yInt -= 1 << 11;
//         }
//         while (yInt >= 0)
//         {
//             int a = yInt / power;
//             year += a;
//             yInt -= (a == 1) ? power : 0;
//             power /= 2;
//         }
//         while (mInt > 0)
//         {
//             int b = mInt % 2;
//             month += b.ToString() + month;
//             mInt /= 2;
//         }
//         while (dInt > 0)
//         {
//             int c = dInt % 2;
//             day += c.ToString() + day;
//             dInt /= 2;
//         }
//         return year + '-' + month + '-' + day;
//     }
// }