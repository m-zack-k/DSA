public class Solution
{
    int MOD = 1_000_000_007;
    private int power(long a, long b)
    {
        long ans = 1;
        a %= MOD;
        while (b > 0)
        {
            if ((b & 1) == 1)
            {
                ans = (ans * a) % MOD;
            }

            a = (a * a) % MOD;
            b >>= 1;
        }

        return (int)ans;
    }

    private int dfs(int node, int parent, List<List<int>> adj)
    {
        int ans = 0;

        foreach (int child in adj[node])
        {
            if (child != parent)
            {
                ans = Math.Max(ans, 1 + dfs(child, node, adj));
            }
        }
        return ans;
    }
    public int AssignEdgeWeights(int[][] edges)
    {
        int n = edges.Length + 1;
        var adjList = new List<List<int>>();
        for (int i = 0; i <= n; ++i)
        {
            adjList.Add(new List<int>());
        }

        foreach (var edge in edges)
        {
            int u = edge[0];
            int v = edge[1];

            adjList[u].Add(v);
            adjList[v].Add(u);
        }

        int depth = dfs(1, -1, adjList);

        return power(2, depth - 1);

    }
}