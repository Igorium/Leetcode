public class Solution {
    public bool IsSubtree(TreeNode s, TreeNode t) {
        var sTree = Preorder(s);
        var tTree = Preorder(t);

        return sTree.IndexOf(tTree) != -1;
    }

    string Preorder(TreeNode node){
        return node == null 
            ? "n" 
            : string.Concat("#", node.val, Preorder(node.left), Preorder(node.right));
    }
}