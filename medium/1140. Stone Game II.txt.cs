public class Solution {
    public int StoneGameII(int[] piles) {
        var n = piles.Length;
        var maxScore = new int[n];
        
        maxScore[n-1] = piles[n-1];
        for(int i = n-2; i >= 0; i--)
            maxScore[i] = maxScore[i+1] + piles[i];
        
        var memo = new Dictionary<(int, int), int>();
        
        int DFS(int pile, int m){
            if(pile >= n)
                return 0;
            if(n-pile <= 2*m)
                return maxScore[pile];
            
            var key = (pile, m);
            if(memo.ContainsKey(key))
                return memo[key];
            
            var min = int.MaxValue;
            for(var i=1; i <= 2*m; i++){
                min = Math.Min(min, DFS(pile+i, Math.Max(i,m)));
            }

            memo[key] = maxScore[pile] - min;
            return memo[key];
        }
        
        return DFS(0, 1);
    }
}