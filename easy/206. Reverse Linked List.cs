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
public class Solution {
    public ListNode ReverseList(ListNode head) {
        return ReverseList(head, null);
    }
    
    public ListNode ReverseList(ListNode head, ListNode prev) {
        if(head == null)
            return prev;
        
        var next = head.next;        
        head.next = prev;

        return ReverseList(next, head);
        
        
    }
    
    /*public ListNode ReverseList(ListNode head) {
        
        ListNode prev = null;
        var curr = head;
        
        while(curr != null){
            var next = curr.next;
            
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        
        return prev;
    }*/
}