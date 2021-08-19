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
    public int MaxPathSum(TreeNode root) {
        
        var maxSum = int.MinValue;
        MaxPathSum(root, ref maxSum);
        
        return maxSum;
    }
    
    public int MaxPathSum(TreeNode root, ref int maxSum) {
        if (root == null)
            return 0;
        
        var maxL = Math.Max(MaxPathSum(root.left, ref maxSum), 0);
        var maxR = Math.Max(MaxPathSum(root.right, ref maxSum), 0);
        
        maxSum = Math.Max(maxSum, maxL+maxR+root.val);
        
        return Math.Max(maxL, maxR)+root.val;
    }
}