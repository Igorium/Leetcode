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
    /*
         0
       1    2
          3
    
    */
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        var res = new List<IList<int>>();
        if(root == null)
            return res;

        var map = new Dictionary<int, List<int>>(); // 0;03 -1;1 1;2 
        var q = new Queue<(TreeNode, int)>();

        q.Enqueue((root, 0)); // 2;1

        var max = 0; 
        var min = 0;  

        while(q.Any()){
            var (node, level) = q.Dequeue(); // 3;0
            if(node == null) //f
                continue;
            
            if(!map.ContainsKey(level)) // f
                map[level] = new List<int>();
            map[level].Add(node.val); 

            max = Math.Max(max, level); // 0
            min = Math.Min(min, level); // -1

            q.Enqueue((node.left, level-1));
            q.Enqueue((node.right, level+1));
        }

        for(int i = min; i <=max; i++){
            res.Add(map[i]);
        }

        return res;
    }
}