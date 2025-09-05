using System;

public class Solution
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {

        var pq = new PriorityQueue<(double gain, int p, int t), double>(
            Comparer<double>.Create((a, b) => b.CompareTo(a))
        );

        foreach (var c in classes)
        {
            double gain = Gain(c[0], c[1]);
            pq.Enqueue((gain, c[0], c[1]), gain);
        }

        for (int i = 0; i < extraStudents; i++)
        {
            var (gain, p, t) = pq.Dequeue();
            p++; t++;
            pq.Enqueue((Gain(p, t), p, t), Gain(p, t));
        }

        double sum = 0;
        while (pq.Count > 0)
        {
            var (_, p, t) = pq.Dequeue();
            sum += (double)p / t;
        }

        return sum / classes.Length;
    }

    private double Gain(int p, int t)
    {
        return (double)(p + 1) / (t + 1) - (double)p / t;
    }
}
