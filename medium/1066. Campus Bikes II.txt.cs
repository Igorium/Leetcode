public class Solution {
    public int AssignBikes(int[][] workers, int[][] bikes) {
        var memo = new Dictionary<ValueTuple<int,int>, int>();
        
        int DFS(int w, int taken){
            if(w == workers.Length)
                return 0;
            
            var key = (w,taken);
            if(memo.ContainsKey(key))
                return memo[key];
            
            var min = int.MaxValue;
            for(var b = 0; b < bikes.Length; b++){
                if((taken & (1<<b)) > 0)
                    continue;
                
                var dist = Math.Abs(workers[w][0]-bikes[b][0]) + Math.Abs(workers[w][1]-bikes[b][1]);
                min = Math.Min(min, DFS(w+1, (taken | (1<<b)))+dist);
            }
            
            memo[key] = min;
            return min;
        }
        
        return DFS(0, 0);
    }
}