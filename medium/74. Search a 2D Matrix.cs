public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var rows = matrix.Length;
        if(rows == 0)
            return false;
        var cols = matrix[0].Length;
        var n = rows * cols;

        var lo = 0;
        var hi = n-1;
        while(lo <= hi){
            var mid = lo + (hi-lo)/2;
            var val = matrix[mid/cols][mid%cols];
            if(target == val)
                return true;
            
            if(val > target)
                hi = mid-1;
            else
                lo = mid+1;
        }

        return false;
    }
}