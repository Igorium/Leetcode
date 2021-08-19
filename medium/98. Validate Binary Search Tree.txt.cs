/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool IsValidBST(TreeNode root) {
        return EnsureInterval(root, null, null);
    }
    
    private bool EnsureInterval(TreeNode n, int? min, int? max)
    {
        if (n == null)
            return true;
        
        if ((min == null || n.val > min.Value) && (max == null || n.val < max.Value) )
             return EnsureInterval(n.left, min, n.val) && EnsureInterval(n.right, n.val, max);
        
        return false;
    }
}