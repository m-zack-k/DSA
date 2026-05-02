public class Solution
{
    public int RotatedDigits(int n)
    {
        int count = 0;

        for (int i = 1; i <= n; i++)
        {
            string s = i.ToString();

            bool hasValidRotation = false; // any(c in '2569')
            bool hasInvalidDigit = false;  // any(c in '347')

            foreach (char c in s)
            {
                if (c == '2' || c == '5' || c == '6' || c == '9')
                {
                    hasValidRotation = true;
                }
                if (c == '3' || c == '4' || c == '7')
                {
                    hasInvalidDigit = true;
                    break; // no need to continue
                }
            }

            if (hasValidRotation && !hasInvalidDigit)
            {
                count++;
            }
        }

        return count;
    }
}