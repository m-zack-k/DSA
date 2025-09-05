using System;

class Solution58
{
    public int LengthOfLastWord(string s)
    {
        string[] words = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        int len = words[^1].Length;
        return len;
    }

}