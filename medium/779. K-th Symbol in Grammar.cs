public class Solution {
    public int KthGrammar(int N, int K) {
        if(N == 1)
            return 0;

        var prev = (K+1)/2.0;
        var prevK = (int)prev;
        var takeLeft = prev == (double)prevK;

        var parent = KthGrammar(N-1, prevK);

        return takeLeft ? parent : (parent+1)%2;
    }
}