/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        if(l1==null)
            return l2;
        if(l2==null)
            return l1;
        
        var result = new ListNode(0);
        var l = result;
        
        while(l1 != null && l2 != null)
        {
            if (l1.val < l2.val){
                l.next = l1;
                l1 = l1.next;
            } else{
                l.next = l2;
                l2 = l2.next;
            }
            l = l.next;
        }
        
        var left = l1 != null ? l1 : l2;
        
        while(left != null){
            l.next = left;
            left = left.next;
            l = l.next;
        }

        
        return result.next;
    }
}