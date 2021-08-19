public class Solution {
    public int SumSubarrayMins(int[] A) {
        int MOD = 1000000007;
        var res = 0;
        var mins = new Stack<ValueTuple<int, int>>();
        var sum = 0;
        
        for(int i=0; i < A.Length; i++){
            var v = A[i];
            var count = 1;
            
            while(mins.Count > 0)
            {
                (var vPrev, var countPrev) = mins.Peek();
                
                if(vPrev<v)
                    break;
                
                count += countPrev;
                mins.Pop();
                sum -= (vPrev*countPrev);
            }
            
            mins.Push((v, count));
            sum += v*count;

            res += sum;
            res %= MOD;
        }
        
        return res;
    }
}