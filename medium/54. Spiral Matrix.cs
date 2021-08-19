public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        var res = new List<int>();

        var rows = matrix.Length-1;
        if(rows == -1)
            return res;

        var cols = matrix[0].Length-1;
        var frow = 0;
        var fcol = 0;

        while(fcol<=cols && frow<=rows){
            for(int i = fcol; i <= cols; i++)
                res.Add(matrix[frow][i]);
            frow++;

            for(int i = frow; i <= rows; i++)
                res.Add(matrix[i][cols]);
            cols--;
            

            if(frow<=rows){
                for(int i = cols; i >= fcol; i--)
                    res.Add(matrix[rows][i]);
                rows--;
            }

            if(fcol<=cols){
                for(int i = rows; i >= frow; i--)
                    res.Add(matrix[i][fcol]);
                fcol++;
            }
        }
        return res;
    }
}