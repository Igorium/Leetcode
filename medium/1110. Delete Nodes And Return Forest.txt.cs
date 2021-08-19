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
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        var res = new List<TreeNode>();
        var d = new HashSet<int>(to_delete);
        
        DeleteNodes(root, res, d, null, false);
        
        if(!d.Contains(root.val))
            res.Add(root);
        
        return res;
    }
    
    private void DeleteNodes(TreeNode n, List<TreeNode> res, HashSet<int> d, TreeNode parent, bool left){
        if(n == null)
            return;
        
        if(d.Contains(n.val)){
            if(parent != null){
                if(left)
                    parent.left = null;
                else
                    parent.right = null;
            }
            
            if(n.left != null && !d.Contains(n.left.val))
                res.Add(n.left);
            
            if(n.right != null && !d.Contains(n.right.val))
                res.Add(n.right);
        }
        
        DeleteNodes(n.left, res, d, n, true);
        DeleteNodes(n.right, res, d, n, false);
    }
}