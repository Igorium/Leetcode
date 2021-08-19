public class TicTacToe {
    int[] rows;
    int[] cols;
    int d1;
    int d2;
    int n;
    /** Initialize your data structure here. */
    public TicTacToe(int n) {
        rows = new int[n];
        cols = new int[n];
        this.n = n;
    }
    
    /** Player {player} makes a move at ({row}, {col}).
        @param row The row of the board.
        @param col The column of the board.
        @param player The player, can be either 1 or 2.
        @return The current winning condition, can be either:
                0: No one wins.
                1: Player 1 wins.
                2: Player 2 wins. */
    public int Move(int row, int col, int player) {
        var p = player == 1 ? 1 : -1;
        rows[row] += p;
        cols[col] += p;

        if(row == col)
            d1 += p;
        if(row + col == n-1)
            d2 += p;

        return (Math.Abs(rows[row]) == n || Math.Abs(cols[col]) == n || Math.Abs(d1) == n || Math.Abs(d2) == n) ? player : 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */