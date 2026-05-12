public class Solution
{
    public int[][] RotateGrid(int[][] grid, int k)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int layers = Math.Max(m, n) / 2 - Math.Abs(m - n) % 2;
        int temp;
        for (int i = 0; i < layers; ++i)
        {
            int prev = grid[i][1];
            for (int j = i; j < m - i; ++j)
            {
                temp = grid[j][i];
                grid[j][i] = prev;
                prev = temp;
            }
            for (int j = i + 1; j < n - i; ++j)
            {
                temp = grid[m - i][j];
                grid[m - i][j] = prev;
                prev = temp;
            }
            for (int j = m - 1 - i; j >= i; j--)
            {
                temp = grid[j][n - i];
                grid[j][n - i] = prev;
                prev = temp;
            }
            for (int j = m - 1 - i; j > i; j--)
            {
                temp = grid[i][j];
                grid[i][j] = prev;
                prev = temp;
            }
        }
        return grid;
    }
}

using System;
using System.Collections.Generic;

public class Solution {
    public int[][] RotateGrid(int[][] grid, int k) {
        int m = grid.Length;
        int n = grid[0].Length;
        int layers = Math.Min(m, n) / 2;

        for (int layer = 0; layer < layers; layer++) {
            // Define the boundaries for the current layer
            int top = layer;
            int bottom = m - 1 - layer;
            int left = layer;
            int right = n - 1 - layer;

            // Step 1: Extract the elements of the current layer in a ring order
            List<int> ring = new List<int>();
            
            // Top edge (left to right)
            for (int j = left; j < right; j++) ring.Add(grid[top][j]);
            // Right edge (top to bottom)
            for (int i = top; i < bottom; i++) ring.Add(grid[i][right]);
            // Bottom edge (right to left)
            for (int j = right; j > left; j--) ring.Add(grid[bottom][j]);
            // Left edge (bottom to top)
            for (int i = bottom; i > top; i--) ring.Add(grid[i][left]);

            // Step 2: Calculate the effective rotation
            int len = ring.Count;
            int effectiveK = k % len;
            
            // Step 3: Write the rotated elements back into the grid
            int index = effectiveK;

            // Top edge (left to right)
            for (int j = left; j < right; j++) {
                grid[top][j] = ring[index % len];
                index++;
            }
            // Right edge (top to bottom)
            for (int i = top; i < bottom; i++) {
                grid[i][right] = ring[index % len];
                index++;
            }
            // Bottom edge (right to left)
            for (int j = right; j > left; j--) {
                grid[bottom][j] = ring[index % len];
                index++;
            }
            // Left edge (bottom to top)
            for (int i = bottom; i > top; i--) {
                grid[i][left] = ring[index % len];
                index++;
            }
        }

        return grid;
    }
}