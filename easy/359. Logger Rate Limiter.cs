public class Logger {
    private const int n = 10;
    private ValueTuple<int, HashSet<string>>[] hist = new ValueTuple<int, HashSet<string>>[n];

    /** Initialize your data structure here. */
    public Logger() {
        for(int i = 0; i < n; i++)
          hist[i] = (i, new HashSet<string>());
    }
    
    /** Returns true if the message should be printed in the given timestamp, otherwise returns false.
        If this method returns false, the message will not be printed.
        The timestamp is in seconds granularity. */
    public bool ShouldPrintMessage(int timestamp, string message) {
        for(var i = 0; i < n; i++){
            (var hts, var hset) = hist[i];
            if(timestamp - hts < n && hset.Contains(message))
                return false;
        }
        
        (var ts, var set) = hist[timestamp % n];
        if(ts != timestamp)
            hist[timestamp % n] = (timestamp, set = new HashSet<string>());
        set.Add(message);
        
        return true;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */