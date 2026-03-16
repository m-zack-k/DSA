public class TopThreeTracker
{
    private int[] topValues;

    public TopThreeTracker()
    {
        topValues = new int[3];
    }

    public void Add(int value)
    {
        if (value > topValues[0])
        {
            topValues[2] = topValues[1];
            topValues[1] = topValues[0];
            topValues[0] = value;
        }
        else if (value != topValues[0] && value > topValues[1])
        {
            topValues[2] = topValues[1];
            topValues[1] = value;
        }
        else if (value != topValues[0] && value != topValues[1] && value > topValues[2])
        {
            topValues[2] = value;
        }
    }

    public List<int> GetValues()
    {
        List<int> result = new List<int>();

        foreach (int value in topValues)
        {
            if (value != 0)
            {
                result.Add(value);
            }
        }

        return result;
    }
}

public class Solution
{
    public int[] GetBiggestThree(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;

        int[,] diagDownRightPrefix = new int[rows + 1, cols + 2];
        int[,] diagDownLeftPrefix = new int[rows + 1, cols + 2];

        for (int row = 1; row <= rows; row++)
        {
            for (int col = 1; col <= cols; col++)
            {
                diagDownRightPrefix[row, col] =
                    diagDownRightPrefix[row - 1, col - 1] + grid[row - 1][col - 1];

                diagDownLeftPrefix[row, col] =
                    diagDownLeftPrefix[row - 1, col + 1] + grid[row - 1][col - 1];
            }
        }

        TopThreeTracker topThree = new TopThreeTracker();

        for (int centerRow = 0; centerRow < rows; centerRow++)
        {
            for (int centerCol = 0; centerCol < cols; centerCol++)
            {
                // Single cell rhombus
                topThree.Add(grid[centerRow][centerCol]);

                for (int bottomRow = centerRow + 2; bottomRow < rows; bottomRow += 2)
                {
                    int topRow = centerRow;
                    int topCol = centerCol;

                    int bottomCol = centerCol;

                    int leftRow = (centerRow + bottomRow) / 2;
                    int leftCol = centerCol - (bottomRow - centerRow) / 2;

                    int rightRow = (centerRow + bottomRow) / 2;
                    int rightCol = centerCol + (bottomRow - centerRow) / 2;

                    if (leftCol < 0 || rightCol >= cols)
                        break;

                    int rhombusBorderSum =
                        (diagDownLeftPrefix[leftRow + 1, leftCol + 1] - diagDownLeftPrefix[topRow, topCol + 2]) +
                        (diagDownRightPrefix[rightRow + 1, rightCol + 1] - diagDownRightPrefix[topRow, topCol]) +
                        (diagDownRightPrefix[bottomRow + 1, bottomCol + 1] - diagDownRightPrefix[leftRow, leftCol]) +
                        (diagDownLeftPrefix[bottomRow + 1, bottomCol + 1] - diagDownLeftPrefix[rightRow, rightCol + 2]) -
                        (grid[topRow][topCol] + grid[bottomRow][bottomCol] +
                         grid[leftRow][leftCol] + grid[rightRow][rightCol]);

                    topThree.Add(rhombusBorderSum);
                }
            }
        }

        List<int> result = topThree.GetValues();
        return result.ToArray();
    }
}