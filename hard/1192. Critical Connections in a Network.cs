public class Solution {
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        var g = new IList<IList<int>>[n];

        foreach(var conn in connections){
            if(g[conn[0]] == null)
                g[conn[0]] = new List<IList<int>>();
            if(g[conn[1]] == null)
                g[conn[1]] = new List<IList<int>>();
            g[conn[0]].Add(conn);
            g[conn[1]].Add(conn);
        }

        var strongConnections = new HashSet<IList<int>>();
        var dfsRanks = new int[n];
        
        // to eliminate 1-1 = 0 on parent check
        DFS(g, strongConnections, dfsRanks, 2, 0);
        
        var res = new List<IList<int>>();
        foreach(var conn in connections)
            if(!strongConnections.Contains(conn))
                res.Add(conn);

        return res;
    }

    int DFS(IList<IList<int>>[] g, HashSet<IList<int>> conns, int[] ranks, int rank, int nodeIdx){
        if(ranks[nodeIdx] > 0)
            return ranks[nodeIdx];

        ranks[nodeIdx] = rank;
        var minDfsRank = rank;
        foreach(var nei in g[nodeIdx]){
            var neiIdx = nei[0] == nodeIdx ? nei[1] : nei[0];

            // parent
            if(ranks[neiIdx] == rank - 1)
                continue;

            var dfsRank = DFS(g, conns, ranks, rank+1, neiIdx);

            if(dfsRank <= rank)
                conns.Add(nei);

            minDfsRank = Math.Min(minDfsRank, dfsRank);
        }

        return minDfsRank;
    }
}