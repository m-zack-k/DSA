public class Solution
{
    public string MakeLargestSpecial(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return "";
        }

        List<string> components = new List<string>();
        int count = 0;
        int left = 0;

        for (int i = 0; i < s.Length; i++)
        {
            count += s[i] == '1' ? 1 : -1;

            if (count == 0)
            {
                string innerString = s.Substring(left + 1, i - left - 1);

                string largestInner = "1" + MakeLargestSpecial(innerString) + "0";
                components.Add(largestInner);


                left = i + 1;
            }
        }

        components.Sort((a, b) => b.CompareTo(a));

        return string.Join("", components);
    }
}