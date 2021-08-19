public class Solution {
    public int MinCost(string s, int[] cost) {
        var n = cost.Length;
        var sum = cost[0];
        var max = cost[0];

        for(int i = 1; i < n; i++){
            if(s[i] != s[i-1]){ // when repetitive seq is ended remove max from sum
                sum -= max;
                max = 0;
            }
            // calc sum and max for repeating
            sum += cost[i];
            max = Math.Max(max, cost[i]);
        }

        return sum-max;
    }
}