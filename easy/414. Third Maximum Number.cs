public class Solution {
    public int ThirdMax(int[] nums) {
        var dq = new int?[3];
        for(int i = 0; i < nums.Length; i++){
            var n = nums[i];
            if((dq[2] == null || n > dq[2]) && dq[1] != n && dq[0] != n){
                dq[2] = n;
                var j = 2;
                while(j > 0 && (dq[j-1] == null || dq[j] > dq[j-1])){
                    var t = dq[j];
                    dq[j] = dq[j-1];
                    dq[j-1] = t;
                    j--;
                }
            }
        }

        return dq[2] != null ? dq[2].Value : dq[0].Value;
    }
}