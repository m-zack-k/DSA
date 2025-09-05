using System;

public class Solution2373
{
    public int[][] LargestLocal(int[][] grid)
    {
        return MaxPool2D(grid, 3, 1);
    }

    private int[][] MaxPool2D(int[][] input, int window, int stride)
    {
        int inSize = input.Length;
        int outSize = (inSize - window) / stride + 1;
        int[][] output = new int[outSize][];
        for (int i = 0; i < outSize; ++i)
        {
            output[i] = new int[outSize];
        }

        for (int row = 0; row < outSize; ++row)
        {
            for (int col = 0; col < outSize; ++col)
            {
                int rowStart = row * stride;
                int colStart = col * stride;

                int max = int.MinValue;

                for (int i = 0; i < window; ++i)
                {
                    for (int j = 0; j < window; ++j)
                    {
                        int val = input[rowStart + i][colStart + j];
                        if (val > max) max = val;
                    }
                }
                output[row][col] = max;
            }
        }
        return output;
        
    }
}