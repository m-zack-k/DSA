using System;
using System.Collections.Generic;

public class Solution
{
    private int[,] up;
    private int[] depth;
    private int maxLog;
    private const long MOD = 1_000_000_007;

    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        int n = edges.Length + 1; // Nodes are 1-indexed (1 to n)
        maxLog = (int)Math.Ceiling(Math.Log2(n)) + 1;

        up = new int[n + 1, maxLog];
        depth = new int[n + 1];

        // 1. Build the Adjacency List
        List<int>[] adj = new List<int>[n + 1];
        for (int i = 0; i <= n; i++)
        {
            adj[i] = new List<int>();
        }
        foreach (var edge in edges)
        {
            adj[edge[0]].Add(edge[1]);
            adj[edge[1]].Add(edge[0]);
        }

        // 2. Precompute depths and 2^0 ancestors via DFS
        Dfs(1, 0, 0, adj);

        // 3. Populate Binary Lifting Table
        for (int i = 1; i < maxLog; i++)
        {
            for (int v = 1; v <= n; v++)
            {
                int halfWay = up[v, i - 1];
                if (halfWay != 0)
                {
                    up[v, i] = up[halfWay, i - 1];
                }
            }
        }

        // 4. Process each query
        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int u = queries[i][0];
            int v = queries[i][1];

            if (u == v)
            {
                result[i] = 0;
                continue;
            }

            int lca = GetLCA(u, v);
            int dist = depth[u] + depth[v] - 2 * depth[lca];

            // The answer is 2^(dist - 1) % MOD
            result[i] = PowerOfTwo(dist - 1);
        }

        return result;
    }

    private void Dfs(int current, int parent, int d, List<int>[] adj)
    {
        depth[current] = d;
        up[current, 0] = parent;

        foreach (var neighbor in adj[current])
        {
            if (neighbor != parent)
            {
                Dfs(neighbor, current, d + 1, adj);
            }
        }
    }

    private int GetLCA(int u, int v)
    {
        if (depth[u] < depth[v])
        {
            (u, v) = (v, u); // Swap so u is the deeper node
        }

        // Level the depths
        int diff = depth[u] - depth[v];
        for (int i = 0; i < maxLog; i++)
        {
            if ((diff & (1 << i)) != 0)
            {
                u = up[u, i];
            }
        }

        if (u == v) return u;

        // Climb together
        for (int i = maxLog - 1; i >= 0; i--)
        {
            if (up[u, i] != up[v, i])
            {
                u = up[u, i];
                v = up[v, i];
            }
        }

        return up[u, 0];
    }

    // Binary Exponentiation for modular arithmetic
    private int PowerOfTwo(int exp)
    {
        long res = 1;
        long baseVal = 2;

        while (exp > 0)
        {
            if ((exp & 1) == 1)
            {
                res = (res * baseVal) % MOD;
            }
            baseVal = (baseVal * baseVal) % MOD;
            exp >>= 1;
        }

        return (int)res;
    }
}