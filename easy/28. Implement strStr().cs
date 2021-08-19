public class Solution {
    public int StrStr(string haystack, string needle) {
        if (needle == null || needle == string.Empty)
            return 0;

        var i = 0;
        var n = 0;
        
        while(n < needle.Length && i < haystack.Length){
            if(haystack[i]==needle[n]){
                n++;
                i++;
            }
            else if(n > 0){
                i -= (n-1);
                n = 0;               
            } else{
                i++;
            }          
        }       
        
        return n == needle.Length ? i-n : -1;
    }
}