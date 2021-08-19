public class Solution {
    public bool CheckIfExist(int[] arr) {
        var set = new HashSet<int>();
        foreach(var n in arr){
            if(set.Contains(n*2) || (n%2 == 0 && set.Contains(n/2)))
                return true;
            set.Add(n);
        }
        return false;
    }
}