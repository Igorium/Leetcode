class Solution {
    public int CountSquares(int[][] matrix) {
        var res = 0;
        for(int i = 0; i < matrix.Length; i++)
            for(int j = 0; j < matrix[0].Length; j++)
                if(matrix[i][j] > 0){
                    if(i > 0 && j > 0)
                        matrix[i][j] = Math.Min(Math.Min(matrix[i-1][j], matrix[i][j-1]), matrix[i-1][j-1])+1;
                    res += matrix[i][j];
                }
        
        return res;
    }
}