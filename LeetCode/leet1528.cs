public class Solution
{
    public string RestoreString(string s, int[] indices)
    {
        int n = s.Length;
        char[] ordered = new char[n];
        for (int i = 0; i < n; ++i)
        {
            ordered[indices[i]] = s[i];
        }
        return new string(ordered);
    }
}