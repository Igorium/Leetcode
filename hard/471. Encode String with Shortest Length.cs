public class Solution {
    public string Encode(string s) {
        return Encode(s, new Dictionary<string, string>());
    }
    
    public string Encode(string s, Dictionary<string, string> memo){
        var n = s.Length;
        if(n <= 4)
            return s;
        if(memo.ContainsKey(s))
            return memo[s];
        
        string res = null;
        for(var i=1; i <= n/2; i++){
            var sub = s.Substring(0, i);
            var repeatCount = CountRepetitions(s, sub);
            
            for(var j = 1; j <= repeatCount; j++){
                var head = j == 1 ? sub : $"{j}[{Encode(sub, memo)}]";
                
                if(res != null && head.Length >= res.Length)
                    break;
                
                var tail = Encode(s.Substring(i*j), memo);
                
                if(res == null || head.Length+tail.Length < res.Length)
                    res = head+tail;
            }
        }
        
        memo[s] = res;
        return res;
    }
    
    private  int CountRepetitions(string s, string sub){
        var res = 1;
        var n = sub.Length;
        for(var i = n; i <= s.Length-n; i += n){
            var j = 0;
            while(j<n && s[i+j] == s[j])
                j++;
            if(j != n)
                break;
            res++;
        }
        return res;
    }
}