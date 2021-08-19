public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        if(s == null || s.Length <= 2)
            return s?.Length ?? 0;
        
        var lo = 0;
        var hi = 0;
        var max = 0;
        
        var map = new Dictionary<char, int>();
        
        while(hi < s.Length){
            var c = s[hi++];
            
            if(map.Count < 2 || map.ContainsKey(c)){
                if(hi-lo > max)
                    max = hi - lo;              
            } else{
                var prevVal = Math.Min(map.First().Value, map.Last().Value);
                lo = prevVal;
                map.Remove(s[prevVal-1]);                
            }
            
            map[c] = hi;

        }
        
        return max;
    }
}