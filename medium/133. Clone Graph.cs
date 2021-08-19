/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if(node == null)
            return null;

        var visited = new Dictionary<Node, Node>();
        var q = new Queue<Node>();

        void Clone(Node n){
            if(n == null || visited.ContainsKey(n))
                return;

            q.Enqueue(n);
            var clone = new Node(n.val);
            visited[n] = clone;
        }

        Clone(node);

        while(q.Any()){
            var n = q.Dequeue();
            var clone = visited[n];
            foreach(var nei in n.neighbors){
                Clone(nei);
                clone.neighbors.Add(visited[nei]);
            }
        }

        return visited[node];
    }
}