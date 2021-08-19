public class Solution {
    public string ReorganizeString(string S) {
        var n = S.Length;
        var a = 26;
        var frq = new int[a];
        
        if(n < 2)
            return S;
        
        foreach(var c in S){
            if (frq[c-'a'] == 0)
                frq[c-'a'] = c-'a';
            
            frq[c-'a'] += a;
        }
        
        Array.Sort(frq);
        var ptr = 0;
        var res = new char[n];
        
        for(int i = a-1; i >= 0; i--){
            var count = frq[i]/a;
            var c = frq[i] % a;
            
            if(count > (n+1)/2)
                return "";
            
            while(count-- > 0){
                res[ptr] = (char)(c + 'a');
                ptr = ptr < n-2 ? ptr+2 : 1;
            }
        }
        
        return new String(res.ToArray());
    }
}