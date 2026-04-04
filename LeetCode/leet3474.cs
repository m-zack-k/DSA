public class Solution {
    public string GenerateString(string str1, string str2) {
        char[] s = str1.ToCharArray();
        int n = s.Length;
        int m = str2.Length;

        char[] ans = new char[n + m - 1];

        for (int i = 0; i < ans.Length; i++) {
            ans[i] = '?';
        }

        for (int i = 0; i < n; i++) {
            if (s[i] != 'T') continue;

            for (int j = 0; j < m; j++) {
                char v = ans[i + j];
                if (v != '?' && v != str2[j]) {
                    return "";
                }
                ans[i + j] = str2[j];
            }
        }

        char[] oldAns = (char[])ans.Clone();

        for (int i = 0; i < ans.Length; i++) {
            if (ans[i] == '?') {
                ans[i] = 'a';
            }
        }

        for (int i = 0; i < n; i++) {
            if (s[i] != 'F') continue;

            bool equals = true;
            for (int j = 0; j < m; j++) {
                if (ans[i + j] != str2[j]) {
                    equals = false;
                    break;
                }
            }

            if (!equals) continue;

            bool ok = false;
            for (int j = i + m - 1; j >= i; j--) {
                if (oldAns[j] == '?') {
                    ans[j] = 'b';
                    ok = true;
                    break;
                }
            }

            if (!ok) {
                return "";
            }
        }

        return new string(ans);
    }
}