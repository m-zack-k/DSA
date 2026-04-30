public class Solution {
    public bool HasValidPath(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        bool[,] visited = new bool[m, n];
        
        // Directions mapping exactly as requested:
        // 0: Up, 1: Right, 2: Down, 3: Left
        int[][] dirs = new int[][] {
            new int[] {-1, 0}, // 0
            new int[] {0, 1},  // 1
            new int[] {1, 0},  // 2
            new int[] {0, -1}  // 3
        };
        
        // Mapping each street type (1-6) to its valid directions.
        // Index 0 is an empty placeholder since streets are 1-indexed.
        int[][] streetDirs = new int[][] {
            new int[] {},       // 0: Invalid
            new int[] {1, 3},   // 1: Right, Left
            new int[] {0, 2},   // 2: Up, Down
            new int[] {2, 3},   // 3: Down, Left
            new int[] {1, 2},   // 4: Right, Down
            new int[] {0, 3},   // 5: Up, Left
            new int[] {0, 1}    // 6: Up, Right
        };
        
        return Dfs(0, 0, grid, visited, dirs, streetDirs, m, n);
    }
    
    private bool Dfs(int x, int y, int[][] grid, bool[,] visited, int[][] dirs, int[][] streetDirs, int m, int n) {
        // Base case: Reached the target cell
        if (x == m - 1 && y == n - 1) {
            return true;
        }
        
        visited[x, y] = true;
        int currentStreet = grid[x][y];
        
        // Explore all valid outgoing directions for the current street
        foreach (int dir in streetDirs[currentStreet]) {
            int nx = x + dirs[dir][0];
            int ny = y + dirs[dir][1];
            
            // Check grid bounds and ensure we haven't visited the cell yet
            if (nx >= 0 && nx < m && ny >= 0 && ny < n && !visited[nx, ny]) {
                
                int nextStreet = grid[nx][ny];
                int expectedIncomingDir = (dir + 2) % 4; // The reverse of our current direction
                
                // Verify if the destination street connects back to us
                bool isValidConnection = false;
                foreach (int nextDir in streetDirs[nextStreet]) {
                    if (nextDir == expectedIncomingDir) {
                        isValidConnection = true;
                        break;
                    }
                }
                
                // If the path is valid, continue traversing
                if (isValidConnection) {
                    if (Dfs(nx, ny, grid, visited, dirs, streetDirs, m, n)) {
                        return true;
                    }
                }
            }
        }
        
        return false;
    }
}