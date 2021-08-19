public class Solution {
    public int MyAtoi(string str) {
        str = str.Trim();
        
        if (str.Length == 0)
            return 0;
        
        var i = 0;
        var sign = 1;
        int res = 0;
        int prev = 0;
        
        if (str[0] == '-'){
            i++;
            sign = -1;
        }
        if (str[0] == '+'){
            i++;
        }
        
        for(; i < str.Length; i++){
            if (char.IsDigit(str[i])){
                res *= 10;
                res += (str[i]-'0');
                
                if (sign == 1 && res < 0)
                    return int.MaxValue;

                if (sign == -1 && res < 0)
                    return int.MinValue;        
            } else{
                break;
            }
        }  
        
        
        return (int)res*sign;      
       
    }
}