using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    /// You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
    /// Merge all the linked-lists into one sorted linked-list and return it.
    /// </summary>
    public class _00023_MargeKSortedLists_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            List<ListNode> listArray = new List<ListNode>();
            ListNode temp = new ListNode(5);
            temp = new ListNode(4, temp);
            temp = new ListNode(1, temp);
            listArray.Add(temp);

            temp = new ListNode(4);
            temp = new ListNode(3, temp);
            temp = new ListNode(1, temp);
            listArray.Add(temp);

            temp = new ListNode(6);
            temp = new ListNode(2, temp);
            listArray.Add(temp);

            ListNode answer;
            answer = MergeKLists(listArray.ToArray());
            Assert.AreEqual(1, answer.val);
            answer = answer.next;
            Assert.AreEqual(1, answer.val);
            answer = answer.next;
            Assert.AreEqual(2, answer.val);
            answer = answer.next;
            Assert.AreEqual(3, answer.val);
            answer = answer.next;
            Assert.AreEqual(4, answer.val);
            answer = answer.next;
            Assert.AreEqual(4, answer.val);
            answer = answer.next;
            Assert.AreEqual(5, answer.val);
            answer = answer.next;
            Assert.AreEqual(6, answer.val);
            //answer = answer.next;


            //answer = MaxProfit(new int[] { 5, 7, 1, 5, 3, 6, 4 });
            //Assert.AreEqual(5, answer);
            //answer = MaxProfit(new int[] { 7, 6, 4, 3, 1 });
            //Assert.AreEqual(0, answer);
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;
            if (lists.Length == 1 && lists[0] == null)
                return null;

            ListNode head = null;
            ListNode currentNode = null;
            while (true)
            {
                // Find the min head index in the array
                int minIndex = Int32.MaxValue;
                int minValue = Int32.MaxValue;
                bool foundValue = false;
                for (int i = 0; i < lists.Length; i++)
                {
                    var list = lists[i];
                    // List has ended?
                    if (list == null)
                        continue;
                    // Find the lowest value among the heads
                    if (!foundValue || list.val < minValue)
                    {
                        minIndex = i;
                        minValue = list.val;
                        foundValue = true;
                    }
                }

                if (!foundValue)
                {
                    break;
                }

                var newNode = new ListNode(minValue);
                if (head == null)
                {
                    head = newNode;
                    currentNode = head;
                }
                else
                {
                    currentNode.next = newNode;
                    currentNode = newNode;
                }
                // Move the linked list we just consumed to the next value
                lists[minIndex] = lists[minIndex].next;
            }

            return head;
        }
    }
}