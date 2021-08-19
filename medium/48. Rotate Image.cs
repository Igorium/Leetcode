public class Solution {
    public void Rotate(int[][] matrix) {
        if (matrix == null || matrix.Length <= 1)
            return;
        
        var rank = matrix.Length;
        
        for(var i=0; i < rank; i++){
            for(var j=i; j < rank; j++){
                var t = matrix[j][i];
                matrix[j][i] = matrix[i][j];
                matrix[i][j] = t;
            }
        }   
        
        for(var i=0; i < rank; i++){
            for(var j=0; j < rank/2; j++){
                var t = matrix[i][j];
                matrix[i][j] = matrix[i][rank-j-1];
                matrix[i][rank-j-1] = t;
            }
        }
    }
}