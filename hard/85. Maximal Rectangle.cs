public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        var rows = matrix.Length;
        if(rows == 0)
            return 0;
        var cols = matrix[0].Length;
        var hist = new int[cols];
        var max = 0;

        for(int r = 0; r < rows; r++){
            for(int c = 0; c < cols; c++){
                hist[c] = matrix[r][c] == '1' ? hist[c]+1 : 0;
            }
            max = Math.Max(max, LargestRectangleArea(hist));
        }

        return max;
    }

    public int LargestRectangleArea(int[] heights) {
        var st = new Stack<int>();
        st.Push(-1);
        var len = heights.Length;
        var max = 0;

        for(int i = 0; i <= len; i++){
            var h = i == len ? -1 : heights[i];
            while(st.Peek() > -1 && heights[st.Peek()] > h){
                var prevIdx = st.Pop();
                var prevVal = heights[prevIdx];

                var square = prevVal * (i - 1 - st.Peek());
                max = Math.Max(max, square);
            }
            st.Push(i);
        }

        return max;
    }
}