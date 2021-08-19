public class Solution {
    public int MaximumSwap(int num) {
        var nums = num.ToString().ToCharArray();
        var lastPos = new int[10];

        for(int i = 0; i < nums.Length; i++)
            lastPos[nums[i]-'0'] = i;

        for(int i = 0; i < nums.Length; i++){
            for(var n = 9; n > nums[i]-'0'; n--){
                if(lastPos[n] > i){
                    var t = nums[i];
                    nums[i] = nums[lastPos[n]];
                    nums[lastPos[n]] = t;

                    return int.Parse(new string(nums));
                }
            }
        }

        return num;
    }
}