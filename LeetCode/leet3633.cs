public class Solution
{
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
    {
        int m = landStartTime.Length;
        int n = waterStartTime.Length;
        int ans = int.MaxValue;

        int minLandFinish = int.MaxValue;
        for (int i = 0; i < m; ++i)
        {
            if (landStartTime[i] + landDuration[i] < minLandFinish)
            {
                minLandFinish = landStartTime[i] + landDuration[i];
            }
        }
        for (int i = 0; i < n; ++i)
        {
            if (waterStartTime[i] <= minLandFinish && minLandFinish + waterDuration[i] < ans)
            {
                ans = minLandFinish + waterDuration[i];
            }

            if (waterStartTime[i] > minLandFinish && waterStartTime[i] + waterDuration[i] < ans)
            {
                ans = waterStartTime[i] + waterDuration[i];
            }
        }

        int minWaterFinish = int.MaxValue;
        for (int i = 0; i < n; ++i)
        {
            if (waterStartTime[i] + waterDuration[i] < minWaterFinish)
            {
                minWaterFinish = waterStartTime[i] + waterDuration[i];
            }
        }

        for (int i = 0; i < m; ++i)
        {
            if (landStartTime[i] <= minWaterFinish && minWaterFinish + landDuration[i] < ans)
            {
                ans = minWaterFinish + landDuration[i];
            }

            if (landStartTime[i] > minWaterFinish && landStartTime[i] + landDuration[i] < ans)
            {
                ans = landStartTime[i] + landDuration[i];
            }
        }

        return ans;

    }
}