public class Solution {
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) {
        var maxh = 0;
        var maxv = 0;

        horizontalCuts.Sort();
        verticalCuts.Sort();

        for(int i = 0; i <= horizontalCuts.Length; i++){
            var prev = i == 0 ? 0 : horizontalCuts[i-1];
            var next = i == horizontalCuts.Length ? h : horizontalCuts[i];

            maxh = Math.Max(maxh, next-prev);
        }

        for(int i = 0; i <= verticalCuts.Length; i++){
            var prev = i == 0 ? 0 : verticalCuts[i-1];
            var next = i == verticalCuts.Length ? w : verticalCuts[i];

            maxv = Math.Max(maxv, next-prev);
        }

        maxh = maxh == 0 ? h : maxh;
        maxv = maxv == 0 ? w : maxv;

        long res = (long)maxh * (long)maxv;

        return (int)(res % 1000000007);
    }
}