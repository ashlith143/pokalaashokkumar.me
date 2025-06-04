namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Reverses a singly linked list iteratively in O(n) time by rewiring the
    /// next pointers as it traverses the list.
    /// </summary>
    public static class ReverseLinkedList
    {
        public static ListNode? Reverse(ListNode? head)
        {
            ListNode? prev = null;
            ListNode? current = head;
            while (current != null)
            {
                var next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
    }
}
