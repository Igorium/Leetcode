public class Solution {
    public bool IsValidSudoku(char[][] board) {
        bool isValid(char c, int[] vals){
            if(c == '.')
                return true;
            if(c < '1' || c > '9')
                return false;
            var idx = c - '1';
            if(vals[idx] == 1)
                return false;
            vals[idx] = 1;
            return true;
        }

        for(int i = 0; i < 9; i++){
            var col = new int[9];
            var row = new int[9];
            for(int j = 0; j < 9; j++){
                if (!isValid(board[i][j], row) || !isValid(board[j][i], col))
                    return false;
            }
        }

        for(var k = 0; k < 9*3; k+=3){
            var col = k % 9;
            var row = (k / 9)*3;
            var vals = new int[9];
            
            for(int i = 0; i < 3; i++){
                for(int j = 0; j < 3; j++){
                    if (!isValid(board[i + row][j + col], vals))
                        return false;
                }
            }
        }

        return true;
    }
}