public class Solution
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        int n = A.Length;
        bool[] count = new bool[n + 1];
        int sum = 0;
        int[] ans = new int[n];
        for (int i = 0; i < n; ++i)
        {
            int a = A[i];
            if (count[a])
            {
                sum++;
            }
            count[a] = true;

            int b = B[i];
            if (count[b])
            {
                sum++;
            }
            count[b] = true;
            ans[i] = sum;
        }
        return ans;

    }
}