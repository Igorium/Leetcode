public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var st = new Stack<int>();
        st.Push(-1);
        var len = heights.Length;
        var max = 0;

        for(int i = 0; i < len; i++){
            var h = heights[i];
            while(st.Peek() > -1 && heights[st.Peek()] > h){
                var prevIdx = st.Pop();
                var prevVal = heights[prevIdx];

                var square = prevVal * (i - 1 - st.Peek());
                max = Math.Max(max, square);
            }
            st.Push(i);
        }

        while(st.Peek() > -1){
            var prevIdx = st.Pop();
            var prevVal = heights[prevIdx];

            var square = prevVal * (len - 1 - st.Peek());
            max = Math.Max(max, square);
        }

        return max;
    }
}