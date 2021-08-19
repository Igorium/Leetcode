/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool IsPalindrome(ListNode head) {
        
        if (head == null || head.next == null)
            return true;
        
        var slow = head;
        var fast = head;
        
        var history = new Stack<int>();
        
        while(fast != null && fast.next != null){
            history.Push(slow.val);
            slow = slow.next;
            fast = fast.next.next;
        }
        
        if (fast != null)
            slow = slow.next;
        
        while(history.Any()){
            if (history.Pop() != slow.val)
                return false;
            
            slow = slow.next;
        }
        
        return true;
    }
}