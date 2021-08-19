public class Solution {
    public int MinDistance(string word1, string word2) {
        if (word1 == null || word2 == null)
            return -1;

        var n = word1.Length;
        var m = word2.Length;

        if (n == 0)
            return m;
        if (m == 0)
            return n;

        var dp = new int[n+1, m+1];

        for(int i = 0; i <= n; i++)
            dp[i, 0] = i;

        for(int j = 0; j <= m; j++)
            dp[0, j] = j;

        for(int i = 0; i < n; i++)
            for(int j = 0; j < m; j++)
                dp[i+1, j+1] = word1[i] == word2[j] 
                    ? dp[i, j] 
                    : Math.Min(dp[i+1, j], Math.Min(dp[i, j+1], dp[i, j])) + 1;

        return dp[n, m];
    }
}

public class Solution {
    public int MinDistance(string word1, string word2) {
        if (word1 == null || word1.Length == 0)
            return word2.Length;
        if (word2 == null || word2.Length == 0)
            return word1.Length;

        return dfs(word1, word2, 0, 0, new int?[word1.Length+1, word2.Length+1]);
    }

    int dfs(string s1, string s2, int i, int j, int?[,] memo){
        if(i >= s1.Length)
            return s2.Length-j;
        if(j >= s2.Length)
            return s1.Length-i;
        
        if(memo[i, j] != null)
            return memo[i,j].Value;

        var len = 0;
        if(s1[i] == s2[j]){
            len = dfs(s1, s2, i+1, j+1, memo);
        } else {
            var ins = dfs(s1, s2, i+1, j, memo);
            var del = dfs(s1, s2, i, j+1, memo);
            var repl = dfs(s1, s2, i+1, j+1, memo);
            len = Math.Min(ins, Math.Min(del, repl)) + 1;
        }

        memo[i,j] = len;
        return len;
    }
}