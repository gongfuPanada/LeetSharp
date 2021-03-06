using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a linked list and a value x, 
// partition it such that all nodes less than x come before nodes greater than or equal to x.

// You should preserve the original relative order of the nodes in each of the two partitions.

// For example,
// Given 1->4->3->2->5->2 and x = 3,
// return 1->2->2->4->3->5.

namespace LeetSharp
{
    [TestClass]
    public class Q086_PartitionList
    {
        public ListNode<int> Partition(ListNode<int> head, int x)
        {
            if (head == null)
                return null;

            ListNode<int> first = new ListNode<int>(-1);
            ListNode<int> second = new ListNode<int>(-1);
            ListNode<int> originalFirst = first;
            ListNode<int> originalSecond = second;

            while (head != null)
            {
                if (head.Val < x)
                {
                    first.Next = head;
                    first = first.Next;
                }
                else
                {
                    second.Next = head;
                    second = second.Next;
                }
                head = head.Next;
            }
            second.Next = null;
            first.Next = originalSecond.Next;

            return originalFirst.Next;
        }

        public string SolveQuestion(string input)
        {
            return Partition(input.GetToken(0).ToListNode<int>(), input.GetToken(1).ToInt()).SerializeListNode();
        }

        [TestMethod]
        public void Q086_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q086_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
