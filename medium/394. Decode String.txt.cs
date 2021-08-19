public class Solution {
    public string DecodeString(string s) {
        var ptr = 0;
        var sb = new StringBuilder();
        while(ptr < s.Length){
            var c = s[ptr];
            if(c > '0' && c <= '9')
                sb.Append(Decode(s, ref ptr));
            else
                sb.Append(c);
            ptr++;
        }
        return sb.ToString();
    }
    
    private string Decode(string s, ref int ptr){
        var num = 0;
        while(ptr < s.Length && s[ptr] != '['){
            num *= 10;
            num += (int)(s[ptr]-'0');
            ptr++;
        }
        ptr++;
        
        var sb = new StringBuilder();
        while(ptr < s.Length && s[ptr] != ']'){
            var c = s[ptr];
            if(c > '0' && c <= '9')
                sb.Append(Decode(s, ref ptr));
            else{
                sb.Append(c);
            }
            ptr++;
        }
                
        return string.Concat(Enumerable.Repeat(sb.ToString(), num));
    }
}