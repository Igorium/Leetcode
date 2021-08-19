public class Solution {
    public int NumDecodings(string s) { 
        return DFS(s, 0, new int?[s.Length]);
    }

    public int DFS(string s, int start, int?[] memo){
        if(start > s.Length-1)
            return 1;

        if(memo[start] != null)
            return memo[start].Value;

        var res = 0;
        var num = s[start] - '0';
        if(num > 0){
            res += DFS(s, start+1, memo); 
            if(start+1 < s.Length){
                num = num * 10 + s[start+1] - '0';
                if(num <= 26)
                    res += DFS(s, start+2, memo);
            }
        }
            
        memo[start] = res;
        return res;
    }
}