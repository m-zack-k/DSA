using System;

public class Solution37
{

    private int[] rowMask = new int[9];
    private int[] colMask = new int[9];
    private int[] blockMask = new int[9];

    private List<(int y, int x)> emptyGrids = new List<(int, int)>();

    private int GetBlockIDX(int y, int x) => (y / 3) * 3 + (x / 3);
    public void SolveSudoku(char[][] board)
    {
        Array.Fill(rowMask, 0);
        Array.Fill(colMask, 0);
        Array.Fill(blockMask, 0);
        emptyGrids.Clear();

        for (int y = 0; y < 9; ++y)
        {
            for (int x = 0; x < 9; ++x)
            {
                if (board[y][x] == '.')
                {
                    emptyGrids.Add((y, x));
                }
                else
                {
                    int val = board[y][x] - '1';
                    int bit = 1 << val;

                    rowMask[y] |= bit;
                    colMask[x] |= bit;
                    blockMask[GetBlockIDX(y, x)] |= bit;
                }
            }
        }
        Backtrack(board);

    }

    private void Backtrack(char[][] grid)
    {
        if (emptyGrids.Count == 0) return;

        int best = -1;
        int minOptions = 10;

        for (int i = 0; i < emptyGrids.Count; ++i)
        {
            var (y, x) = emptyGrids[i];
            int used = rowMask[y] | colMask[x] | blockMask[GetBlockIDX(y, x)];
            int options = 9 - countBits(used);

            if (options < minOptions)
            {
                minOptions = options;
                best = i;
            }
        }

        var (row, col) = emptyGrids[best];
        int block = GetBlockIDX(row, col);
        int usedMask = rowMask[row] | colMask[col] | blockMask[block];

        for (int val = 0; val < 9; ++val)
        {
            int bit = 1 << val;
            if ((usedMask & bit) != 0)
            {
                continue;
            }
            grid[row][col] = (char)('1' + val);
            rowMask[row] |= bit;
            colMask[col] |= bit;
            blockMask[block] |= bit;

            var temp = emptyGrids[best];
            emptyGrids.RemoveAt(best);

            Backtrack(grid);
            if (emptyGrids.Count == 0) return;

            grid[row][col] = '.';
            rowMask[row] ^= bit;
            colMask[col] ^= bit;
            blockMask[block] ^= bit;
            emptyGrids.Insert(best, temp);

        }
    }

    private int countBits(int n) {
        int count = 0;
        while (n > 0)
        {
            n &= (n - 1);
            count++;
        }
        return count;
    }
    

}