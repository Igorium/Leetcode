public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var q = new Heap(k+1);
        
        foreach(var n in nums){
            q.Add(n);
            if(q.len > k)
                q.Pool();
        }
        
        return q.Peek();
    }
}

public class Heap{
    public int len;
    int[] arr;
    
    public Heap(int cap){
        arr = new int[cap];
    }
    
    public int Peek(){
        return arr[0];
    }
    
    public void Pool(){
        arr[0] = arr[len-1];
        len--;
        HeapifyDown();
    }
    
    public void Add(int val){
        arr[len] = val;
        len++;
        HeapifyUp();
    }
    
    int left(int idx) {return idx*2+1;}
    int right(int idx) {return idx*2+2;}
    int parent(int idx) {return (idx-1)/2;}
    
    private void HeapifyDown(){
        var idx = 0;
        
        while(left(idx) < len){
            var childIdx = left(idx);
            if(right(idx) < len && arr[right(idx)] < arr[childIdx])
                childIdx = right(idx);
            
            if(arr[childIdx] > arr[idx])
                break;
            
            swap(idx, childIdx);
            idx = childIdx;
        }
    }    
    
    private void HeapifyUp(){
        var idx = len - 1;
        
        while(idx > 0){
            if(arr[parent(idx)] < arr[idx])
                break;
                
            swap(idx, parent(idx));
            idx = parent(idx);
        } 
    }
    
    void swap(int a, int b){
        var temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
}





