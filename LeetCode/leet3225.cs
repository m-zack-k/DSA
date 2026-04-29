public class Solution
{
    public long MaximumScore(int[][] grid)
    {
        int size = grid[0].Length;
        if (size == 1)
        {
            return 0;
        }

        // dp[col][currentHeight][previousHeight]
        long[,,] dp = new long[size, size + 1, size + 1];

        // prefix max and suffix max helpers
        long[,] bestPrefix = new long[size + 1, size + 1];
        long[,] bestSuffix = new long[size + 1, size + 1];

        // column prefix sums
        long[,] columnPrefixSum = new long[size, size + 1];

        // Build prefix sums for each column
        for (int col = 0; col < size; col++)
        {
            for (int row = 1; row <= size; row++)
            {
                columnPrefixSum[col, row] =
                    columnPrefixSum[col, row - 1] + grid[row - 1][col];
            }
        }

        // Process columns one by one
        for (int col = 1; col < size; col++)
        {
            for (int currentHeight = 0; currentHeight <= size; currentHeight++)
            {
                for (int previousHeight = 0; previousHeight <= size; previousHeight++)
                {

                    if (currentHeight <= previousHeight)
                    {
                        long gainedScore =
                            columnPrefixSum[col, previousHeight] -
                            columnPrefixSum[col, currentHeight];

                        dp[col, currentHeight, previousHeight] =
                            Math.Max(
                                dp[col, currentHeight, previousHeight],
                                bestSuffix[previousHeight, 0] + gainedScore
                            );
                    }
                    else
                    {
                        long gainedScore =
                            columnPrefixSum[col - 1, currentHeight] -
                            columnPrefixSum[col - 1, previousHeight];

                        dp[col, currentHeight, previousHeight] =
                            Math.Max(
                                dp[col, currentHeight, previousHeight],
                                Math.Max(
                                    bestSuffix[previousHeight, currentHeight],
                                    bestPrefix[previousHeight, currentHeight] + gainedScore
                                )
                            );
                    }
                }
            }

            // Update helper arrays
            for (int currentHeight = 0; currentHeight <= size; currentHeight++)
            {

                bestPrefix[currentHeight, 0] = dp[col, currentHeight, 0];

                for (int previousHeight = 1; previousHeight <= size; previousHeight++)
                {
                    long penalty =
                        (previousHeight > currentHeight)
                        ? (columnPrefixSum[col, previousHeight] -
                           columnPrefixSum[col, currentHeight])
                        : 0;

                    bestPrefix[currentHeight, previousHeight] =
                        Math.Max(
                            bestPrefix[currentHeight, previousHeight - 1],
                            dp[col, currentHeight, previousHeight] - penalty
                        );
                }

                bestSuffix[currentHeight, size] = dp[col, currentHeight, size];

                for (int previousHeight = size - 1; previousHeight >= 0; previousHeight--)
                {
                    bestSuffix[currentHeight, previousHeight] =
                        Math.Max(
                            bestSuffix[currentHeight, previousHeight + 1],
                            dp[col, currentHeight, previousHeight]
                        );
                }
            }
        }

        long result = 0;

        for (int prevHeight = 0; prevHeight <= size; prevHeight++)
        {
            result = Math.Max(
                result,
                Math.Max(
                    dp[size - 1, size, prevHeight],
                    dp[size - 1, 0, prevHeight]
                )
            );
        }

        return result;
    }
}