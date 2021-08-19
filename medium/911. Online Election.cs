public class TopVotedCandidate {
    int[] winners;
    int[] times;
    int N;

    public TopVotedCandidate(int[] persons, int[] times) {
        this.times = times;
        N = times.Length;
        winners = new int[N];
        var scores = new Dictionary<int, int>();
        var leader = -1;
        
        for(var i = 0; i < N; i++){
            var candidate = persons[i];
            if(scores.ContainsKey(candidate))
                scores[candidate] += 1;
            else
                scores[candidate] = 1;
            
            if(leader == -1 || scores[candidate] >= scores[leader]){
                leader = candidate;
            }
            
            winners[i] = leader;
        }
    }
    
    public int Q(int t) {
        var lo = 0;
        var hi = N-1;
        while(lo < hi){
            var mid = lo + (hi-lo)/2;
            if(times[mid] > t)
                hi = mid;
            else
                lo = mid+1;
        }
        
        return times[hi] > t ? winners[hi-1] : winners[hi];
    }
}

/**
 * Your TopVotedCandidate object will be instantiated and called as such:
 * TopVotedCandidate obj = new TopVotedCandidate(persons, times);
 * int param_1 = obj.Q(t);
 */