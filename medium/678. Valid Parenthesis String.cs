public class Solution {
    public bool CheckValidString(string s) {
        int balance = 0;
        
        foreach(var c in s){
            if (c == ')')
                balance--;
            else
                balance++;
            
            if (balance < 0 )
                return false;
        }
        
        if (balance == 0)
            return true;
        
        balance =0;
        
        for(var i = s.Length -1; i >=0; i--){
            if (s[i] == '(')
                balance--;
            else
                balance++;
            
            if (balance < 0)
                return false;
        }
        
        return true;
    }
}