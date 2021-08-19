public class Solution {
    public int MinTransfers(int[][] transactions) {
        var balance = new Dictionary<int, int>();
        foreach(var t in transactions){
            if(!balance.ContainsKey(t[0]))
                balance[t[0]] = 0;
            if(!balance.ContainsKey(t[1]))
                balance[t[1]] = 0;
            
            balance[t[0]] += t[2];
            balance[t[1]] -= t[2];
        }
        
        var d = balance.Values.Where(v => v != 0).ToArray();
        var n = d.Length;
        
        if(n == 0)
            return 0;
        
        int rebalance(int p){
            while(p < n && d[p] == 0)
                p++;
            
            if(p == n)
                return 0;
            
            var count = int.MaxValue;
            for(var i = p+1; i < n; i++){
                if((d[p] > 0 && d[i] < 0) || (d[p] < 0 && d[i] > 0)){
                    d[i] += d[p];
                    count = Math.Min(count, rebalance(p+1)+1);
                    d[i] -= d[p];
                }
            }
            
            return count;
        }
        
        return rebalance(0);
    }
}