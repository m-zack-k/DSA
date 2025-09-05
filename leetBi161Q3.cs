public class SolutionQ3 {
    public int FindMaxPathScore(int[][] edges, bool[] online, long k) {

        int n = online.Length;
        List<(int to, int cost)>[] graph = new List<(int, int)>[n];
        for (int i = 0; i < n; i++) graph[i] = new List<(int, int)>();
        foreach (var edge in edges) {
            int u = edge[0], v = edge[1], cost = edge[2];
            graph[u].Add((v, cost));
        }

        int left = 0, right = (int)1e9;
        int answer = -1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (IsPathPossible(graph, online, k, mid, n)) {
                answer = mid;
                left = mid + 1;
            } else {
                right = mid - 1; 
            }
        }

        return answer;
    }

    private bool IsPathPossible(List<(int to, int cost)>[] graph, bool[] online, long k, int minScore, int n) {
        long[] costSoFar = new long[n];
        for (int i = 0; i < n; i++) costSoFar[i] = long.MaxValue;
        costSoFar[0] = 0;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Count > 0) {
            int u = queue.Dequeue();
            foreach (var (v, cost) in graph[u]) {
                if (cost < minScore) continue;
                if (v != 0 && v != n - 1 && !online[v]) continue;
                long newCost = costSoFar[u] + cost;
                if (newCost < costSoFar[v]) {
                    costSoFar[v] = newCost;
                    if (newCost <= k) {
                        queue.Enqueue(v);
                    }
                }
            }
        }

        return costSoFar[n - 1] <= k;
    }
}