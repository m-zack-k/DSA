using System;

public class Solution263
{
    public bool IsUgly(int n)
    {
        if (n == 1) return true;
        List<int> primes = SieveInRange();
    }
    
    private List<int> SieveInRange(int m, int n)
    {
        bool[] isPrime = new bool[n + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;

        for (int p = 2; p * p <= n; p++)
        {
            if (isPrime[p])
            {
                for (int i = p * p; i <= n; i += p)
                {
                    isPrime[i] = false;
                }
            }
        }

        List<int> primes = new List<int>();
        for (int i = m; i <= n; i++)
        {
            if (isPrime[i])
                primes.Add(i);
        }

        return primes;
    }
}