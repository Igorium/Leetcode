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
    public ListNode SwapPairs(ListNode head) {

        ListNode prev = null;
        ListNode res = null;
        
        while(head != null && head.next != null){
            var second = head.next;
            var third = second.next;
            
            second.next = head;
            if(prev != null)
                prev.next = second;
            else
                res = second;
            
            prev = head;
            head = third;
        }
        
        if (prev != null)
            prev.next = head;
        
        return res;
    }
    
    /*public ListNode SwapPairs(ListNode head) {
        if(head == null || head.next == null)
            return head;
        
        var next = head.next;
        var memo = next.next;
        next.next = head;
        head.next = SwapPairs(memo);
        
        
        
        return next;
    }*/
}