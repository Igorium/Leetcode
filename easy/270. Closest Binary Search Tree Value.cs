public class Solution {
    public int ClosestValue(TreeNode root, double target) {
        var res = root.val;
        var delta = double.MaxValue;
        while(root != null){
            if((double)root.val == target)
                return root.val;

            var d = Math.Abs(root.val-target);
            if(d < delta){
                delta = d;
                res = root.val;
            }

            root = (double)root.val > target ? root.left : root.right;
        }

        return res;
    }
}