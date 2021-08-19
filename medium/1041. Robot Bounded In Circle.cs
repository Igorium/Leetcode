public class Solution {
    public bool IsRobotBounded(string instructions) {
        var x = 0;
        var y = 0;
        var d = 0;
        var dirs = new []{(0, 1),(1,0),(0,-1),(-1,0)};

        foreach(var c in instructions){
            switch(c){
                case 'R':
                    d = (d+1) % 4; 
                break;
                case 'L':
                    d = (d+3) % 4;
                break;
                case 'G':
                    var (xd, yd) = dirs[d];
                    x += xd;
                    y += yd;
                break;
            }
        }

        return (x == 0 && y == 0) || d != 0;
    }
}