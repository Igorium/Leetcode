public class Solution {
    public int MinDifficulty(int[] jobDifficulty, int d) {
        return jobDifficulty.Length >= d 
            ? DFS(jobDifficulty, 0, d, new int?[jobDifficulty.Length, d])
            : -1;
    }

    public int DFS(int[] jd, int idx, int remaining, int?[,] memo){
        if(memo[idx, remaining-1].HasValue)
            return memo[idx, remaining].Value;

        var max = int.MinValue;
        var res = int.MaxValue;
        for(int i = idx; i < jd.Length - remaining + 1; i++){
            max = Math.Max(max, jd[i]);
            res = remaining == 1 ? max : Math.Min(res, max + DFS(jd, i+1, remaining-1, memo));
        }
        
        memo[idx, remaining-1] = res;
        return res;
    }
}