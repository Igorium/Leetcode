public class Solution {
    
    private int[] prefixSums;
    private int totalSum;
    private Random rand;

    public Solution(int[] w) {
        prefixSums = new int[w.Length];
        for (int i = 0; i < w.Length; ++i) {
            totalSum += w[i];
            prefixSums[i] = totalSum;
        }
        rand = new Random(totalSum);
    }
    
    public int PickIndex() {
        double target = totalSum * rand.NextDouble();
        
        var low = 0;
        var high = prefixSums.Length;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (target > prefixSums[mid])
                low = mid + 1;
            else
                high = mid;
        }
        return low;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */