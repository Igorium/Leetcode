public class Solution {
    public bool IsMatch(string s, string p) {
        //return DFS(s, p, 0, 0, new int?[s.Length+1, p.Length+1]);

        var dp = new int[s.Length+1, p.Length+1];
        dp[s.Length,p.Length] = true;

        for (int posS = s.Length; posS >= 0; posS--){
            for (int posP = p.Length - 1; posP >= 0; posP--){
                var symbolMatch = posS < s.Length && (s[posS] == p[posP] || p[posP] == '.');
                var isAsterisk = posP < p.Length-1 && p[posP+1] == '*';

                var res = false;
                if(isAsterisk){
                    // skip * and move on OR continue with current *
                    dp[posS, posP] = dp[posS, posP+2] || symbolMatch && dp[posS+1, posP];
                } else {
                    dp[posS, posP] = symbolMatch && dp[posS+1, posP+1]; // simple case
                }  

            }
        }

        return dp[0,0];
    }

    
    public bool DFS(string s, string p, int posS, int posP, int?[,] memo) {
        if(posP == p.Length)
            return posS == s.Length;

        if(memo[posS, posP] != null)
            return memo[posS, posP].Value;

        var symbolMatch = posS < s.Length && (s[posS] == p[posP] || p[posP] == '.');
        var isAsterisk = posP < p.Length-1 && p[posP+1] == '*';

        var res = false;
        if(isAsterisk){
            res = DFS(s, p, posS, posP+2); // skip * and move on
            res = res || symbolMatch && DFS(s, p, posS+1, posP); // continue with current *
        } else {
            res = symbolMatch && DFS(s, p, posS+1, posP+1); // simple case
        }

        memo[posS, posP] = res;
        return res;
    }
    
}

/*
"c"
"c*f"
*/