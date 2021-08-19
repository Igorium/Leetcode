public class Solution {
    public int MinSumOfLengths(int[] arr, int target) {
        var n = arr.Length;
        // Optimization: it is not required to populate this array
        var best = new int[n];
        var bestSoFar = int.MaxValue;
        var sum = 0;
        var start = 0;
        var res = int.MaxValue;
    
        for(var i = 0; i < n; i++){
            sum += arr[i];
            
            while(sum > target && start < n){
                sum -= arr[start++];
            }
            
            if(sum == target){
                var currLen = i-start+1;
                bestSoFar = Math.Min(bestSoFar, currLen);
                
                if(start > 0 && best[start-1] != int.MaxValue)
                    res = Math.Min(res, best[start-1] + currLen);
                
                // Optimization: minimum possible length is 2
                if(res == 2)
                    return res;
            }
            
            best[i] = bestSoFar;
        }
        
        return res == int.MaxValue ? -1 : res;
    }
}