/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public int GoodNodes(TreeNode root) {
        var res = 0;
        GoodNodes(root, int.MinValue, ref res);
        return res;
    }

    void GoodNodes(TreeNode node, int max, ref int res){
        if(node == null)
            return;

        if(node.val >= max){
            res++;
            max = node.val;
        }

        GoodNodes(node.left, max, ref res);
        GoodNodes(node.right, max, ref res);
    }
}