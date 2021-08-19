public class SnapshotArray {
    List<ValueTuple<int,int>>[] data;
    int snapshots;

    public SnapshotArray(int length) {
        data = new List<ValueTuple<int,int>>[length];
        for(int i = 0; i < length; i++){
            data[i] = new List<ValueTuple<int,int>>{(0, 0)};
        }
    }
    
    public void Set(int index, int val) {
        var versions = data[index];
        
        (var version, _) = versions[versions.Count-1];
        if(snapshots > version){
            versions.Add((snapshots, val));
        } else {
            versions[versions.Count-1] = (version, val);
        }
    }
    
    public int Snap() {
        return snapshots++;
    }
    
    public int Get(int index, int snap_id) {
        var versions = data[index];
            
        var lo = 0;
        var hi = versions.Count;
        while(lo < hi){
            var mid = lo + (hi-lo)/2;
            (var version, var val) = versions[mid];
            if (version == snap_id)
                return val;
            
            if(version > snap_id)
                hi = mid;
            else
                lo = mid + 1;
        }
        
        (var ver, var v) = versions[hi-1];
        return v;
    }
}

/**
 * Your SnapshotArray object will be instantiated and called as such:
 * SnapshotArray obj = new SnapshotArray(length);
 * obj.Set(index,val);
 * int param_2 = obj.Snap();
 * int param_3 = obj.Get(index,snap_id);
 */