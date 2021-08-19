
public class Solution {
    public Node Insert(Node head, int insertVal) {
        if(head == null){
            head = new Node(insertVal);
            head.next = head;
            return head;
        }

        var node = head;
        var inserted = false;
        var maxNode = head;
        do{
            var next = node.next;
            if(insertVal >= node.val && insertVal < next.val){
                node.next = new Node(insertVal, next);
                inserted = true;
                break;
            }
            
            if(node.val >= maxNode.val)
                maxNode = node;

            node = next;
        }while(node != head);
        
        if(!inserted){
            maxNode.next = new Node(insertVal, maxNode.next);
        }

        return head;
    }
}