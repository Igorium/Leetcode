public class Solution {
    public bool Exist(char[][] board, string word) {
        if(word == null || word == "")
            return false;

        var rows = board.Length;
        var cols = board[0].Length;
        var delta = new []{(0,1),(1,0),(0,-1),(-1,0)};

        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                if(DFS(r, c, 0, new HashSet<(int, int)>()))
                    return true;
            }
        }

        bool DFS(int row, int col, int pos, HashSet<(int, int)> visited){
            if(pos >= word.Length)
                return true;

            if(row < 0 || row >= rows || col < 0 || col >= cols || board[row][col] != word[pos] || visited.Contains((row, col)))
                return false;

            visited.Add((row, col));
            var found = false;

            foreach(var (rd, cd) in delta){
                if(found = DFS(row + rd, col + cd, pos+1, visited))
                    break;
            }

            visited.Remove((row, col));

            return found;
        }

        return false;
    }
}