public class Solution {
    public bool IsNStraightHand(int[] hand, int W) {
        var n = hand.Length;
        if(n % W != 0)
            return false;
        
        var heap = new SortedDictionary<int, int>();
        for(int i = 0; i < n; i++){
            if(heap.ContainsKey(hand[i]))
                heap[hand[i]] += 1;
            else
                heap[hand[i]] = 1;
        }
        
        for(int i = 0; i < n / W; i++){
            var min = heap.First().Key;
            
            for(int j = 0; j < W; j++){
                if(!heap.ContainsKey(min+j))
                    return false;
                
                if(heap[min+j] > 1)
                    heap[min+j] -= 1;
                else
                    heap.Remove(min+j);
            }
        }
        
        return true;
    }
}