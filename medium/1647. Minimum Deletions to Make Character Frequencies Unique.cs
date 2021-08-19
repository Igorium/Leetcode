public class Solution {
    public int MinDeletions(string s) {
        var frq = new int[26];
        foreach(var c in s)
            frq[c-'a']++;

        Array.Sort(frq);
        var res = 0;
        for(int i = frq.Length-2; i >= 0 && frq[i] > 0; i--){
            var d = frq[i] - frq[i+1];
            
            if(d >= 0){
                d = frq[i] == d ? d : d+1;
                
                frq[i] -= d;
                res += d;
            }
        }
        
        return res;
    }
}