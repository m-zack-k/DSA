/*
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
*/

public class Solution
{
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head == null || head.next == null || k == 0)
        {
            return head;
        }

        int n = 1;
        ListNode node = head;
        while (node.next != null)
        {
            n++;
            node = node.next;
        }
        int forward = k % n;
        if (forward == 0)
        {
            return head;
        }
        ListNode curr = head;

        for (int i = 0; i < n - forward - 1; ++i)
        {
            if (curr.next != null)
            {
                curr = curr.next;
            }
        }
        ListNode first = curr.next != null ? curr.next : head.next;
        curr.next = null;

        ListNode current = first;
        while (current.next != null)
        {
            current = current.next;
        }

        current.next = head;

        return first;
    }
}