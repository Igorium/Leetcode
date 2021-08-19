public class Solution {
    public bool IsPalindrome(string s) {

        
        
        var l = 0;
        var r = s.Length-1;
        while (r >= l){            
            if(!char.IsLetterOrDigit(s[l])){
                l++;
            } else if(!char.IsLetterOrDigit(s[r])){
                r--;
            } else if(char.ToLower(s[l++]) != char.ToLower(s[r--]))
                return false;
        }
        
        return true;
    }
}