public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        bool[] seen = new bool[26];
        bool[] counted = new bool[26];
        bool[] subtracted = new bool[26];
        int count = 0;
        int idx;
        foreach (char c in word)
        {
            if (Char.IsLower(c))
            {
                idx = c - 'a';
                if (counted[idx] && !subtracted[idx])
                {
                    count--;
                    subtracted[idx] = true;
                }
                seen[idx] = true;
            }
            else
            {
                idx = c - 'A';
                if (!seen[idx])
                {
                    counted[idx] = true;
                    subtracted[idx] = true;
                }
                if (seen[idx] && !counted[idx])
                {
                    count++;
                    counted[idx] = true;
                }
            }
        }
        return count;
    }
}