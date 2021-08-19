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
    public TreeNode SortedArrayToBST(int[] nums) {
        return Convert(nums, 0, nums.Length-1);
    }

    public TreeNode Convert(int[] nums, int start, int end){// 0 1 // 3 4 
        if(end < start)
            return null;
        if(start == end) // f
            return new TreeNode(nums[start]);

        var mid = start + (end-start)/2; // 3
        var node = new TreeNode(nums[mid]); // 5
        node.Left = Convert(nums, start, mid-1); // 3 2
        node.Right = Convert(nums, mid+1, end); // 4 4
        return node; // 0
    }
}