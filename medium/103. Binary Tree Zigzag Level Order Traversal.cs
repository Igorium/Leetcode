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
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var res = new List<IList<int>>();
        if(root == null)
            return res;
        
        var prev = new Stack<TreeNode>();
        prev.Push(root);
        res.Add(new List<int>{root.val});
        var forward = false;

        while(prev.Any()){
            var cur = new Stack<TreeNode>();
            var level = new List<int>();

            void AddNode(TreeNode n){
                if(n != null){
                    level.Add(n.val);
                    cur.Push(n);
                }
            }
            
            for(int count = prev.Count; count > 0; count--){
                var node = prev.Pop();
                if(forward){
                    AddNode(node.left);
                    AddNode(node.right);
                } else {
                    AddNode(node.right);
                    AddNode(node.left);
                }
            }

            prev = cur;
            if(level.Any())
                res.Add(level);
            forward = !forward;
        }

        return res;
    }
}