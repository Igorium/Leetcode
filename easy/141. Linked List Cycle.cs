/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        if (head == null || head.next == null)
            return false;
        
        var slow = head.next;
        var fast = head.next.next;
        
        while(slow != null && fast != null && slow != fast){
            slow = slow.next;
            fast = fast.next?.next;
        }
        
        return slow == fast;
    }
}