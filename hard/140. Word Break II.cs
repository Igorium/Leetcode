public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
        var words = new HashSet<string>();
        var maxLen = 0;
        var minLen = int.MaxValue;
        var memo = new List<string>[s.Length];

        foreach(var w in wordDict){
            maxLen = Math.Max(maxLen, w.Length);
            minLen = Math.Min(minLen, w.Length);
            words.Add(w);
        }

        List<string> DFS(int idx){
            if(memo[idx] != null)
                return memo[idx];

            var res = new List<string>();
            
            var sb = new StringBuilder();
            for(int i = idx; i < s.Length && i-idx+1 <= maxLen; i++){
                sb.Append(s[i]);
                if(i-idx+1 < minLen)
                    continue;

                var word = sb.ToString();
                if(words.Contains(word)){
                    if(i == s.Length-1){
                        res.Add(word);
                    } else {
                        foreach(var str in DFS(i+1))
                            res.Add(word + " " + str);
                    }
                }
            }

            memo[idx] = res;
            return res;
        }
        
        return DFS(0);
    }
}