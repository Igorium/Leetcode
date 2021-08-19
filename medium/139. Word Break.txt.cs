public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        if(wordDict?.Count == 0)
            return false;

        var n = s.Length;
        var set = new HashSet<string>(wordDict);
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

    public bool WordBreak(string s, IList<string> wordDict) {
        if(wordDict?.Count == 0)
            return false;

        var n = s.Length;
        var set = new HashSet<string>(wordDict);
        var memo = new bool?[n];

        bool CheckSubstring(int start){
            if (start >= n)
                return true;

            if(memo[start] != null)
                return memo[start].Value;

            for (int end = start + 1; end <= n; end++) {
                var str = s.Substring(start, end-start);
                if(set.Contains(str) && CheckSubstring(end)){
                    memo[start] = true;
                    return true;
                }
            }

            memo[start] = false;
            return false;
        }

        return CheckSubstring(0);
    }
}