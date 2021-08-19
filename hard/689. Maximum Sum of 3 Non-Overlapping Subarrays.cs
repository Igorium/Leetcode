public class Solution {
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k) {
        /*var res = DFS(nums, k, 0, 3, new int[nums.Length, 4][]);
        return res.Skip(1).ToArray();*/

        var sums = new int[nums.Length - k + 1];
        var sum = 0;
        for(int i = 0; i < nums.Length; i++){
            sum += nums[i];
            if(i - k >= 0)
                sum -= nums[i-k];

            // have K in window. start counting
            if(i - k + 1 >= 0)
                sums[i - k + 1] = sum;
        }

        var n = sums.Length;
        var bestSoFar = new int[n,2];

        var best = 0;
        for(int i = 0; i < n; i++){
            if(sums[i] > sums[best])
                best = i;
            bestSoFar[i,0] = best;
        }

        best = n-1;
        for(int i = n-1; i >= 0; i--){
            if(sums[i] >= sums[best])
                best = i;
            bestSoFar[i,1] = best;
        }

        var res = new int[3];
        sum = 0;
        for(int i = k; i < n - k; i++){
            var l = bestSoFar[i-k, 0];
            var r = bestSoFar[i+k, 1];
            var curSum = sums[l] + sums[i] + sums[r];
            if(curSum > sum){
                sum = curSum;
                res[0] = l;
                res[1] = i;
                res[2] = r;
            }
        }

        return res;
    }

    /*public int[] DFS(int[] nums, int k, int start, int left, int[,][] memo){
        if(memo[start, left] != null)
            return memo[start, left];

        var localSum = 0;
        var maxLocalSum = int.MinValue;
        var maxSum = int.MinValue;
        var res = new int[4];
        for(int i = start; i < nums.Length-(k*(left-1)); i++){
            localSum += nums[i];
            if(i - k >= start)
                localSum -= nums[i-k];
            
            // have K in window. start counting
            if(i-(k-1) >= start){
                maxLocalSum = Math.Max(maxLocalSum, localSum);
                var sum = maxLocalSum;
                if(left > 1){
                    var dfs = DFS(nums, k, i+1, left-1, memo);
                    sum += dfs[0];
                    if(sum > maxSum) 
                        res = dfs;
                }

                if(sum > maxSum) {
                    maxSum = sum;
                    res[0] = maxSum;
                    res[4-left] = i-(k-1);
                }
            }
        }

        memo[start, left] = res;
        return res;
    }*/
}