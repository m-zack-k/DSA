using System;

public class Solution1684 {
    public int CountConsistentStrings(string allowed, string[] words)
    {
        bool[] permitted = new bool[26];
        Array.Fill(permitted, false);
        int ans = 0;
        foreach (char c in allowed)
        {
            permitted[c - 'a'] = true;
        }
        foreach (string word in words)
        {
            bool valid = true;
            for (int i = 0; i < word.Length; ++i)
            {
                if (!permitted[word[i] - 'a'])
                {
                    valid = false;
                    break;
                }
            }
            if (!valid) continue;
            ans++;
        }
        return ans;
    }
}