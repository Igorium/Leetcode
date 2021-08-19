public class Solution {

    /*

    1 2  2
    0 -1 1
    1 1  0
    */
    public void WallsAndGates(int[][] rooms) {
        var rows = rooms.Length;
        var cols = rooms[0].Length;
        var q = new Queue<(int,int)>();
        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                if(rooms[r][c] == 0)
                    q.Enqueue((r,c)); // (0, 1) (2,2)
            }
        }

        var distance = 1;
        var directions = new (int, int)[]{(-1,0),(1,0),(0,1),(0,-1)};
        while(q.Any()){
            for(int i = q.Count; i > 0; i--){
                var (row, col) = q.Dequeue();
                foreach(var (deltaRow, deltaCol) in directions){
                    var r = row+deltaRow;
                    var c = col+deltaCol;
                    if(r >= 0 && r < rows && c >= 0 && c < cols && rooms[r][c] == int.MaxValue){
                        rooms[r][c] = distance;
                        q.Enqueue((r,c));
                    }
                }
            }
            distance++;
        }
    }
}