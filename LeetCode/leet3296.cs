public class Solution
{
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
    {
        long low = 1;
        long hi = 10000000000000000L;

        while (low < hi)
        {
            long mid = (low + hi) >> 1;
            long tot = 0;
            for (int i = 0; i < workerTimes.Length && tot < mountainHeight)
            {
                tot += (long)(Math.Sqrt((double)mid / workerTimes[i] * 2 + 0.25) - 0.5);

            }
            if (tot >= mountainHeight)
            {
                hi = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

    }
}