
public class Solution
{

    int n;
    public bool FindRotation(int[][] mat, int[][] target)
    {
        n = mat.Length;
        if (Equal(mat, target))
        {
            return true;
        }
        for (int i = 0; i < 3; ++i)
        {
            int[][] curr = RotateNintyClockwise(mat);
            if (Equal(curr, target))
            {
                return true;
            }
            mat = curr;
        }
        return false;
    }

    public int[][] RotateNintyClockwise(int[][] original)
    {
        int[][] res = new int[n][];
        for (int i = 0; i < n; ++i)
        {
            res[i] = new int[n];
        }
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                res[i][j] = original[n - 1 - j][i];
            }
        }

        return res;
    }

    public bool Equal(int[][] a, int[][] b)
    {
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (a[i][j] != b[i][j])
                {
                    return false;
                }
            }
        }
        return true;
    }
}