public class MyCalendar {
    List<ValueTuple<int,int>> data;

    public MyCalendar() {
        data = new List<ValueTuple<int,int>>();
        // dirty hack for binary searxh simplification
        //data.Add((int.MinValue, int.MinValue));
       // data.Add((int.MaxValue, int.MaxValue));
    }
    
    public bool Book(int start, int end) {
        if(!data.Any()){
            data.Add((start, end)); 
            return true;
        }
        
        if(data.Count == 1){
            (var iStart, var iEnd) = data[0];
            //Console.WriteLine(iStart +" "+ end  +" "+start +" "+ iEnd);
            
            if(iStart > end || start < iEnd)
                return false;
            data.Insert(start < iStart ? 0 : 1, (start, end)); 
            return true;
        }
        
        var lo = 0;
        var hi = data.Count;
        while(lo < hi){
            var mid = lo + (hi - lo)/2;
            (var next, _) = data[mid];
            if(start == next)
                return false;
            
            if(start < next)
                hi = mid;
            else
                lo = mid+1;
        }
        
        if (lo >= data.Count-1)
            return data[data.Count-1].Item2 <= start;
        
        if (lo == 0)
            return end <= data[lo].Item1;
        
        (var nextStart, _) = data[lo+1];
        (_, var prevEnd) = data[lo];
        if(nextStart < end || start < prevEnd)
            return false;
        
        data.Insert(lo, (start, end)); 
        return true;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */