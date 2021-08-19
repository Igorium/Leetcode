public class Solution {
    public int DiameterOfBinaryTree(TreeNode root) {
        int diameter = 0;
        DiameterOfBinaryTree(root, ref diameter);
        return diameter > 0 ? diameter-1 : 0;
    }

    public int DiameterOfBinaryTree(TreeNode node, ref int diameter) {
        if(node == null)
            return 0;

        var diameterLeft = DiameterOfBinaryTree(node.left, ref diameter);
        var diameterRight = DiameterOfBinaryTree(node.right, ref diameter);
        diameter = Math.Max(diameter, diameterLeft+diameterRight+1);

        return Math.Max(diameterLeft, diameterRight)+1;
    }
}