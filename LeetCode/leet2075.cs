using System.Text;

public class Solution
{
    public string DecodeCiphertext(string encodedText, int rows)
    {
        int cols = encodedText.Length / rows;
        var sb = new StringBuilder();

        for (int i = 0; i < cols; ++i)
        {
            for (int r = 0, c = i; r < rows && c < cols; r++, c++)
            {
                sb.Append(encodedText[r * cols + c]);
            }
        }

        return sb.ToString().TrimEnd();
    }
}