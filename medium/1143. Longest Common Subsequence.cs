public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        if (text1.Length > text2.Length){
            return LongestCommonSubsequence(text2, text1);
        }
        
        var l1 = text1.Length;
        var l2 = text2.Length;
        var memo = new int[l2+1,l1+1];
        
        for(int i = 1; i <= l2; i++){
            for(int j = 1; j <= l1; j++){
                if (text2[i-1]==text1[j-1]){
                    memo[i,j] = memo[i-1,j-1]+1;
                } else{
                    memo[i,j] = Math.Max(memo[i-1,j], memo[i,j-1]);
                }
            }
        }
        
        return memo[l2, l1];
    }
}