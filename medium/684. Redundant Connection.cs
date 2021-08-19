public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        int[] res = null;
        var dsu = new DSU(edges.Length);

        foreach(var edge in edges){
            if(dsu.Union(edge[0], edge[1]))
                res = edge;
        }

        return res;
    }

    class DSU{
        int[] arr;

        public DSU(int n){
            arr = Enumerable<int>.Range(0, n).ToArray();
        }

        public bool Union(int a, int b){
            var parenta = Find(a);
            var parentb = Find(b);

            arr[parenta] = parentb;

            return parenta == parentb;
        }

        public int Find(int a){
            if(arr[a] != a)
                arr[a] = Find(arr[a]); // path compression

            return arr[a];
        }
    }
}