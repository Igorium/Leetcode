public class Solution {
    public int MinCost(int[][] grid) {
        var rows = grid.Length;
        var cols = grid[0].Length;
        
        if(rows == 0 && cols == 0)
            return 0;
        
        var dirs = new (int,int)[]{(0,1),(0,-1),(1,0),(-1,0)};
        
        var map = new SortedDictionary<int, Queue<(int, int)>>();
        var dist = new int?[rows, cols];
        map.Add(0, new Queue<(int, int)>());
        map[0].Enqueue((0,0));
        dist[0,0] = 0;
        
        while(map.Any()){
            var node = map.First();
            var cost = node.Key;
            var (row, col) = node.Value.Dequeue();
            
            if(!node.Value.Any())
                map.Remove(cost);
            
            for(int i = 0; i < 4; i++){
                var (rd,cd) = dirs[i];
                var r = row+rd;
                var c = col+cd;
                var newCost = cost + (i == grid[row][col]-1 ? 0 : 1);
                
                if(r >= 0 && r < rows && c >= 0 && c < cols && (dist[r,c] == null || dist[r,c] > newCost)){
                    dist[r,c] = newCost;
                    if(!map.ContainsKey(newCost))
                        map.Add(newCost, new Queue<(int, int)>());
                    map[newCost].Enqueue((r,c));
                }
            }
        }

        return dist[rows-1, cols-1].Value;
    }
} 