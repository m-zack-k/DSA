public class Solution
{
    public double AngleClock(int hour, int minutes)
    {
        double h = 30.0 * (hour % 12) + minutes / 2.0;
        double m = minutes * 6.0;
        double angle = Math.Max(h, m) - Math.Min(h, m);
        return angle < 180.0 ? angle : 360.0 - angle;
    }
}