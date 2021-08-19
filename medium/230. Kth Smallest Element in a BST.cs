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
    public int KthSmallest(TreeNode root, int k) {
        var st = new Stack<TreeNode>();
        
        void moveLeft(TreeNode node){
            while(node != null){
                st.Push(node);
                node = node.left;
            }
        }

        moveLeft(root);

        while(st.Any()){
            var node = st.Pop();
            if(--k == 0)
                return node.val;

            if(node.right != null){
                moveLeft(node.right);
            }
        }

        return -1;
    }
}