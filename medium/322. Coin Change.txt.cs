public class Solution {
    public int CoinChange(int[] coins, int amount) {
        return CoinChange(coins, amount, new int[amount]);
    }
    
    private int CoinChange(int[] coins, int amount, int[] memo){
        if (amount == 0)
            return 0;
        
        if (memo[amount-1] != 0)
            return memo[amount-1];      
        
        var min = int.MaxValue;
        
        for(var i = 0; i < coins.Length; i++){
            if(coins[i] > amount)
                continue;
            
            var res = CoinChange(coins, amount-coins[i], memo);
            
            if(res >= 0 && res < min)
                min = res;
        }
        
        min = min == int.MaxValue ? -1 : min+1;
        
        memo[amount-1] = min;
        
        return min;
    }
}