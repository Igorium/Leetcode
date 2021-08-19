public class Solution {
    public bool ValidPalindrome(string s) {
        var l = 0;
        var r = s.Length-1;
        
        if(IsPalindrome(s, ref l, ref r))
            return true;
        
        var l2 = l+1;
        var r2 = r-1;
        
        return IsPalindrome(s, ref l, ref r2) || IsPalindrome(s, ref l2, ref r);
    }

    bool IsPalindrome(string s, ref int l, ref int  r){
        while(r >= l){
            if(s[l] != s[r])
                return false;
            l++;
            r--;
        }

        return true;
    }
}