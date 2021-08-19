public class Solution {
    public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps) {
        var n = source.Length;
        var dsu = new DSU(n);

        foreach(var sw in allowedSwaps)
            dsu.Union(sw[0], sw[1]);

        var map = new Dictionary<int, List<int>>();

        for(int i = 0; i < n; i++){
            var p = dsu.Find(i);
            if(!map.ContainsKey(p))
                map[p] = new List<int>();

            map[p].Add(i);
        }
        
        var res = 0;

        foreach(var indexes in map.Values){
            var targetMap = new Dictionary<int, int>();

            foreach(var idx in indexes){
                var val = target[idx];
                if(!targetMap.ContainsKey(val))
                    targetMap[val] = 1;
                else   
                    targetMap[val]++;
            }

            foreach(var idx in indexes){
                var val = source[idx];
                if(targetMap.ContainsKey(val)){
                    targetMap[val]--;
                    if(targetMap[val] < 0)
                        res++;
                }
                else{
                    res++;
                }
            }
        }

        return res;
    }

    private class DSU{
        private int[] arr;

        public DSU(int n){
            arr = Enumerable.Range(0, n).ToArray();
        }

        public void Union(int a, int b){
            var pa = Find(a);
            var pb = Find(b);
            arr[pa] = pb;
        }

        public int Find(int a){
            if(arr[a] == a)
                return a;

            return Find(arr[a]);
        }
    }
}