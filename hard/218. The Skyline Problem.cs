public class Solution {
    public IList<IList<int>> GetSkyline(int[][] buildings) {
        var n = buildings.Length;
        var res = new List<IList<int>>();
        var points = new int[n*2][];

        var idx = 0;
        foreach(var b in buildings){
            points[idx++] = new int[]{b[0], -b[2]}; // x, h
            points[idx++] = new int[]{b[1], b[2]}; // x, h
        }
        
        // sort by x if xa != xb
        // greater hight goes first at start
        // lesser hight goes frist at end
        // start goes before end
        Array.Sort(points, Comparer<int[]>.Create((a,b) => a[0] != b[0] ? a[0] - b[0] : a[1] - b[1]));
        var map = new SortedDictionary<int, int>(Comparer<int>.Create((a,b) => b - a)); // sort by hight
        map[0] = 0;

        foreach(var p in points){
            var h = p[1];
            var maxHight = map.First().Key;

            if(h < 0){ // start
                h = -h; // !!!
                map[h] = map.ContainsKey(h) ? map[h]+1 : 1;
            } else { // end
                map[h]--;
                if(map[h] == 0)
                    map.Remove(h);
            }

            var newMax = map.First().Key;
            if(maxHight != newMax)
                res.Add(new List<int>{p[0], newMax});
        }

        return res;
    }

}