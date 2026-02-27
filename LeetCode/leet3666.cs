public class Solution
{
    public int MinOperations(string s, int k)
    {
        int stringLength = s.Length;
        int initialZeros = 0;

        foreach (char ch in s)
        {
            if (ch == '0')
            {
                initialZeros++;
            }
        }

        int[] minOperations = new int[stringLength + 1];
        Array.Fill(minOperations, -1);

        List<SortedSet<int>> unvisitedZeroCounts = new List<SortedSet<int>> {
            new SortedSet<int>(),
            new SortedSet<int>()
        };

        for (int i = 0; i <= stringLength; i++)
        {
            unvisitedZeroCounts[i % 2].Add(i);
        }

        Queue<int> bfsQueue = new Queue<int>();

        bfsQueue.Enqueue(initialZeros);
        minOperations[initialZeros] = 0;
        unvisitedZeroCounts[initialZeros % 2].Remove(initialZeros);

        while (bfsQueue.Count > 0)
        {
            int currentZeros = bfsQueue.Dequeue();
            int currentOnes = stringLength - currentZeros;

            if (currentZeros == 0)
            {
                break;
            }

            int minZerosToFlip = Math.Max(0, k - currentOnes);

            int maxZerosToFlip = Math.Min(currentZeros, k);


            int minNextZeros = currentZeros + k - 2 * maxZerosToFlip;

            int maxNextZeros = currentZeros + k - 2 * minZerosToFlip;

            int targetParity = minNextZeros % 2;
            var targetSet = unvisitedZeroCounts[targetParity];

            var validUnvisitedStates = targetSet.GetViewBetween(minNextZeros, maxNextZeros).ToList();

            foreach (int nextZeros in validUnvisitedStates)
            {
                minOperations[nextZeros] = minOperations[currentZeros] + 1;
                bfsQueue.Enqueue(nextZeros);
                targetSet.Remove(nextZeros);
            }
        }

        return minOperations[0];
    }
}