// quick select
public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var n = points.Length;
        if(n == k)
            return points;

        var res = new int[k][];

        int distance(int[] p) => p[0]*p[0] + p[1]*p[1];

        void swap(int a, int b){
            if(a == b) return;
            var t = points[a];
            points[a] = points[b];
            points[b] = t;
        }

        int partition(int lo, int hi){
            var pivot = distance(points[hi]);

            for(int i = lo; i < hi; i++){
                if(distance(points[i]) < pivot)
                    swap(lo++, i);
            }

            swap(lo, hi);
            return lo;
        }
        
        var lo = 0;
        var hi = n-1;
        var mid = -1;
        while(lo < hi && mid != k){
            mid = partition(lo, hi);
            if(mid > k)
                hi = mid-1;
            else
                lo = mid+1;
        }

        Array.Copy(points, res, k);

        return res;
    }
}