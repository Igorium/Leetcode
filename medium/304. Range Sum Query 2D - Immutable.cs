public class NumMatrix {
    private int[,] m;

    public NumMatrix(int[][] matrix) {
        var rows = matrix.Length;
        var cols = matrix[0].Length;

        m = new int[rows, cols];
        for(int i = 0; i < rows; i++)
            for(int j = 0; j < cols; j++)
                m[i,j] = matrix[i][j] + (j == 0 ? 0 : m[i, j-1]);
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        var sum = 0;
        for(int r = row1; r <= row2; r++){
            sum += m[r,col2] - (col1 == 0 ? 0 : m[r,col1-1]);
        }

        return sum;
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */