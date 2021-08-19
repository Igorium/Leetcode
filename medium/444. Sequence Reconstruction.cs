public class Solution {
    public bool SequenceReconstruction(int[] org, IList<IList<int>> seqs) {
        var n = org.Length;
        var order = new int[n+1];
        var pairs = new bool[n];
        
        for(var i =0; i < n; i++){
            order[org[i]] = i;
        }
        
        foreach(var seq in seqs){
            for(var i = 0; i< seq.Count; i++){
                if (seq[i] <= 0 || seq[i]> n) return false;
                if (i == 0 && seq[i] == org[0]) pairs[0] = true;
                if (i > 0 && order[seq[i-1]] >= order[seq[i]]) return false;
                if (i > 0 && order[seq[i-1]] + 1 == order[seq[i]]) pairs[order[seq[i]]] = true;
            }
        }
        
        for (int i = 0; i < n; i++) {
            if (!pairs[i]) return false;
        }
        return true;

    }
}