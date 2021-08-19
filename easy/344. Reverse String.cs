public class Solution {
    public void ReverseString(char[] s) {
        var l = 0;
        var r = s.Length-1;
        
        while(r>l){
            var t = s[l];
            s[l] = s[r];
            s[r] = t;
            l++;
            r--;
        }
    }
}