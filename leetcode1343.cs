using System;

public class Solution1343 {
    public int NumOfSubarrays(int[] arr, int k, int threshold)
    {
        int sum = 0;
        int ans = 0;
        int n = arr.Length;
        for (int i = 0; i < k; ++i)
        {
            sum += arr[i];
        }
        if (sum >= threshold * k) ans++;

        for (int i = k; i < n; ++i)
        {
            sum += arr[i];
            sum -= arr[i - k];
            if (sum >= threshold * k) ans++;
        }
        return ans;
    }
}