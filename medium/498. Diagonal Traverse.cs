public class Solution {
    public int[] FindDiagonalOrder(int[][] matrix) {
        var rows = matrix.Length;
        if(rows == 0)
            return new int[0];
        var cols = matrix[0].Length;
        var res = new int[rows*cols];

        var r = 0;
        var c = 0;
        var idx = 0;
        var up = true;

        while(r < rows && c < cols){
            while(r < rows && r >= 0 && c < cols && c >= 0){
                res[idx++] = matrix[r][c];
                if(up){
                    if(r == 0 || c == cols-1)
                        break;
                    r--;
                    c++;
                } else {
                    if(c == 0 || r == rows-1)
                        break;
                    r++;
                    c--;
                }
            }
            
            if(up){
                if(c < cols-1)
                    c = c+1;
                else
                    r = r+1;
            } else {
                if(r < rows-1)
                    r = r+1;
                else
                    c = c+1;
            }
            
            up = !up;
        }

        return res;
    }
}