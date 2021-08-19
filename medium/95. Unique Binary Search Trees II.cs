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
    public IList<TreeNode> GenerateTrees(int n) {
        if(n==0)
            return new List<TreeNode>();
        
        return GenerateTrees(1, n);
    }
    
    public IList<TreeNode> GenerateTrees(int start, int end) {
        var trees = new List<TreeNode>();
        
        if (start > end){
            trees.Add(null);
            return trees;
        }      
        
        for(int i = start; i <=end; i++){
            var lTrees = GenerateTrees(start, i-1);
            var rTrees = GenerateTrees(i+1, end);
            
            foreach(var l in lTrees)
                foreach(var r in rTrees){
                    trees.Add(new TreeNode(i, l, r));
                }
        }
        
        return trees;
    }
}