public class Solution {
    public int MaximalSquare(char[][] matrix) {
        var r = matrix.Length;
        if (r==0)
            return 0;
        var c = matrix[0].Length;


        
        var dp = new int[r+1, c+1];
        
        var maxSquare = 0;
        
        for(int i=1; i<=r; i++){
            for(int j =1; j<=c; j++){
                
                if(matrix[i-1][j-1] == '1'){
                   dp[i,j]=Math.Min(Math.Min(dp[i-1,j],dp[i,j-1]), dp[i-1,j-1])+1;
                
                    if (dp[i,j] > maxSquare)
                        maxSquare = dp[i,j];
                }
                
                
            }
        }
        
        return maxSquare*maxSquare;
    }
}