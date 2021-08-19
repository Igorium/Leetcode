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
        void link(Node next, ref Node cur, ref Node first){
            if(first == null)
                first = cur ?? next;
            
            if(cur == null){
                cur = next;
            }else if(next != null){
                cur.next = next;
                cur = next;
            }            
        }

        var left = root;

        while(left != null){
            var head = left;
            var cur = head.left;
            left = null;

            while(head != null){
                link(head.right, ref cur, ref left);

                if(head.next != null)
                    link(head.next.left, ref cur, ref left);

                head = head.next;
            }
        }

        return root;
    }
}