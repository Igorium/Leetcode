public class Solution {
    public string GetHint(string secret, string guess) {
        var bulls = 0;
        var cows = 0;
        var n = secret.Length;
        
        if(n == 0)
            return $"{bulls}A{cows}B";
        
        var map = new Dictionary<char, int>();
        foreach(var c in secret){
            if(map.ContainsKey(c))
                map[c] += 1;
            else
                map[c] = 1;
        }
        
        for(var i = 0; i < n; i++){
            var c = guess[i];
            if(map.ContainsKey(c)){
                if(secret[i] == c){
                    bulls++;
                    if(map[c] <= 0)
                        cows--;
                } else {
                    if(map[c] > 0)
                        cows++;
                }
                map[c] -= 1;
            }
        }
        
        return $"{bulls}A{cows}B";
    }
}