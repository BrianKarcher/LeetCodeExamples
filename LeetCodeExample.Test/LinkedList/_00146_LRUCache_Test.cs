using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Design a data structure that follows the constraints of a Least Recently Used(LRU) cache.

    //   Implement the LRUCache class:

    //   LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
    //   int get(int key) Return the value of the key if the key exists, otherwise return -1.
    //   void put(int key, int value) Update the value of the key if the key exists.Otherwise, add the key-value pair to the cache.If the number of keys exceeds the capacity from this operation, evict the least recently used key.
    //   The functions get and put must each run in O(1) average time complexity.
    /// </summary>
    /// 

    // ANSWER:
    // Hashmap + DoubleLinkedList
    // Hashmap is key : node in DLL
    // When getting a value, move the node to the front of the DLL (O(1)) time.
    // Thus, when removing the "least recently used", it will always be at the tail.
    // Use both a dummy head and a dummy tail to remove the edge case null checks

    public class _00146_LRUCache_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //var answer = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);

            //answer = TwoSum(new int[] { 3, 2, 4 }, 6);
            //Assert.AreEqual(1, answer[0]);
            //Assert.AreEqual(2, answer[1]);

            //answer = TwoSum(new int[] { 3, 3 }, 6);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);
        }

        class DLinkedNode
        {
            public int key;
            public int value;
            public DLinkedNode prev;
            public DLinkedNode next;
        }


        private void addNode(DLinkedNode node)
        {
            /**
             * Always add the new node right after head.
             */
            node.prev = head;
            node.next = head.next;

            head.next.prev = node;
            head.next = node;
        }

        private void removeNode(DLinkedNode node)
        {
            /**
             * Remove an existing node from the linked list.
             */
            DLinkedNode prev = node.prev;
            DLinkedNode next = node.next;

            prev.next = next;
            next.prev = prev;
        }

        private void moveToHead(DLinkedNode node)
        {
            /**
             * Move certain node in between to the head.
             */
            removeNode(node);
            addNode(node);
        }

        private DLinkedNode popTail()
        {
            /**
             * Pop the current tail.
             */
            DLinkedNode res = tail.prev;
            removeNode(res);
            return res;
        }

        private Dictionary<int, DLinkedNode> cache = new();
        private int size;
        private int capacity;
        private DLinkedNode head, tail;

        public _00146_LRUCache_Test(int capacity)
        {
            this.size = 0;
            this.capacity = capacity;

            head = new DLinkedNode();
            // head.prev = null;

            tail = new DLinkedNode();
            // tail.next = null;

            head.next = tail;
            tail.prev = head;
        }

        public int get(int key)
        {
            if (!cache.TryGetValue(key, out var node))
                return -1;

            // move the accessed node to the head;
            moveToHead(node);

            return node.value;
        }

        public void put(int key, int value)
        {
            cache.TryGetValue(key, out var node);

            if (node == null)
            {
                DLinkedNode newNode = new DLinkedNode();
                newNode.key = key;
                newNode.value = value;

                cache.Add(key, newNode);
                addNode(newNode);

                ++size;

                if (size > capacity)
                {
                    // pop the tail
                    DLinkedNode tail = popTail();
                    cache.Remove(tail.key);
                    --size;
                }
            }
            else
            {
                // update the value.
                node.value = value;
                moveToHead(node);
            }
        }
    }
}