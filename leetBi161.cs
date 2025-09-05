using System;
using System.Collections.Generic;

public class SolutionBi
{
    public long SplitArray(long[] nums)
    {
        long sum = 0;
        long n = nums.Length;
        if (n == 0) return 0;
        List<long> primes = SieveUpTo(n - 1);
        for (long i = 0; i < n; ++i)
        {
            long curr = nums[i];
            if (primes.Count > 0 && i == primes[0])
            {
                sum += curr;
                primes.RemoveAt(0);
            }
            else
            {
                sum -= curr;
            }
        }
        return Math.Abs(sum);
    }

    public List<long> SieveUpTo(long n)
    {
        bool[] isPrime = new bool[n + 1];
        Array.Fill(isPrime, true);
        isPrime[0] = isPrime[1] = false;

        for (long p = 2; p * p <= n; p++)
        {
            if (isPrime[p])
            {
                for (long i = p * p; i <= n; i += p)
                {
                    isPrime[i] = false;
                }
            }
        }

        List<long> primes = new List<long>();
        for (long i = 2; i <= n; i++)
        {
            if (isPrime[i])
                primes.Add(i);
        }

        return primes;
    }
}

class SolutionBi2
{
    private int rows, cols;
    private bool[][] visited;
    public int CountIslands(int[][] grid, int k)
    {
        List<int> list = Dfs(grid);
        int count = 0;
        foreach (int num in list)
        {
            if (num % k == 0) count++;
        }
        return count;
    }

    public List<int> Dfs(int[][] grid)
    {
        rows = grid.Length;
        cols = grid[0].Length;
        visited = new bool[rows][];
        for (int i = 0; i < rows; i++)
            visited[i] = new bool[cols];

        List<int> islandSums = new List<int>();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (grid[r][c] > 0 && !visited[r][c])
                {
                    int sum = Explore(grid, r, c);
                    islandSums.Add(sum);
                }
            }
        }

        return islandSums;
    }

    public int Explore(int[][] grid, int r, int c)
    {
        if (r < 0 || r >= rows || c < 0 || c >= cols)
            return 0;
        if (visited[r][c] || grid[r][c] == 0)
            return 0;

        visited[r][c] = true;
        int sum = grid[r][c];

        // Explore 4 directions
        sum += Explore(grid, r + 1, c);
        sum += Explore(grid, r - 1, c);
        sum += Explore(grid, r, c + 1);
        sum += Explore(grid, r, c - 1);

        return sum;
    }
}