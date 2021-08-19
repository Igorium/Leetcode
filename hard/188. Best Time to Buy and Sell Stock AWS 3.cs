/*
  You're given an array of positive integers representing the prices of a single stock on
  various days (each index in the array represents a different day). You're also
  given an integer k, which represents the number of transactions
  you're allowed to make. One transaction consists of buying the stock on a
  given day and selling it on another, later day.
  
  Write a function that returns the maximum profit that you can make by buying
  and selling the stock, given k transactions.
  
  Note that you can only hold one share of the stock at a time; in other words,
  you can't buy more than one share of the stock on any given day, and you can't
  buy a share of the stock if you're still holding another share. Also, you
  don't need to use all k transactions that you're allowed.
  
  Input = [5, 11, 3, 50, 60, 90]
  k = 2
  
  Output = 93
  
  5, 11, 3, 50, 60, 90
  
  3, 5
  
  60, 90
  
day0  0, 6, -2, 45, 55, 85
day1     0, -8, 39, 49, 79

 55 11 3    60 90 
  */

class Program {
  public static int maxProfitWithKTransactions(int[] prices, int k) {
    if(prices == null || prices.Length < 2*k) // false
        return -1;
      
    return DFS(prices, 0, k, new int?[prices.Length, k]); // [1,2], 0, 1, new[][]
  }
  
  int DFS(int[] prices, int start, int k, int?[,] memo){ //
    if(memo[start, k] != null) //
        return memo[start,k];//
    
    var maxProfitTotal = int.MinValue;//
    for(int i = start; i <= prices.Length-(k-1)*2; i++){//
        var profit = prices[start] - prices[i];
        if(k > 1)
            profit += DFS(prices, i+1, k-1, memo);
        maxProfitTotal = Math.Max(maxProfitTotal, profit);//
    }
    
    memo[start, k] = maxProfitTotal;//
    return maxProfitTotal;
  }
}

/*
class Program { 
    // O(nk) time | O(nk) space 
    public static int maxProfitWithKTra if (prices.length == 0) { return 0; } 
    int[][] profits = new int[k + 1] 
    for (int t = 1; t < k + 1; t++) {
        int maxThusFar = Integer.MIN_VAL; 
        for (int d = 1; d < prices.length; d++) {
            maxThusFar = Math.max(maxThus profits[t][d] = Math.max(profits[t-1][d-1] - prices[d - 1]; 
            profits[t][d] = Math.max(profits[t][d-1], maxThusFar - prices[d]);
            
            return profits[k][prices.length - 1];
        } 
    }
}
*/

