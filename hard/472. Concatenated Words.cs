public class Solution {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        var res = new List<string>();

        if(words.Length < 2)
            return res;

        var sorted = words.Where(w => w != null && w.Length > 0).OrderBy(w => w.Length).ToArray();
        var minLen = sorted[0].Length;
        var wordsSet = new HashSet<string>();
        var maxLen = 0;
        foreach(var word in sorted){
            //if(word.Length >= minLen*2 && WordBreak(word, wordsSet, minLen, maxLen))
            if(word.Length >= minLen*2 && WordBreak(word, wordsSet))
                res.Add(word);
            
            wordsSet.Add(word);
            maxLen = Math.Max(maxLen, word.Length);
        }

        return res;
    }

    public bool WordBreak(string s, HashSet<string> set) {
        var n = s.Length;
        var memo = new bool[n+1];
        memo[0] = true;

        for(int i = 1; i<= n; i++){
            for(int j = i-1; j >=0; j--){
                if(memo[j] && set.Contains(s.Substring(j, i-j))){
                    memo[i] = true;
                    break;
                }
            }
        }

        return memo[n];
    }

    public bool WordBreak(string s, HashSet<string> words, int minLen, int maxLen) {
        var memo = new List<bool?>[s.Length];

        bool DFS(int idx){
            if(memo[idx] != null)
                return memo[idx];

            var res = false;
            var sb = new StringBuilder();
            for(int i = idx; i < s.Length && i-idx+1 <= maxLen; i++){
                sb.Append(s[i]);
                if(i-idx+1 < minLen)
                    continue;

                var word = sb.ToString();
                if(words.Contains(word) && (i == s.Length-1 || DFS(i+1))){
                    res = true;
                    break;
                }
            }

            memo[idx] = res;
            return res;
        }
        
        return DFS(0);
    }
}