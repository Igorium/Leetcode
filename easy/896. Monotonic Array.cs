public class Solution {
    public bool IsMonotonic(int[] A) {
        var isIncreasing = 0;
        for(int i = 1; i < A.Length; i++){
            if(isIncreasing == 0){
                isIncreasing = A[i] - A[i-1];
            } else {
                if(isIncreasing * (A[i] - A[i-1]) < 0) 
                    return false;
            }
        }

        return true;
    }
}