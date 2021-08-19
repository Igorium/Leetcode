public class Solution {
    public string LongestPalindrome(string s) {
        var n = s.Length;
        var length = 1;
        var start = 0;
        for(var i = 1; i <= 2*n-1; i++){
            var idx = i/2.0;
            int lo = (int)idx; 
            int hi = idx == lo ? lo : lo+1;

            while(lo >= 0 && hi < n && s[lo] == s[hi]){
                var len = hi-lo+1;
                if(len > length){
                    start = lo;
                    length = len;
                }
                lo--;
                hi++;
            }
        }

        return s.Substring(start, length);
    }
}