public class Solution {
    public int LongestLine(int[][] M) {
        var rows = M.Length;
        if(rows == 0)
            return 0;
        var cols = M[0].Length;
        var max = 0;
        var dp = new int[cols, 3];
        
        for(var r = 0; r < rows; r++){
            var row = 0;
            var prevDiag = 0; 
            for(var c = 0; c < cols; c++){
                var col = 0;
                var diag = 0;
                var adiag = 0;
                    
                if(M[r][c] == 1){
                    row++;
                    col = dp[c,0] + 1;
                    diag = c != 0 ? prevDiag + 1 : 1;
                    adiag = c < cols-1 ? dp[c+1,2] + 1 : 1;
                    max = Math.Max(max , Math.Max(row, Math.Max(col, Math.Max(diag, adiag))));
                } else {
                    row = 0;
                }
                
                dp[c, 0] = col;
                // !!! prevent override
                prevDiag = dp[c, 1];
                dp[c, 1] = diag;
                dp[c, 2] = adiag;
            }
        }
        
        return max;
    }
}