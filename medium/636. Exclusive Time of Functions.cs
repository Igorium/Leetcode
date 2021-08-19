public class Solution {
    public int[] ExclusiveTime(int n, IList<string> logs) {
        var res = new Dictionary<int, int>();
        var callStack = new Stack<Function>();

        foreach(var entry in logs){
            var f = new Function(entry);
            if(f.Type == "start"){
                callStack.Push(f);
            } else {
                var fStart = callStack.Pop();
                var exclusive = f.Ts - fStart.Ts + 1;
                
                if(!res.ContainsKey(f.Id))
                    res[f.Id] = 0;

                res[f.Id] += exclusive-fStart.Inclusive;
                if(callStack.Any())
                    callStack.Peek().Inclusive += exclusive;
            }
        }

        var ans = new int[res.Count];
        foreach(var kv in res)
            ans[kv.Key] = kv.Value;

        return ans;
    }

    class Function{
        public int Ts;
        public int Id;
        public string Type;
        public int Inclusive;

        public Function(string entry){
            var arr = entry.Split(":");
            Id = int.Parse(arr[0]);
            Type = arr[1];
            Ts = int.Parse(arr[2]);
        }
    }
}