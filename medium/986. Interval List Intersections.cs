public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
        var idx1 = 0;
        var idx2 = 0;
        var res = new List<int[]>();

        while(idx1 < firstList.Length && idx2 < secondList.Length){
            var start1 = firstList[idx1][0];
            var start2 = secondList[idx2][0];
            var end1 = firstList[idx1][1];
            var end2 = secondList[idx2][1];

            if(start2 >= start1 && start2 <= end1 || start1 >= start2 && start1 <= end2)
                res.Add(new int[]{Math.Max(start1, start2), Math.Min(end1, end2)});

            if(end1 <= end2)
                idx1++;
            if(end2 <= end1)
                idx2++;
        }

        return res.ToArray();
    }
}