public class Solution {
    public int MaxProfit(int[] prices) {
       int maxCurr = 0;
        int maxSoFar = 0;
        
        for(int i = 1; i < prices.Length; i++){
            maxCurr += prices[i] - prices[i-1];
            maxCurr = Math.Max(maxCurr,  prices[i] - prices[i-1]);
            maxSoFar = Math.Max(maxSoFar, maxCurr);
        }
        
        return maxSoFar;
    }

}