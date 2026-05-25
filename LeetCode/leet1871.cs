public bool CanReach(string s, int minJump, int maxJump)
{
    int n = s.Length;
    if (s[n - 1] == '1') { return false; }

    int[] dp = new int[n + maxJump + 1];
    dp[minJump]++;
    dp[maxJump + 1]--;
    for (int i = 1; i < n; i++)
    {
        dp[i] += dp[i - 1];
        if (s[i] == '1') continue;
        if (dp[i] == 0) continue;

        dp[i + minJump]++;
        dp[i + maxJump + 1]--;
    }

    return dp[n - 1] > 0;
}