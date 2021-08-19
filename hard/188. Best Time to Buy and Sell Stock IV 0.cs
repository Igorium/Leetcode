public class Solution
{
    public int MaxProfit(int k, int[] prices){
        if (prices == null || prices.Length < 2 || k <= 0)
            return 0;
        
        if (prices.Length < 2 * k)
            k = prices.Length/2;
        
        return  DFS(prices, 0, k, new int?[prices.Length, k+1]);
    }

    int DFS(int[] prices, int start, int k, int?[,] memo){
        if(start > prices.Length-2)
            return 0;
        
        if (memo[start, k] != null) 
            return memo[start, k].Value;

        var maxProfitTotal = int.MinValue;
        var min = int.MaxValue; 
        for (int i = start; i < prices.Length; i++){
            min = Math.Min(min, prices[i]);
            var profit = prices[i]-min;
            if (k > 1)
                profit += DFS(prices, i + 1, k - 1, memo);
            maxProfitTotal = Math.Max(maxProfitTotal, profit);
        }
        
        if(maxProfitTotal < 0)
            maxProfitTotal = 0;

        memo[start, k] = maxProfitTotal;
        return maxProfitTotal;
    }
}