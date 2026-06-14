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
public class Solution
{
    public int PairSum(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;
        var stack = new Stack<int>();
        while (fast != null && fast.next != null)
        {
            stack.Push(slow.val);
            slow = slow.next;
            fast = fast.next.next;
        }
        int max = -1;
        while (slow != null)
        {
            max = Math.Max(max, stack.Pop() + slow.val);
            slow = slow.next;
        }
        return max;
    }
}