using System;

public class Solution3136 {
    public bool IsValid(string word) {
        if (word.Length >= 3)
        {
            bool vowel = false;
            bool consonant = false;
            foreach (char c in word)
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (char.IsLetter(c))
                    {
                        char low = char.ToLower(c);
                        if (!vowel || !consonant)
                        {
                            if (low == 'a' || low == 'i' || low == 'u' || low == 'e' || low == 'o') vowel = true;
                            else consonant = true;
                        }
                    }
                }
                else return false;
            }
            return vowel && consonant;
        }
        else return false;
    }
}