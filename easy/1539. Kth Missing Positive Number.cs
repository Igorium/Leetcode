public class Solution {
    public int FindKthPositive(int[] arr, int k) {
        var lo = 0;
        var hi = arr.Length-1;
        while(lo <= hi){
            var mid = lo+(hi-lo)/2;
            if(arr[mid]-(mid+1) >= k)
                hi = mid-1;
            else
                lo = mid+1;
        }
        return lo + k;
    }
}