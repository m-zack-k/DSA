using System;


public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
public class Solution21
{
    static void Main(){
        
    }
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode ans = new ListNode();
        ListNode current = ans;
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }
        current.next = (list1 == null) ? list2 : list1;
        return ans.next;
    }
}