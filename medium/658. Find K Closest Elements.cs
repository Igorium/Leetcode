public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        var lo = 0;
        var hi = arr.Length-k-1;
        while(lo <= hi){
            var mid = lo + (hi-lo)/2;
            if(x - arr[mid] <= arr[mid + k] - x)
                hi = mid - 1;
            else
                lo = mid + 1;
        }

        var res = new List<int>();
        hi = lo+k;
        while(lo < hi)
            res.Add(arr[lo++]);

        return res;
    }
}

public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        var res = new List<int>();
        if(k <= 0 || arr.Length == 0)
            return res;

        if(x <= arr[0]){
            for(int i = 0; i < k; i++)
                res.Add(arr[i]);

            return res;
        }

        if(x >= arr[arr.Length-1]){
            for(int i = arr.Length-k; i < arr.Length; i++)
                res.Add(arr[i]);

            return res;
        }

        var lo = 0;
        var hi = arr.Length-1;
        while(lo < hi){
            var mid = lo + (hi-lo)/2;
            if(arr[mid] == x){
                hi = mid;
                break;
            }

            if(arr[mid] > x)
                hi = mid;
            else
                lo = mid + 1;
        }

        lo = hi - 1;
        
        for(int i = 0; i < k; i++){
            if(lo < 0){
                hi++;
                continue;
            }
            if(hi >= arr.Length){
                lo--;
                continue;
            }

            var a = arr[lo];
            var b = arr[hi];
            var d = Math.Abs(a - x) - Math.Abs(b - x);
            
            if(d < 0 || d == 0 && a < b)
                lo--;
            else
                hi++;
        }

        lo++;
        hi--;

        while(lo <= hi)
            res.Add(arr[lo++]);

        return res;

    }
}