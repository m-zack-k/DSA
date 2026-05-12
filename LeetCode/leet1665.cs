public class Solution
{
    public int MinimumEffort(int[][] tasks)
    {
        Array.Sort(tasks, (a, b) => (a[1] - a[0]).CompareTo(b[1] - b[0]));
        int res = 0;
        foreach (int[] task in tasks)
        {
            res = Math.Max(res + task[0], task[1]);
        }
        return res;
    }
}