// 76, 3
public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        var res = new List<int>();
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
            
            if(count == 0)
                res.Add(lo);

            if(hi-lo == p.Length){
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