using System;

public class Solution49 {
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        IList<IList<string>> wordList = new List<IList<string>>();
        Dictionary<string, int> IdxDict = new Dictionary<string, int>();
        int i = 0;
        foreach (string word in strs)
        {
            string sorted = string.Concat(word.OrderBy(c => c));
            if (IdxDict.ContainsKey(sorted))
            {
                wordList[IdxDict[sorted]].Add(word);
            }
            else
            {
                List<string> newList = [word];
                wordList.Add(newList);
                IdxDict[sorted] = i;
                i++;
            }
        }
        return wordList;
    }
}