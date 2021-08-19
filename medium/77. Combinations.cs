public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        var res = new List<IList<int>>();
        Combine(1, 0, n, k, res, new int[k]);
        return res;
    }


    public void Combine(int cur, int pos, int n, int k, IList<IList<int>> res, int[] comb) {
        if(pos == k){
            var arr = new int[k];
            Array.Copy(comb, arr, k);
            res.Add(arr);
            return;
        }

        for(int i = cur; i <= n; i++){
            comb[pos] = i;
            Combine(i+1, pos+1, n, k, res, comb); 
        }
    }
}