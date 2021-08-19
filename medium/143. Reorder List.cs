/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public void ReorderList(ListNode head)
    {
        if (head == null)
		{
			return;
		}
        ReorderList(head.next, head);
    }
    
    private ListNode ReorderList(ListNode tail, ListNode parent)
    {
        if(tail == null)
            return parent;

        var head = ReorderList(tail.next, parent);

        if(head == null || head == tail){
            if(head != null)
                head.next = null;
            return null;
        }

        var next = head.next;
        head.next = tail;

        if(next == tail){
            tail.next = null;
            return null;
        }

        tail.next = next;
        return next;
    }
}

public class Solution {
    public void ReorderList(ListNode head) {
        var st = new Stack<ListNode>(); // 1 2 
        var node = head;
        while(node != null){
            st.Push(node);
            node = node.next;
        }

        while(head != null){
            var next = head.next;
            var tail = st.Pop();

            if(tail == head)
                break;
            head.next = tail;
            head = head.next;

            if(next == head)
                break;
            head.next = next;
            head = head.next;
        }

        if(head != null)
            head.next = null;
    }
}