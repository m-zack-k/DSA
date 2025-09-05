using System;

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
public class Solution1290 {
    public int GetDecimalValue(ListNode head)
    {
        int len = 0;
        ListNode current = head;

        while (current != null)
        {
            len++;
            current = current.next;
        }
        int a = 1 << (len - 1);
        int res = 0;
        ListNode curr = head;
        while (curr != null)
        {
            res += curr.val * a;
            curr = curr.next;
            a /= 2;
        }
        return res;
    }
}