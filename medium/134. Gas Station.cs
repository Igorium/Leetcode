public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        var n = gas.Length;
        
        var total = 0;
        var curr = 0;
        var station = 0;
        
        for(int i = 0; i < n; i++){
            var balance = gas[i] - cost[i];
            total += balance;
            curr += balance;
            
            if(curr < 0){
                curr = 0;
                station = i+1;
            }
        }
        
        return total < 0 ? -1 : station;
    }
}