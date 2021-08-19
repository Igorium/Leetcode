public class Solution {
    public int[] AssignBikes(int[][] workers, int[][] bikes) {
        var lenW = workers.Length;
        var lenB = bikes.Length;
        var res = new int[lenW];
        var buckets = new List<ValueTuple<int, int>>[2000];
        
        for(var w = 0; w < lenW; w++){
            for(var b = 0; b < lenB; b++){
                var dist = Math.Abs(bikes[b][0] - workers[w][0]) + Math.Abs(bikes[b][1] - workers[w][1]);
                if (buckets[dist] == null){
                    buckets[dist] = new List<ValueTuple<int,int>>{(w, b)};
                } else {
                    buckets[dist].Add((w,b));
                }
            }
        }
        
        var left = lenW;
        for(int i = 0; i < buckets.Length && left > 0; i++){
            var list = buckets[i];
            if(list == null)
                continue;
            
            foreach((var w, var b) in list){
                if(workers[w] != null && bikes[b] != null){
                    res[w] = b;
                    workers[w] = null;
                    bikes[b] = null;
                    left--;
                }
            }
        }
        
        return res;
    }

}