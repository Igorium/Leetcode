public class RangeModule {
    List<ValueTuple<int,int>> data;
    
    public RangeModule() {
        data = new List<ValueTuple<int,int>>();
        // dirty hack for binary searxh simplification
        data.Add((int.MinValue, int.MinValue));
        data.Add((int.MaxValue, int.MaxValue));
    }
    
    public void AddRange(int left, int right) {
        var next = FindNext(left);
        
        while(next < data.Count){
            (var start, var end) = data[next];
            if(start > right)
                break;
            
            left = Math.Min(left, start);
            right = Math.Max(right, end);
            data.RemoveAt(next);
        }
        data.Insert(next, (left, right));
    }
    
    public bool QueryRange(int left, int right) {
        (var start, var end) = data[FindNext(left)];
        return start <= left && end >= right;
    }
    
    public void RemoveRange(int left, int right) {
        var next = FindNext(left);
        var temp = new List<ValueTuple<int,int>>();
        
        while(next < data.Count){
            (var start, var end) = data[next];
            if(start > right)
                break;
            
            if(start < left)
                temp.Add((start, left));
            if(end > right)
                temp.Add((right, end));
            
            data.RemoveAt(next);
        }
        
        for(var i = temp.Count-1; i >= 0; i--)
            data.Insert(next, temp[i]);
    }
    
    private int FindNext(int left){
        var lo = 0;
        var hi = data.Count-1;
        while(lo < hi){
            var mid = lo + (hi - lo)/2;
            (_, var nextRight) = data[mid];
            if(left == nextRight)
                return mid;
            
            if(left < nextRight)
                hi = mid;
            else
                lo = mid+1;
        }
        
        return hi;
    }
}

/**
 * Your RangeModule object will be instantiated and called as such:
 * RangeModule obj = new RangeModule();
 * obj.AddRange(left,right);
 * bool param_2 = obj.QueryRange(left,right);
 * obj.RemoveRange(left,right);
 */