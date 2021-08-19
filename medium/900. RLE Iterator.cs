public class RLEIterator {
    int[] a;
    int reps = 0;
    int ptr = -2;
    
    public RLEIterator(int[] A) {
       a = A; 
    }
    
    public int Next(int n) {
        while(reps < n && ptr + 2 < a.Length){
            n -= reps;
            ptr += 2;
            reps = a[ptr];
        }
        
        if(reps < n){
            reps = 0;
            return -1;
        }
        
        reps -= n;
        return a[ptr+1];
    }
}

/**
 * Your RLEIterator object will be instantiated and called as such:
 * RLEIterator obj = new RLEIterator(A);
 * int param_1 = obj.Next(n);
 */