public class Solution
{
    public int MinOperations(string s)
    {
        int n = s.Length;
        // pattern 01010101...
        int difA = 0;
        // pattern 10101010...
        int difB = 0;
        for (int i = 0; i < n; ++i)
        {
            int curr = int.Parse(s[i].ToString());
            int a = i % 2;
            int b = (i + 1) % 2;
            difA += Math.Abs(curr - a);
            difB += Math.Abs(curr - b);
        }
        return Math.Min(difA, difB);
    }
}