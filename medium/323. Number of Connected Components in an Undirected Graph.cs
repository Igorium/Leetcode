public class Solution {
    /*
    o,1 2,0 3,4
    0 1 2 3 4
    1 1 1 3 4 
    */

    public int CountComponents(int n, int[][] edges) {
        var dsu = new DSU(n);
        foreach(var edge in edges){
            dsu.Union(edge[0], edge[1]); // 2 0
        }

        /*
        var res = 0;
        for(int i = 0; i < n; i++){
            if(dsu.nodes[i] == i)
                res++;
        }
        */

        return dsu.n;
    }

    public class DSU{
        public int n;
        public int[] nodes;

        public DSU(int n){
            this.n = n;
            nodes = Enumerable.Range(0, n).ToArray();
        }

        public void Union(int a, int b){
            // 2
            // 1
            var pa = Find(a);
            var pb = Find(b);
            if(pa != pb){
                nodes[pa] = pb;
                n--;
            }
        }

        public int Find(int a){
            if(nodes[a] != a)
                nodes[a] = Find(nodes[a]); // 1

            return nodes[a];
        }
    }
}