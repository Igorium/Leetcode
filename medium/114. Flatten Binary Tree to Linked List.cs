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
    public void Flatten(TreeNode root) {
        FlattenInternal(root);
    }

    /*
             1
        2        5
    3      4        6

    1 - 2 - 3 - 4 - 
    */

    public TreeNode FlattenInternal(TreeNode node) { //1 
        if(node == null) // false
            return node;

        var left = node.left; // 2 
        var right = node.right; // 5
        node.right = null;
        node.left = null;
        TreeNode lastSubtreeNode = node;

        // visit left subtree
        if(left != null){ // t
            lastSubtreeNode.right = left; 
            lastSubtreeNode = FlattenInternal(left); // 4
        }
        
        // visit right
        if(right != null){
            // contunie left subtree or curent node
            lastSubtreeNode.right = right;
            lastSubtreeNode = FlattenInternal(right); // 4
        }

        return lastSubtreeNode; // 4
    }
}