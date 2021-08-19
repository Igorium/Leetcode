/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        
        if (head == null || head.next == null)
            return null;
            
        ListNode start = new ListNode(0);
        start.next = head;
        var ahead = start;
        var behind = start;       
        
        
        while(n-- >= 0)
        {
            ahead = ahead.next;
        }
        
        while(ahead != null){
            ahead = ahead.next;
            behind = behind.next;
        }
        
        
        behind.next = behind.next.next;
        
        return start.next;
    }
}