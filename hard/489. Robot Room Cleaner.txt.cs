/**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * interface Robot {
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     public bool Move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     public void TurnLeft();
 *     public void TurnRight();
 *
 *     // Clean the current cell.
 *     public void Clean();
 * }
 */

class Solution {
    Robot r;
    HashSet<ValueTuple<int,int>> visited;
    
    public void CleanRoom(Robot robot) {
        r = robot;
        visited = new HashSet<ValueTuple<int,int>>();
      
        BackTrack((0, 0), Direction.Up);
    }
    
    private void BackTrack(ValueTuple<int, int> pos, Direction d){
        visited.Add(pos);
        r.Clean();
        
        for(var i = 0; i < 4; i++){
            var newPos = GetPos(pos, d);
            if(!visited.Contains(newPos) && r.Move()){
                BackTrack(newPos, d);                   
            }
            
            r.TurnRight();
            d = (Direction)(((int)d + 1)%4);
        }
        
        GoBack();            
    }
    
      public void GoBack() {
        r.TurnRight();
        r.TurnRight();
        r.Move();
        r.TurnRight();
        r.TurnRight();
      }
    
    private ValueTuple<int, int> GetPos(ValueTuple<int, int> pos, Direction d){
        (var row, var col) = pos; 
       switch(d){
           case Direction.Up:
               return (row-1, col);
           case Direction.Right:
               return (row, col+1);
           case Direction.Down:
               return (row+1, col);
           case Direction.Left:
               return (row, col-1);
       } 
        
        return pos;
    }
    
    private enum Direction{
        Up,
        Right,
        Down,
        Left
    }
}