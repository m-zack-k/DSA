public class Solution
{
    public int ClosestTarget(string[] words, string target, int startIndex)
    {
        int n = words.Length;
        if (words[startIndex] == target)
        {
            return 0;
        }
        int range = n / 2;
        int left = (startIndex - 1 + n) % n;
        int right = (startIndex + 1) % n;
        int k = 1;
        while (k <= range)
        {
            if (words[left] == target || words[right] == target)
            {
                return k;
            }
            left = (left - 1 + n) % n;
            right = (right + 1) % n;
            k++;
        }
        return -1;
    }
}