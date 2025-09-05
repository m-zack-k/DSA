using System;

public class Solution3021
{
    public long FlowerGame(int n, int m)
    {
        long evenN = n / 2;
        long evenM = m / 2;
        long oddN = (n % 2 == 1) ? n / 2 + 1 : n / 2;
        long oddM = (m % 2 == 1) ? m / 2 + 1 : m / 2;
        return evenN * oddM + evenM * oddN;
    }
}
