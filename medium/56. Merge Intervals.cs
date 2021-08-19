public class Solution {
    public int[][] Merge(int[][] intervals) {
        var n = intervals.Length;
        if(n <= 1)
            return intervals;

        Array.Sort(intervals, new IntervalComparer());
        var res = new List<int[]>();
        var cur = intervals[0];

        for(int i = 1; i < n; i++){
            if(cur[1] >= intervals[i][0]){
                cur[0] = Math.Min(cur[0], intervals[i][0]);
                cur[1] = Math.Max(cur[1], intervals[i][1]);
            } else {
                res.Add(cur);
                cur = intervals[i];
            }
        }
        
        res.Add(cur);
        return res.ToArray();
    }

    public class IntervalComparer : IComparer<int[]>{
        public int Compare(int[] a, int[] b){
            return a[0] - b[0];
        }
    }
}