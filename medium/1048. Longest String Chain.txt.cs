public class Solution {
    public int LongestStrChain(string[] words) {
        var a = new Dictionary<string, int>();
        var len = new HashSet<int>();
        var max = 1;
        
        foreach(var w in words.OrderBy(wd => wd.Length)){
            if(a.ContainsKey(w))
                continue;
            
            var n = w.Length;
            len.Add(n);
            
            if(n==1 || !len.Contains(n-1)){
                a[w] = 1;
                continue;
            }

            var sb = new StringBuilder(w);
            for(int i = 0; i < n; i++){
                var t = sb[i];
                sb.Remove(i,1);
                var p = sb.ToString();
                sb.Insert(i, t);

                if(a.ContainsKey(p)){
                    a[w] = a[p] + 1;
                    max = Math.Max(max, a[w]);
                    break;
                }
            }
            
            if(!a.ContainsKey(w))
                a[w] = 1;

        }
        
        return max;
    }
}