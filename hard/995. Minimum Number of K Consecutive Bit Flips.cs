public class Solution {
    public int MinKBitFlips(int[] A, int K) {
        var q = new Queue<int>();
        var n = A.Length;
        var flips = 0;
        for(int i = 0; i < n; i++){
            if(A[i] == 0){
                if(q.Count%2 == 0){
                    q.Enqueue(i+K-1);
                    flips++;
                }
            } else {
                if(q.Any() && q.Count%2 == 1){
                    q.Enqueue(i+K-1);
                    flips++;
                }
            }
            
            if(q.Any() && q.Peek() <= i)
                q.Dequeue();
        }
        
        return q.Any() ? -1: flips;
    }
}