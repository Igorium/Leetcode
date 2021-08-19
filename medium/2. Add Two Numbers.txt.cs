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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            return GetSum(l1, l2, 0);
    }
    
    public ListNode GetSum(ListNode l1, ListNode l2, int carry){
        if (l1 == null && l2 == null)
            return carry > 0 ? new ListNode(carry) : null;
        
        var sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
        var res = new ListNode(sum % 10);
        res.next = GetSum(l1?.next, l2?.next, sum / 10);
        
        return res;        
    }
    

}