public class Solution {
    public bool IsIsomorphic(string s, string t) {
        var map = new Dictionary<char,char>();
        var taken = new Dictionary<char,char>();
        var n = s.Length;
        
        for(int i = 0; i < n; i++){
            var from = s[i];
            var to = t[i];
            
            if(map.ContainsKey(from) && to != map[from])
                return false;
            if(taken.ContainsKey(to) && from != taken[to])
                return false;
            
            map[from] = to;
            taken[to] = from;
        }
        
        return true;
    }
}