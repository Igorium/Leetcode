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
    public IList<string> BinaryTreePaths(TreeNode root) {
        var res = new List<string>();
        if(root == null)
            return res;

        var q = new Queue<(TreeNode, string)>();
        q.Enqueue((root, ""));
        while(q.Any()){
            var (node, path) = q.Dequeue();
            if(path != "")
                path += "->";
            path += node.val;
            if(node.left == null && node.right == null)
                res.Add(path);
            else {
                if(node.left != null)
                    q.Enqueue((node.left, path));
                if(node.right != null)
                    q.Enqueue((node.right, path));
            }
        }

        return res;
    }
}