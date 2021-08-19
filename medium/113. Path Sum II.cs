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
    public IList<IList<int>> PathSum(TreeNode root, int targetSum) {
        var res = new List<IList<int>>();

        var r = PathSum(root, targetSum, 0);
        if( r != null)
            foreach(var st in r)
                res.Add(st.ToList());

        return res;
    }

    public List<Stack<int>> PathSum(TreeNode node, int targetSum, int sum) {
        if(node == null)
            return null;

        if(node.left == null && node.right == null){
            if(sum+node.val == targetSum){
                var r = new List<Stack<int>>{new Stack<int>()};
                r[0].Push(node.val);
                return r;
            }

            return null;
        }

        var stl = PathSum(node.left, targetSum, sum+node.val);
        var str = PathSum(node.right, targetSum, sum+node.val);

        if(stl == null && str == null)
            return null;

        var l = stl ?? str;

        if(str != null && stl != null)
            foreach(var st in str)
                l.Add(st);

        foreach(var st in l)
            st.Push(node.val);

        return l;
    }
}