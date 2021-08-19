public class Solution {
    public int MinReorder(int n, int[][] connections) {
        var nei = new List<int>[n];
        var res = 0;
        
        for(int i = 0; i < n; i++)
            nei[i] = new List<int>();
        
        foreach(var con in connections){
            nei[con[0]].Add(con[1]+n); // from city to next
            nei[con[1]].Add(con[0]);
        }
        
        var q = new Queue<int>();
        q.Enqueue(0);
        var visited = new HashSet<int>();
        visited.Add(0);
        
        while(q.Any()){
            var city = q.Dequeue();
            
            foreach(var next in nei[city]){
                var nextCity = next >= n ? next-n : next;
                if(visited.Contains(nextCity))
                    continue;
                
                if(next >= n)
                    res++;

                q.Enqueue(nextCity);
                visited.Add(nextCity);
            }
        }
        
        return res;
    }
}


public class Solution {
    public int MinReorder(int n, int[][] connections) {
        var nei = new List<int>[n];
        
        foreach(var con in connections){
            if(nei[con[0]] == null)
                nei[con[0]] = new List<int>();
            if(nei[con[1]] == null)
                nei[con[1]] = new List<int>();
            
            nei[con[0]].Add(con[1]+n);
            nei[con[1]].Add(con[0]);
        }
        
        return FixDirection(0, nei, n, int.MinValue);
    }
    
    private int FixDirection(int city, List<int>[] nei, int max, int prevCity){
        var res = 0;
        
        for(int j = 0; j < nei[city].Count; j++){
            var n = nei[city][j];
            
            if(n == prevCity || n-max == prevCity)
                continue;
            
            if(n >= max){
                n -= max;
                res++;
            }
            
            res += FixDirection(n, nei, max, city);
        }
        
        return res;
    }
}