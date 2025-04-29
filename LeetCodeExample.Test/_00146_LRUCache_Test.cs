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
        //void put(int key, int value) Update the value of the key if the key exists.Otherwise, add the key-value pair to the cache.If the number of keys exceeds the capacity from this operation, evict the least recently used key.
        //   The functions get and put must each run in O(1) average time complexity.
    /// </summary>
    public class LRUCache
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        private Dictionary<int, LinkedListNode<(int key, int val)>> _dict;
        private LinkedListNode<(int key, int val)> _head;
        private LinkedListNode<(int key, int val)> _tail;
        // We store the key and the val into the LinkedList so we can remove the tail from the dictionary in O(1)
        private LinkedList<(int key, int val)> _list;
        private int _cap;

        public LRUCache(int capacity)
        {
            _cap = capacity;
            _list = new LinkedList<(int key, int val)>();
            _dict = new Dictionary<int, LinkedListNode<(int key, int val)>>();
            // The dummy head and tail help to address edge cases and reduces the amount of null checking and 
            // if statements at very little space cost.
            // Dummy head
            _head = _list.AddFirst((-1, -1));
            // Dummy tail
            _tail = _list.AddLast((-1, -1));

        }

        public int Get(int key)
        {
            if (!_dict.ContainsKey(key))
                return -1;
            var node = _dict[key];
            MoveToTop(node);
            return _dict[key].Value.val;
        }

        public void Put(int key, int value)
        {
            if (_dict.ContainsKey(key))
            {
                // Just do an update if the key already exists
                var n = _dict[key];
                n.Value = (key, value);
                MoveToTop(n);
                return;
            }
            // Add new value to the head of the LinkedList.
            var node = _list.AddAfter(_head, (key, value));
            _dict.Add(key, node);

            // Need to subtract the dummy head and dummy tail from the count
            if (_list.Count - 2 > _cap)
            {
                var tail = _tail.Previous;
                _list.Remove(tail);
                _dict.Remove(tail.Value.key);
            }
        }

        public void MoveToTop(LinkedListNode<(int key, int val)> node)
        {
            // Move node to the head of the LinkedList.
            _list.Remove(node);
            _list.AddAfter(_head, node);
        }
    }
}