public class Solution {
    public int TotalFruit(int[] tree) {
        
        var lo = 0;
        var hi = 0;
        var max = int.MinValue;
        
        var map = new Dictionary<int, int>();
        
        while(hi<tree.Length){
            
            map[tree[hi]] = hi;           
            
            if(map.Count == 3){
                var minIdx = map.Min(kv => kv.Value);
                map.Remove(map.First(kv => kv.Value == minIdx).Key);
                
                lo = minIdx + 1;
            } else if(hi-lo+1 > max){
                max = hi - lo+1;
            }
            
            hi++;
        }
        
        return max;
    }
}