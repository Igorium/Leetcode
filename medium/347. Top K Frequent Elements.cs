public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var frq = new Dictionary<int, int>();
        foreach(var n in nums)
            if(frq.ContainsKey(n))
                frq[n]++;
            else
                frq[n] = 1;

        var arr = frq.Select(kv => new []{kv.Key, kv.Value}).ToArray();

        void swap(int a, int b){
            if(a == b)
                return;
            var t = arr[a];
            arr[a] = arr[b];
            arr[b] = t;
        }

        int partition(int lo, int hi){
            var pivot = arr[hi];

            for(int i = lo; i < hi; i++)
                if(arr[i][1] < pivot[1])
                    swap(i, lo++);

            swap(hi, lo);
            return lo;
        }

        var lo = 0;
        var hi = arr.Length - 1;
        while(hi >= lo){
            var mid = partition(lo, hi);
            if(mid == k)
                break;
            if(mid > k)
                hi = mid-1;
            else
                lo = mid+1;
        }

        var res = new int[k];
        for(int i = 0; i < k; i++)
            res[i] = arr[i][0];
        
        return res;
    }
}