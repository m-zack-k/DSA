using System;
using System.Text;

public class Solution1678 {
    public string Interpret(string command) {
        int n = command.Length;
        int i = 0;
        StringBuilder res = new StringBuilder();
        
        while (i < n) {
            if (command[i] == 'G') {
                res.Append('G');
                i++;
            } else {
                if (command[i + 1] == ')') {
                    res.Append('o');
                    i += 2;
                } else {
                    res.Append("al");
                    i += 4;
                }
            }
        }
        
        return res.ToString();
    }
}