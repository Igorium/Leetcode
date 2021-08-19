public class Solution {
    public IList<string> AddOperators(string num, int target) {
        var res = new List<string>();

        void DFS(string eq, int start, long eval, long mult) {
            if(start >= num.Length){
                if(eval == target)
                    res.Add(eq);
                return;
            }

            var n = 0L;
            var end = num[start] == '0' ? start + 1 : num.Length;
            for(int i = start; i < end; i++){
                n = n*10 + num[i]-'0';
                if(start == 0){
                    DFS(eq + n, i+1, n, n);
                }
                else{
                    DFS(eq + '+' + n, i+1, eval + n, n);
                    DFS(eq + '-' + n, i+1, eval - n, -n);
                    DFS(eq + '*' + n, i+1, eval - mult + mult * n, mult * n);
                }
            }
        }

        DFS("", 0 , 0, 0);
        return res;
    }
}