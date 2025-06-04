namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Basic singly linked list node used by linked list problems.
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
