// morris  traversal
public class Solution {
    public void RecoverTree(TreeNode root) {
        TreeNode prev = null;
        TreeNode firstNode = null;
        TreeNode secondNode = null;

        void check(TreeNode node){
            if(prev != null && node.val < prev.val){
                if(firstNode == null)
                    firstNode = prev;
                
                secondNode = node;
            }

            prev = node;
        }

        var cur = root;

        while(cur != null){
            if(cur.left == null){
                check(cur);
                cur = cur.right;
            } else {
                var pred = cur.left;
                while(pred.right != cur && pred.right != null)
                    pred = pred.right;

                if(pred.right == null){ // not visited
                    pred.right = cur;
                    // visit pre-order
                    cur = cur.left;
                } else { // visited
                    pred.right = null;
                    check(cur); // in-order
                    cur = cur.right;
                }
            }
        }

        var t = firstNode.val;
        firstNode.val = secondNode.val;
        secondNode.val = t;
    }
}

public class Solution {
    public void RecoverTree(TreeNode root) {
        var st = new Stack<TreeNode>();
        
        void traverseLeft(TreeNode node){
            while(node != null){
                st.Push(node);
                node = node.left;
            }
        }

        traverseLeft(root);
        TreeNode prev = null;
        TreeNode firstNode = null;
        TreeNode secondNode = null;

        while(st.Any()){
            var node = st.Pop();

            if(prev != null && node.val < prev.val){
                if(firstNode == null)
                    firstNode = prev;
                
                secondNode = node;
            }

            prev = node;
            traverseLeft(node.right);
        }

        var t = firstNode.val;
        firstNode.val = secondNode.val;
        secondNode.val = t;
    }
}