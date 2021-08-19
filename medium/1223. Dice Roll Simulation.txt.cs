public class Solution {
    public int DieSimulator(int n, int[] rollMax) {
        var memo = new Dictionary<ValueTuple<int,int,int>, int>();
        var m = (int)Math.Pow(10,9)+7;
        int DFS(int roll, int prev, int len){
            if(roll > n)
                return 1;
            
            var key = (roll, prev, len);
            if(memo.ContainsKey(key))
                return memo[key];
            
            var res = 0;
            for(int i = 1; i <=6; i++){
                if(i == prev && rollMax[i-1] == len)
                    continue;
                
                res = (res + DFS(roll+1, i,  i == prev ? len+1 : 1)) % m;
            }
            
            memo[key] = res;
            return res;
        }
        
        return DFS(1, -1, 0);
    }
}