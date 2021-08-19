public class MovingAverage {
    LinkedList<int> data;
    int size;
    long sum;

    /** Initialize your data structure here. */
    public MovingAverage(int size) {
        data = new LinkedList<int>();
        this.size = size;
    }
    
    public double Next(int val) {
        if(data.Count >= size){
            var stale = data.First.Value;
            data.RemoveFirst();
            sum -= stale;
        }
        sum += val;
        data.AddLast(val);
        return sum/(double)data.Count;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */