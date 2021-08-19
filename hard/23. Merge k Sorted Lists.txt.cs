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
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists == null || lists.Length == 0)
            return null;
        var n = lists.Length;
        if (n == 1)
            return lists[0];
        
        var step = 1;
        if(n % 2 != 0){
            lists[0] = MergeTwo(lists[0], lists[n-1]);
            n--;
        }
        
        while(step < n){
            for(var i = 0; i < n-step; i += step*2){
                lists[i] = MergeTwo(lists[i], lists[i+step]);
            }
            step *= 2;
        }
        
        return lists[0];
    }
    
    private ListNode MergeTwo(ListNode l1, ListNode l2){
        var dummy = new ListNode();
        var head = dummy;
        
        while(l1 != null && l2 != null){
            if(l1.val < l2.val){
                head.next = l1;
                l1 = l1.next;
            } else {
                head.next = l2;
                l2 = l2.next;
            }
            head = head.next;
        }
        
        var l = l1 == null ? l2 : l1;
        if(l != null)
            head.next = l;
        
        return dummy.next;
    }
}