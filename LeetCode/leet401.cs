public class Solution
{
    public IList<string> ReadBinaryWatch(int turnedOn)
    {
        List<string> res = new List<string>();

        for (int h = 0; h < 12; ++h)
        {
            for (int m = 0; m < 60; ++m)
            {
                int total = int.PopCount(h) + int.PopCount(m);

                if (total == turnedOn)
                {
                    string time = $"{h}:{m:D2}";
                    res.Add(time);
                }
            }
        }
        return res;
    }
}

