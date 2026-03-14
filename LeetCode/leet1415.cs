using System.Text;

public class Solution
{
    public string GetHappyString(int n, int k)
    {
        int total = 3 * (1 << (n - 1));

        if (k > total)
        {
            return "";
        }

        --k;
        var sb = new StringBuilder();

        int size = 1 << (n - 1);
        int charIDX = k / size;
        char prevChar = (char)('a' + charIDX);
        sb.Append(prevChar);

        k %= size;

        for (int i = 1; i < n; ++i)
        {
            size = 1 << (n - 1 - i);
            charIDX = k / size;
            int choiceCount = 0;
            char nextChar = 'a';
            for (char c = 'a'; c <= 'c'; c++)
            {
                if (c != prevChar)
                {
                    if (choiceCount == charIDX)
                    {
                        nextChar = c;
                        break;
                    }
                    choiceCount++;
                }
            }

            sb.Append(nextChar);
            prevChar = nextChar;
            k %= size;
        }
        return sb.ToString();
    }
}