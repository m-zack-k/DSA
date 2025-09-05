public class Solution150DFS
{
    public int EvalRPN(string[] tokens)
    {
        var list = new List<string>(tokens);
        return DFS(list);
    }
    private int DFS(List<string> tokens)
    {
        string token = tokens[tokens.Count - 1];
        tokens.RemoveAt(tokens.Count - 1);

        if (token != "+" && token != "-" && token != "*" && token != "/")
        {
            return int.Parse(token);
        }

        int right = DFS(tokens);
        int left = DFS(tokens);

        if (token == "+")
        {
            return right + left;
        }
        else if (token == "-")
        {
            return left - right;
        }
        else if (token == "*")
        {
            return right * left;
        }
        else
        {
            return left / right;
        }
    } 
}