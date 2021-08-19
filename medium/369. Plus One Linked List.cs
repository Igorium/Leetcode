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
    public ListNode PlusOne(ListNode head) {
        
        var dummy = new ListNode(0, head);
        var nonNine = dummy;
        
        while(head != null){
            if(head.val < 9)
                nonNine = head;
            
            head = head.next;
        }
        
        nonNine.val++;
        
        while(nonNine.next != null){
            nonNine.next.val = 0;
            nonNine = nonNine.next;
        }
        
        return dummy.val > 0 ? dummy : dummy.next;
        
        //var carry = PlusOneInternal(head);       
        //return carry > 0 ? new ListNode(carry, head) : head;
    }
    
    public int PlusOneInternal(ListNode node) {
       
        var carry = node.next == null ? 1 : PlusOneInternal(node.next);
        
        var d = node.val + carry;
        node.val = d % 10;
        return d / 10;
    }
}