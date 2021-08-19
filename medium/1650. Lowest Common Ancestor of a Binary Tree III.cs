/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution {
    public Node LowestCommonAncestor(Node p, Node q) {
        var path = new HashSet<Node>();
        while(p != null){
            path.Add(p);
            p = p.parent;
        }

        while(q != null){
            if(path.Contains(p))
                return p;
            
            p = p.parent;
        }

        return null;
    }
}