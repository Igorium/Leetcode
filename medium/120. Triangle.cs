public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        var res = 0;
        var rows = triangle.Count;

        for(int r = rows-2; r >= 0; r--){
            for(int c = 0; c < triangle[r].Count; c++){
                triangle[r][c] += Math.Min(triangle[r+1][c], triangle[r+1][c+1]);
            }
        } 

        return triangle[0][0];
    }
}