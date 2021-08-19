public class Solution {
    public int RangeSumBST(TreeNode root, int low, int high) {
        if(root == null)
            return 0;

        if(root.val < low)
            return RangeSumBST(root.right, low, high);
        if(root.val > high)
            return RangeSumBST(root.left, low, high);

        return root.val + RangeSumBST(root.right, low, high) + RangeSumBST(root.left, low, high);
    }
}