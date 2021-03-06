/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        bool DFS(TreeNode node){
            if(node == null)
                return false;

            var l = DFS(node.left);
            var r = DFS(node.right);
            if(l && r || (node == p || node == q) && (r || l)){
                root = node;
                return false;
            }

            return node == p || node == q || r || l;
        }

        DFS(root);
        return root;
    }
}

/*
public class Solution {
    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        Map<TreeNode, TreeNode> parent = new HashMap<>();
        Deque<TreeNode> stack = new ArrayDeque<>();
        parent.put(root, null);
        stack.push(root);

        while (!parent.containsKey(p) || !parent.containsKey(q)) {
            TreeNode node = stack.pop();
            if (node.left != null) {
                parent.put(node.left, node);
                stack.push(node.left);
            }
            if (node.right != null) {
                parent.put(node.right, node);
                stack.push(node.right);
            }
        }

        To find the lowest common ancestor, we need to find where is p and q and a way to track their ancestors. 
        A parent pointer for each node found is good for the job. After we found both p and q, we create a set of p's ancestors. 
        Then we travel through q's ancestors, the first one appears in p's is our answer.

        Set<TreeNode> ancestors = new HashSet<>();
        while (p != null) {
            ancestors.add(p);
            p = parent.get(p);
        }
        while (!ancestors.contains(q))
            q = parent.get(q);
        return q;
    }
}
*/