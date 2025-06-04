namespace DotNetInterviewProblems.Problems
{
    /// <summary>
    /// Detects if a singly linked list contains a cycle using the tortoise and
    /// hare algorithm (Floyd's cycle detection). Runs in O(n) time and constant
    /// space.
    /// </summary>
    public static class CycleDetection
    {
        public static bool HasCycle(ListNode? head)
        {
            if (head == null) return false;
            var slow = head;
            var fast = head.next;
            while (fast != null && fast.next != null)
            {
                if (slow == fast) return true;
                slow = slow!.next;
                fast = fast.next.next;
            }
            return false;
        }
    }
}
