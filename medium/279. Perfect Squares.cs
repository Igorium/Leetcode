public class Solution {
    public int NumSquares(int n) {
        var dp = Enumerable.Repeat(int.MaxValue, n+1).ToArray();
        dp[0] = 0;
        
        for(int i = 1; i <= n; i++){
            for(int j = 1; j*j <= i; j++){
                dp[i] = Math.Min(dp[i], dp[i - j*j] + 1);
            }
        }
        
        return dp[n];
    }
}