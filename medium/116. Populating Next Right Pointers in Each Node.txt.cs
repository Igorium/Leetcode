/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if(root == null)
            return null;

        var left = root;
        while(left != null){
            var parent = left;
            left = parent.left;
            while(parent != null){
                parent.left.next = parent.right;
                if(parent.next != null){
                    parent.right.next = parent.next.left;
                parent = parent.next;
            }
        }

        return root;
    }
}