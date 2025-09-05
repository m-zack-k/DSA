using System;
using System.Collections;

class Program {

    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> pascal = new List<IList<int>>();
        for (int i = 0; i < numRows; ++i)
        {
            List<int> row = new List<int>();
            row.Add(1);

            for (int j = 1; j < i; ++j)
            {
                int val = pascal[i - 1][j - 1] + pascal[i - 1][j];
                row.Add(val);
            }
            if (i > 0) row.Add(1);
            pascal.Add(row);
        }
        return pascal;
    }
}