using System.Collections.Generic;

public class Solution {
    public bool ContainsCycle(char[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        // Keep track of visited cells to avoid infinite loops and find components
        bool[,] visited = new bool[rows, cols];
        
        // Direction vectors for moving Up, Down, Left, Right
        int[] dRow = {-1, 1, 0, 0};
        int[] dCol = {0, 0, -1, 1};
        
        // Check every cell as a potential starting point for a new component
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                if (!visited[i, j]) {
                    
                    // Queue stores tuples of: (currentRow, currentCol, parentRow, parentCol)
                    Queue<(int r, int c, int pr, int pc)> queue = new Queue<(int, int, int, int)>();
                    
                    queue.Enqueue((i, j, -1, -1));
                    visited[i, j] = true;
                    
                    while (queue.Count > 0) {
                        var curr = queue.Dequeue();
                        int r = curr.r;
                        int c = curr.c;
                        int pr = curr.pr;
                        int pc = curr.pc;
                        
                        // Explore all 4 neighbors
                        for (int d = 0; d < 4; d++) {
                            int nr = r + dRow[d];
                            int nc = c + dCol[d];
                            
                            // Ensure the neighbor is within bounds and has the same character
                            if (nr >= 0 && nr < rows && nc >= 0 && nc < cols && grid[nr][nc] == grid[r][c]) {
                                
                                if (!visited[nr, nc]) {
                                    // If unvisited, mark as visited and add to queue
                                    visited[nr, nc] = true;
                                    queue.Enqueue((nr, nc, r, c));
                                } 
                                else if (nr != pr || nc != pc) {
                                    // If it IS visited, but it is NOT the cell we just came from,
                                    // it means we've looped back around on our path. Cycle detected!
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        
        // If we process the entire grid without finding a cycle
        return false;
    }
}