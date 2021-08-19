public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null)
            return "";

        var sb = new List<string>();
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        while(q.Any()){
            var node = q.Dequeue();
            if(node != null){
                sb.Add(node.val.ToString());
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            } else{
                sb.Add("");
            }
        }
        
        return string.Join(",", sb);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(data == "")
            return null;

        var treeValues = data.Split(",");
        var n = treeValues.Length;

        bool tryGetNode(int idx, out TreeNode node){
            var hasValue = treeValues[idx] != "";
            node = hasValue ? new TreeNode{val = int.Parse(treeValues[idx])} : null;
            return hasValue;
        }

        tryGetNode(0, out var root);
        var q = new Queue<TreeNode>();
        q.Enqueue(root);

        for(int i = 1; i < n; i++){
            var node = q.Dequeue();

            if(tryGetNode(i, out node.left))
                q.Enqueue(node.left);

            if(tryGetNode(++i, out node.right))
                q.Enqueue(node.right);
        }

        return root;
    }
}