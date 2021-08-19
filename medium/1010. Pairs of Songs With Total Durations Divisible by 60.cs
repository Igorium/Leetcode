public class Solution {
    public int NumPairsDivisibleBy60(int[] time) {
        var map = new Dictionary<int, int>();
        foreach(var t in time){
            var n = t%60;
            if(map.ContainsKey(n))
                map[n]++;
            else
                map[n] = 1;
        }

        var res = 0;
        foreach(var term1 in map.Keys.ToArray()){
            if(term1 == 30 || term1 == 0){
                var n = map[term1]-1;
                res += ((n*n+n)/2);
                continue;
            }

            var term2 = 60-term1;
            if(map.ContainsKey(term2)){
                res += map[term1] * map[term2];
                map[term1] = 0;
            }
        }

        return res;
    }
}