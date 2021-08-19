public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var rows = matrix.Length;
        if(rows == 0)
            return false;
        var cols = matrix[0].Length;
        var c = 0;
        var r = rows-1;

        while(r >=0 && c < cols){
            var val = matrix[r][c];
            if(target == val)
                return true;

            if(target > val)
                c++;
            else
                r--;
        }

        return false;
    }
}