/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        var map = new Dictionary<Node, Node>();
        var curr = head;
        Node prev = null;
        
        while(curr != null){
            var newNode = new Node(curr.val);
            if(prev != null)
                prev.next = newNode;
            map[curr] = newNode;
            curr = curr.next;
            prev = newNode;
        }
        
        curr = head;
        while(curr != null){
            if(curr.random != null){
                map[curr].random = map[curr.random];
            }
            curr = curr.next;
        }
        
        return head != null ? map[head] : null;
    }
}