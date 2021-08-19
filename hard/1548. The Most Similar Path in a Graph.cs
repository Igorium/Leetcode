public class Solution {
    public IList<int> MostSimilar(int n, int[][] roads, string[] names, string[] targetPath) {
        var g = new List<int>[n];
        var len = targetPath.Length;
        
        foreach(var r in roads){
            var a = r[0];
            var b = r[1];
            if(g[a] == null)
                g[a] = new List<int>();
            if(g[b] == null)
                g[b] = new List<int>();
            
            g[a].Add(b);
            g[b].Add(a);
        }
        
        var end = targetPath[len-1];
        var dp = new int[len, n][];
        
        for(int j = 0; j < n; j++){
            dp[len-1,j] = new []{ names[j]==end ? 0 : 1, -1}; // cost;next city
        }
        
        for(var i = len-1; i > 0; i--){
            var currMin = int.MaxValue;
            for(var j = 0; j < n; j++){
                var city = dp[i,j];
                if(city == null || city[0]-i >= currMin)
                    continue;
                
                foreach(var nei in g[j]){
                    var cost = city[0] + (names[nei] == targetPath[i-1] ? 0 : 1);
                    if(dp[i-1, nei] == null || cost < dp[i-1, nei][0]){
                        dp[i-1, nei] = new []{cost, j};
                        currMin = Math.Min(currMin,cost);
                    }
                }
            }
        }
        
        var min = int.MaxValue;
        var res = new int[len];
        
        for(int j = 0; j < n; j++){
            var cur = dp[0,j];
            if(cur != null && cur[0] < min){
                min = cur[0];
                res[0] = j;
            }
        }
        
        for(int i = 0; i < len-1; i++){
            res[i+1] = dp[i,res[i]][1];
        }
        
        return res;
    }
}