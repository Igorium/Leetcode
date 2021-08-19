public class Solution {
    public int FindMaxForm(string[] strs, int m, int n) {
        var len = strs.Length;
        var memo = new int?[len, m, n];
        var res = int.MinValue;

        int DFS(int pos, int mCurr, int nCurr){
            if(pos >= len)
                return 0;

            if(memo[pos, mCurr, nCurr] != null)
                return memo[pos].Value;

            var str = strs[pos];

            var mt = 0;
            var nt = 0;

            foreach(var c in str){
                if(c == '0')
                    mt++;
                else
                    nt++;
            }

            count = DFS(pos+1, mCurr, nCurr);

            if(mCurr+mt <= m && nCurr+nt <=n){
                count = Math.Max(count, DFS(pos+1, mCurr+mt, nCurr+nt)+1);
            }

            memo[pos, mCurr, nCurr] = count;
            return count;
        }

        DFS(0, 0, 0);
        return memo[0, 0, 0];
    }
}