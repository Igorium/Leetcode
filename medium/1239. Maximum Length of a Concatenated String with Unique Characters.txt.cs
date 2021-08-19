public class Solution {
    public int MaxLength(IList<string> arr) {
        var n = arr.Count;
        var dp = new List<(int, int)>();
        dp.Add((0,0));
        var max = 0;

        for(int i = 0; i < n; i++){
            var str = arr[i];
            var mask = 0;
            foreach(var c in str){
                var b = 1 << (c-'a');
                if((b | mask) != (b  ^ mask)){
                    mask = -1;
                    break;
                }
                mask |= b;
            }
            
            if(mask == -1)
                continue;

            for(int j = dp.Count-1; j >= 0; j--){
                var (m,l) = dp[j];
                if((m  & mask) == 0){
                    var len = str.Length + l;
                    dp.Add((m | mask, len));
                    max = Math.Max(max, len);
                }
            }
        }

        return max;
    }
}