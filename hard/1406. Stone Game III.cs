public class Solution {
    public string StoneGameIII(int[] stoneValue) {
        var n = stoneValue.Length;
        var maxScore = new int[n];
        
        maxScore[n-1] = stoneValue[n-1];
        for(int i = n-2; i >= 0; i--)
            maxScore[i] = maxScore[i+1] + stoneValue[i];
        
        var memo = new int?[n];
        
        int DFS(int pile){
            if(pile >= n)
                return 0;
            
            if(memo[pile].HasValue)
                return memo[pile].Value;
            
            var min = int.MaxValue;
            for(var i=1; i <= 3; i++){
                min = Math.Min(min, DFS(pile+i));
            }

            memo[pile] = maxScore[pile] - min;
            return memo[pile].Value;
        }
        
        var score = DFS(0)*2;
        
        return score == maxScore[0] 
            ? "Tie" 
            : score > maxScore[0] 
                ? "Alice" 
                : "Bob";
    }
}