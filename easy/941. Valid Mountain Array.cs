public class Solution {
    public bool ValidMountainArray(int[] arr) {
        var n = arr.Length;
        if(n<3)
            return false;

        var down = false;
        for(var i=0; i < n-1; i++){
            var cur = arr[i];
            var next = arr[i+1];
            if(next > cur){
                if(down)
                    return false;
            } else if(next < cur){
                if(!down){
                    if(i==0)
                        return false;
                    down = true;
                }
            } else{
                return false;
            }
        }

        return down;
    }
}