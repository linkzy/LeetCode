//Explanation: https://linkzy.dev/2-leetcode-add-two-numbers-problem-and-solution/
//Submission: https://leetcode.com/problems/add-two-numbers/submissions/1101116263

namespace csharp
{
    public class AddTwoNumbersSolution
    {

        [Fact]
        public void Can_Add_Two_Numbers()
        {
            ListNode l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            ListNode l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            ListNode result1 = AddTwoNumbers(l1, l2);
            Object.Equals(new ListNode(7, new ListNode(0, new ListNode(8))), result1);

            // Test case 2
            ListNode l3 = new ListNode(0);
            ListNode l4 = new ListNode(0);
            ListNode result2 = AddTwoNumbers(l3, l4);
            Object.Equals(new ListNode(0), result2);

            // Test case 3
            ListNode l5 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            ListNode l6 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
            ListNode result3 = AddTwoNumbers(l5, l6);
            Object.Equals(new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1)))))))), result3);
        }
        
        private ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode();
            ListNode current = result;
            int carry = 0;

            while (l1 != null || l2 != null || carry != 0)
            {
                int sum = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
                carry = sum / 10;

                current.next = new ListNode(sum % 10);
                current = current.next;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            return result.next;
        }
    }


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
}
