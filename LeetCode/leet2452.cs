public class Solution
{
    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        int n = queries.Length;
        int m = dictionary.Length;
        int size = queries[0].Length;

        var ans = new List<string>();
        int dif;

        for (int i = 0; i < n; ++i)
        {
            string word = queries[i];
            bool added = false;
            for (int j = 0; j < m; ++j)
            {
                string target = dictionary[j];
                dif = 0;
                for (int k = 0; k < size; ++k)
                {
                    if (word[k] != target[k])
                    {
                        dif++;
                    }
                }
                if (dif <= 2 && !added)
                {
                    ans.Add(word);
                    added = true;
                }
            }
        }
        return ans;
    }
}