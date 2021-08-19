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
    public IList<int> RightSideView(TreeNode root) {
        var res = new List<int>();

        if(root == null)
            return res;

        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while(q.Any()){
            var n = q.Count;
            for(int i = 0; i < n; i++){
                var node = q.Dequeue();
                
                if(node.right != null)
                    q.Enqueue(node.right);
                else if(node.left != null)
                    q.Enqueue(node.left);
                
                if(i == n-1)
                    res.Add(node.val);
            }
        }

        return res;
    }
}