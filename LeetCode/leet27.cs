
// public class ListNode {
//      public int val;
//      public ListNode next;
//      public ListNode(int val=0, ListNode next=null) {
//         this.val = val;
//         this.next = next;
//     }
// }

public class Solution27 {
    public ListNode MergeKLists(ListNode[] lists)
    {
        var pq = new PriorityQueue<ListNode, int>();
        foreach (ListNode node in lists)
        {
            if (node != null) pq.Enqueue(node, node.val);
        }

        var sentinel = new ListNode();
        var current = sentinel;

        while (pq.Count > 0)
        {
            var smallest = pq.Dequeue();
            if (smallest.next != null)
            {
                pq.Enqueue(smallest.next, smallest.next.val);
            }
            current.next = smallest;
            current = current.next;
        }
        return sentinel.next;
    }
}