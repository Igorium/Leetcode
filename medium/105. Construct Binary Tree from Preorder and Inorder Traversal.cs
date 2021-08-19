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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        var preIdx = 0;
        var n = preorder.Length-1;

        var map = new Dictionary<int, int>();
        for(int i = 0; i <= n; i++)
            map[inorder[i]] = i;

        TreeNode buildTree(int lo, int hi){
            if(lo > hi)
                return null;

            var rootIdx = map[preorder[preIdx++]];
            var root = new TreeNode(inorder[rootIdx]);
            
            root.left = buildTree(lo, rootIdx-1);
            root.right = buildTree(rootIdx+1, hi);

            return root;
        }

        return buildTree(0, n);
    }
}