public class Solution
{
    public int CountBinarySubstrings(string s)
    {
        int res = 0, prev = 0, streak = 1;

        for (int i = 1; i < s.Length; ++i)
        {
            if (s[i] == s[i - 1])
            {
                streak++;
            }
            else
            {
                prev = streak;
                streak = 1;
            }

            if (streak <= prev)
            {
                res++;
            }
        }
        return res;
    }
}