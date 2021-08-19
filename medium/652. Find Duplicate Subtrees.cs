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
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        var set = new Dictionary<string, bool>();
        var res = new List<TreeNode>();
        
        string Lookup(TreeNode node){
            if(node == null)
                return "#";
            
            var id = node.val + "," + Lookup(node.left) + "," + Lookup(node.right);
            if(set.TryGetValue(id, out var used)){
                if(!used){
                    res.Add(node);
                    set[id] = true;
                }
            } else {
                set[id] = false;
            }
            
            return id;
        }
        
        Lookup(root);
        return res;
    }
}