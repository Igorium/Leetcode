public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var n = s.Length;
        var map = new int[128];
        int l = 0, r = 0, res = 0;
        
        while(r < n){
            var c = s[r];
            l = Math.Max(map[c], l);            
            res = Math.Max(res, r-l+1);
            map[c] = ++r;
        }
        
        return res;
    }
}