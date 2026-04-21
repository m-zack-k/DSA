public class Solution {
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps) {
        int n = source.Length;
        UnionFind uf = new UnionFind(n);
        
        foreach (var swap in allowedSwaps) {
            uf.Union(swap[0], swap[1]);
        }
        
         Dictionary<int, Dictionary<int, int>> componentFrequencies = new Dictionary<int, Dictionary<int, int>>();
        
        for (int i = 0; i < n; i++) {
            int root = uf.Find(i);
            
            if (!componentFrequencies.ContainsKey(root)) {
                componentFrequencies[root] = new Dictionary<int, int>();
            }
            
            int num = source[i];
            if (!componentFrequencies[root].ContainsKey(num)) {
                componentFrequencies[root][num] = 0;
            }
            
            componentFrequencies[root][num]++;
        }
        
        int hammingDistance = 0;
        
        for (int i = 0; i < n; i++) {
            int root = uf.Find(i);
            int targetNum = target[i];
            
             if (componentFrequencies[root].ContainsKey(targetNum) && componentFrequencies[root][targetNum] > 0) {
                componentFrequencies[root][targetNum]--;
            } else {
                hammingDistance++;
            }
        }
        
        return hammingDistance;
    }

   private class UnionFind {
        private int[] parent;
        private int[] rank;

        public UnionFind(int size) {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++) {
                parent[i] = i;
                rank[i] = 1;
            }
        }

        public int Find(int p) {
            if (p == parent[p]) return p;
            
            // Path Compression
            parent[p] = Find(parent[p]);
            return parent[p];
        }

        public void Union(int p, int q) {
            int rootP = Find(p);
            int rootQ = Find(q);

            if (rootP == rootQ) return;

            // Union by Rank
            if (rank[rootP] > rank[rootQ]) {
                parent[rootQ] = rootP;
            } else if (rank[rootP] < rank[rootQ]) {
                parent[rootP] = rootQ;
            } else {
                parent[rootQ] = rootP;
                rank[rootP]++;
            }
        }
    }
}