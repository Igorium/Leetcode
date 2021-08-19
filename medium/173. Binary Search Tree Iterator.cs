public class BSTIterator {
    private Stack<TreeNode> stack = new Stack<TreeNode>();

    public BSTIterator(TreeNode root) {
        TraverseLeft(root);
    }
    
    public int Next() {
        node = stack.Pop();
        TraverseLeft(node.right);
        return node.val;
    }
    
    public bool HasNext() {
        return stack.Any();
    }

    private void TraverseLeft(TreeNode node){
        while(node != null){
            stack.Push(node);
            node = node.left;
        }
    }
}
