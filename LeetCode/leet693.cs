public class Solution
{
    public bool HasAlternatingBits(int n)
    {
        if (n < 2)
        {
            return true;
        }

        bool prevZero = n % 2 == 0;
        n /= 2;

        while (n > 0)
        {
            bool currZero = n % 2 == 0;
            if (prevZero == currZero)
            {
                return false;
            }
            prevZero = currZero;
        }
        return true;
    }
}