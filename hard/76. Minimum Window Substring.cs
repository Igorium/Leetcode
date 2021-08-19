// 438, 3
public class Solution {
    public string MinWindow(string s, string p) {
        var res = "";
        if(s.Length == 0 || p.Length > s.Length)
            return res;

        var frq = new Dictionary<char, int>();
        foreach(var c in p)
            frq[c] = frq.ContainsKey(c) ? frq[c] + 1 : 1;

        var count = p.Length;
        var lo = 0;
        var hi = 0;

        while(hi < s.Length){
            var c = s[hi++];

            if(frq.ContainsKey(c)){
                frq[c]--;
                if(frq[c] >= 0)
                    count--; 
            }
            
            while(count == 0 && lo < hi){
                if(res == "" || hi - lo < res.Length)
                    res = s.Substring(lo, hi-lo);

                c = s[lo++];
                if(frq.ContainsKey(c)){
                    frq[c]++;
                    if(frq[c] > 0)
                        count++;
                }
            }
        }
        
        return res;
    }

}