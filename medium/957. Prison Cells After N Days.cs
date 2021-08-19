public class Solution {
    public int[] PrisonAfterNDays(int[] cells, int N) {
        
        int calcState(int[] a){
            var b = 0;
            for(int i = 0; i < a.Length; i++){
                b <<= 1;
                b |= a[i];
            }
            return b;
        }

        var visited = new Dictionary<int, int>();
        visited[calcState(cells)] = 0;
        var daysCount = 1;

        while(N > 0){
            var curCells = new int[cells.Length];
            for(int i = 1; i < cells.Length-1; i++)
                curCells[i] = cells[i-1] != cells[i+1] ? 0 : 1;

            if(visited != null){
                var curState = calcState(curCells);

                if(visited.ContainsKey(curState)){
                    var cycleLength = daysCount-visited[curState];
                    N %= cycleLength; // magic
                    visited = null;
                } else {
                    visited[curState] = daysCount++;
                }
            }

            if(N > 0)
                cells = curCells;
            N--;
        }

        return cells;
    }
}