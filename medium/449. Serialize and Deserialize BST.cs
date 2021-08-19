/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        var sb = new StringBuilder();
        serialize(root, sb);
        return sb.ToString();
    }

    public void serialize(TreeNode node, StringBuilder sb) {
        if(node == null)
            return;
        sb.Append(node.val).Append(' ');
        serialize(node.left, sb);
        serialize(node.right, sb);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        var q = new Queueu<int>();
        foreach(var str in data.Split(' '))
            q.Enqueue(int.Parse(str));

        return deserialize(q, int.MinValue, int.MaxValue);
    }

    public TreeNode deserialize(Queue<int> q, int min, int max) {
        if(!q.Any())
            return null;

        var n = q.Peek();
        if(n < min && n > max)
            return null;

        q.Dequeue();
        var node = new TreeNode(n);
        node.left = deserialize(q, min, n);
        node.right = deserialize(q, n, max);
        return node;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// String tree = ser.serialize(root);
// TreeNode ans = deser.deserialize(tree);
// return ans;