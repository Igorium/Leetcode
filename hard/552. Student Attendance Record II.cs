public class Solution {
    
    public int CheckRecord(int n) {
        var M = (long)Math.Pow(10, 9)+7;
        var dp = new long[n<=5 ? 6 : n+1];
        dp[0] = 1;
        dp[1] = 2;
        dp[2] = 4;
        dp[3] = 7; // 8-1
        
        for(var i = 4; i <= n; i++){
            dp[i] = ((2*dp[i-1])%M + (M -  dp[i-4])) % M;
        }
        
        var sum = dp[n];
        for(var i = 1; i <= n; i++){
            sum += (dp[i-1] * dp[n-i]) % M;
        }
        
        return (int)(sum % M);
    }
}