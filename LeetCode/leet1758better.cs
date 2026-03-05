public class Solution
{
    public int MinOperations(string s)
    {
        int n = s.Length;
        int difA = 0;

        for (int i = 0; i < n; i++)
        {
            int curr = s[i] - '0';
            int expected = i & 1;     // same as i % 2 but slightly cheaper
            difA += curr ^ expected;  // adds 1 if mismatch
        }

        return Math.Min(difA, n - difA);
    }
}