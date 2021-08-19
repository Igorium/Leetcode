/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {     
        
        var l = 0;
        var r = n;
        
        while(r >= l){
            var mid = l + (r-l)/2;
            var isBad = IsBadVersion(mid);
            if(isBad){
                if(!IsBadVersion(mid-1))
                    return mid;
                r = mid-1;
            } else{
                if (IsBadVersion(mid+1))
                    return mid + 1;
                l = mid + 1;
            }
        }
        
        return -1;
        
    }
}