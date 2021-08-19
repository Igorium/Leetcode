public class Solution {
    public int ConnectSticks(int[] sticks) {
        var heap = new SortedDictionary<int,int>();
        var count = 0;

        foreach(var stick in sticks){
            add(stick);
        }

        void add(int v){
            count++;
            if(heap.ContainsKey(v))
                heap[v]++;
            else
                heap[v] = 1;
        }

        int remove(){
            count--;
            var v = heap.First().Key;
            heap[v]--;
            if(heap[v] == 0)
                heap.Remove(v);
            return v;
        }

        var res = 0;
        while(count > 1){
            var a = remove();
            var b = remove();
            add(a+b);

            res += a+b;
        }

        return res;
    }
}