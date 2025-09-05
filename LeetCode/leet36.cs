using System;

public class Solution36 {
    public bool IsValidSudoku(char[][] board)
    {
        var set = new HashSet<char>();
        for (int i = 0; i < 9; ++i)
        {
            for (int j = 0; j < 9; ++j)
            {
                char curr = board[i][j];
                if (curr != '.')
                {
                    if (set.Contains(curr))
                    {
                        return false;
                    }
                    else
                    {
                        set.Add(curr);
                    }
                }
            }
            set.Clear();
        }
        for (int j = 0; j < 9; ++j)
        {
            for (int i = 0; i < 9; ++i)
            {
                char curr = board[i][j];
                if (curr != '.')
                {
                    if (set.Contains(curr))
                    {
                        return false;
                    }
                    else
                    {
                        set.Add(curr);
                    }
                }
            }
            set.Clear();
        }
        for (int i = 0; i <= 6; i += 3)
        {
            for (int j = 0; j <= 6; j += 3)
            {

                for (int k = i; k < i + 3; ++k)
                {
                    for (int l = j; l < j + 3; ++l)
                    {
                        char curr = board[k][l];
                        if (curr != '.')
                        {
                            if (set.Contains(curr))
                            {
                                return false;
                            }
                            else
                            {
                                set.Add(curr);
                            }
                        }
                    }
                }
                set.Clear();
            }
        }
        return true;

    }
}