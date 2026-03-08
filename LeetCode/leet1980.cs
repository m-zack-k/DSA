using System.Text;

public class Solution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        int n = nums.Length;
        char[] ans = new char[n];

        for (int i = 0; i < n; ++i)
        {
            if (nums[i][i] == '0')
            {
                ans[i] = '1';
            }
            else
            {
                ans[i] = '0';
            }
        }
        return new string(ans);
    }
}