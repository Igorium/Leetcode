public class Solution {
    public string ModifyString(string s) {
        var sb = s.ToCharArray();
        var a = (int)'a';
        
        for(int i = 0; i < sb.Length; i++){
            if(sb[i] == '?'){
                var c = a;
                while(i > 0 && c == sb[i-1] || i < sb.Length-1 && c == sb[i+1])
                    c++;
                
                sb[i] = (char)c;
            }
        }

        return new string(sb);
    }
}