public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        var n = intervals.Length;
        var res = new List<int[]>();
        var ptr = 0;
        
        while (ptr < n && intervals[ptr][1] < newInterval[0]){
            res.Add(intervals[ptr++]);
        }
        
        var i = new int[]{newInterval[0], newInterval[1]};
        res.Add(i);
        
        while (ptr < n){
            var next = intervals[ptr++];
            if (i[1] >= next[0]){
                i[0] = Math.Min(i[0], next[0]);
                i[1] = Math.Max(i[1], next[1]);
            } else {
                res.Add(next);
            }
        }
        
        return res.ToArray();
    }
}