public class Solution
{
    public int MinFlips(string s)
    {
        int n = s.Length;
        int res = n;
        int[] op = { 0, 0 };

        for (int i = 0; i < n; i++)
        {
            op[(s[i] ^ i) & 1]++;
        }

        for (int i = 0; i < n; i++)
        {
            op[(s[i] ^ i) & 1]--;
            op[(s[i] ^ (n + i)) & 1]++;
            res = Math.Min(res, Math.Min(op[0], op[1]));
        }

        return res;
    }
}