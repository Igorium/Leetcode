public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int K) {
        var st = new Stack<int>();
        var res = new List<int>();

        if(root == null || target == null)
            return res;
        
        if(K == 0){
            res.Add(target.val);
            return res;
        }

        var path = DFS(root, target);
        if(path == null)
            return res;

        TreeNode prev = null;
        while(path.Any() && K > 0){
            var q = new Queue<TreeNode>();
            q.Enqueue(path.Peek());
            var d = K;
            
            while(q.Any() && d > 0){
                for(int i = q.Count; i > 0; i--){
                    var node = q.Dequeue();

                    if(node.left != null && node.left != prev)
                        q.Enqueue(node.left);

                    if(node.right != null && node.right != prev)
                        q.Enqueue(node.right);
                }
                d--;
            }

            while(q.Any())
                res.Add(q.Dequeue().val);

            K--;
            prev = path.Dequeue();
            
            if(K==0 && path.Any())
                res.Add(path.Peek().val);
                
        }

        return res;
    }

    Queue<TreeNode> DFS(TreeNode node, TreeNode target){
        if(node == null)
            return null;

        if(node.val == target.val){
            var q = new Queue<TreeNode>();
            q.Enqueue(node);
            return q;
        }

        var path = DFS(node.left, target) ?? DFS(node.right, target);

        if(path != null){
            path.Enqueue(node);
            return path;
        }

        return null;
    }
}