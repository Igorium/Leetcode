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
    public int CountNodes(TreeNode root) {
        if (root == null)
            return 0;
        
        var n = root;        
        var d = 0;
        
        while(n.left != null){
            n = n.left;
            d++;
        }
        
        if (d == 0)
            return 1;
        
        var lo = 1;
        var hi = (int)Math.Pow(2, d)-1;
        
        
        while(lo <= hi){
            var mid = lo + (hi-lo)/2;
            
            if (Exists(root, mid, d))
                lo = mid+1;
            else
                hi = mid -1;
        }
        
        return (int)Math.Pow(2, d) - 1 + lo;
    }
    
    public bool Exists(TreeNode n, int t, int d){
        var lo = 0;
        var hi = (int)Math.Pow(2, d)-1;
        
        while(d > 0){
            var mid = lo+(hi-lo)/2;
            if (t>mid){
                lo = mid +1;
                n = n.right;
            } else {
                hi = mid-1;
                n = n.left;
            }
            d--;
        }
        
        return n != null;
    }
}