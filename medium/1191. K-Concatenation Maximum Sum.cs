public class Solution {
    public int KConcatenationMaxSum(int[] arr, int k) {
        var res = 0L;
        var sum = 0L;
        var prev = 0L;
        var delta = 0L;
        var baseSum = 0L;
        
        for(int n = 0; n < 3; n++){
            for(int i = 0; i < arr.Length; i++){
                sum = Math.Max(sum+arr[i], arr[i]);
                res = Math.Max(res, sum);
            }
            
            if(prev >= res)
                return (int)(prev % (Math.Pow(10, 9) + 7));
                    
            if(n==0){
                baseSum = res;
            } else if(n == 1){
                delta = res-prev;
            } else if(n == 2){
                return (int)(((k-1)*delta+baseSum) % (Math.Pow(10, 9) + 7));
            }
            
            prev = res;
        }
        
        return 0;
    }
}