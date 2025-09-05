using System;
using System.Transactions;

public class Solution19 {
    public IList<int> GetRow(int rowIndex)
    {
        IList<int> prevList = new List<int>{1};
        IList<int> curr = new List<int>();

        for (int i = 1; i <= rowIndex; ++i)
        {
            curr = new List<int>();
            curr.Add(1);
            for (int j = 1; j < prevList.Count; ++j)
            {
                int val = prevList[j - 1] + prevList[j];
                curr.Add(val);
            }
            curr.Add(1);
            prevList = curr;
        }
        return prevList;
    }
}