using System;

public class Solution1652 {
    public int[] Decrypt(int[] code, int k)
    {
        int n = code.Length;
        int[] ans = new int[n];
        int sum = 0;
        if (k > 0)
        {
            for (int i = 0; i < k; ++i)
            {
                sum += code[i];
            }
            int p = k - 1;
            ans[n - 1] = sum;
            for (int i = n - 2; i >= 0; --i)
            {
                sum += code[i + 1];
                sum -= code[p];
                ans[i] = sum;
                p--;
                if (p == -1) p = n - 1;
            }
            return ans;
        }
        else if (k < 0)
        {
            k = -k;
            for (int i = n - 1; i > n - k - 1; --i)
            {
                sum += code[i];
            }
            int p = n - k;
            ans[0] = sum;
            for (int i = 1; i < n; ++i)
            {
                sum += code[i - 1];
                sum -= code[p];
                ans[i] = sum;
                p++;
                if (p == n) p = 0;
            }
            return ans;
        }
        else
        {
            Array.Fill(ans, 0);
            return ans;
        }
        
    }
}