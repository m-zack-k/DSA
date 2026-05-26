public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        int[] upper = new int[26];
        int[] lower = new int[26];
        bool[] counted = new bool[26];
        int count = 0;
        int idx;
        foreach (char c in word)
        {
            if (Char.IsLower(c))
            {
                idx = c - 'a';
                lower[idx]++;
                if (!counted[idx] && upper[idx] >= 1)
                {
                    count++;
                    counted[idx] = true;
                }
            }
            else
            {
                idx = c - 'A';
                upper[idx]++;
                if (!counted[idx] && lower[idx] >= 1)
                {
                    count++;
                    counted[idx] = true;
                }

            }
        }
        return count;

    }
}