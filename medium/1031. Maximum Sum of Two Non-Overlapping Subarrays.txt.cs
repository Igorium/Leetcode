public class Solution {
    public int MaxSumTwoNoOverlap(int[] A, int L, int M) {
        var n = A.Length;
        var maxSoFar = new int[n,2];
        
        var res = -1;
        
        
        var sumL = 0;
        var maxL = int.MinValue;
        var sumM = 0;
        var maxM = int.MinValue;
        for(int hi = 0; hi <n; hi++){
                        
            sumL += A[hi];
            sumM += A[hi];
            
            if(hi-L >= -1){
                if (hi-L > -1)
                    sumL -= A[hi-L];
                
                maxL = Math.Max(maxL, sumL);
                maxSoFar[hi,0] = maxL;
                
                if (hi-L > -1)
                    res = Math.Max(res, sumL + maxSoFar[hi-L, 1]);
            }
            
            
            if(hi-M >= -1){
                if (hi-M > -1)
                    sumM -= A[hi-M];
                
                maxM = Math.Max(maxM, sumM);
                maxSoFar[hi,1] = maxM;
                
                if (hi-M > -1)
                    res = Math.Max(res, sumM + maxSoFar[hi-M, 0]);
            }
            
            //Console.WriteLine(maxL + " " + maxM);
        }
        
        return res;
    }
}