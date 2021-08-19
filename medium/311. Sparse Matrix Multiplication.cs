public class Solution {
    public int[][] Multiply(int[][] A, int[][] B) {
        var rows = A.Length;
        var cols = A[0].Length;
        var colsB = B[0].Length;
        var res = new int[rows][];

        // keep values of B != 0
        // below it woulb the subject of the repetitive iterations
        var helper = new List<(int, int)>[B.Length];
        for(int r = 0; r < B.Length; r++){
            helper[r] = new List<(int, int)>();
            for(int c = 0; c < colsB; c++){
                if(B[r][c] != 0)
                    helper[r].Add((c, B[r][c])); 
            }
        }

        
        for(int r = 0; r < rows; r++){
            res[r] = new int[colsB];
            for(int c = 0; c < cols; c++){
                var a = A[r][c];
                if(a != 0)
                    foreach(var (idx, val) in helper[c])
                        res[r][idx] += a * val; 
            }
        }

        return res;
    }
}