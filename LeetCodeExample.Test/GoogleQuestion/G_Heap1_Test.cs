using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class G_Heap1_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void Test()
        //{
        //    Main(new string[] { "3", "sam 99912222", "tom 11122222", "harry 12299933", "sam", "edward", "harry" });
        //    //Assert.AreEqual(0, answer[0]);

        //}

        static void Main3(String[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            //int count = Int32.Parse(args[0]);
            int count = Int32.Parse(Console.ReadLine());
            Heap heap = new Heap();

            for (int i = 0; i < count; i++)
            {
                string line = Console.ReadLine();
                if (line == "3")
                {
                    Console.WriteLine(heap.Print());
                    continue;
                }
                string[] split = line.Split(' ');
                if (split[0] == "1")
                {
                    heap.Insert(Int32.Parse(split[1]));
                }
                else if (split[0] == "2")
                {
                    heap.Remove(Int32.Parse(split[1]));
                }
            }
        }

        public class Heap
        {
            private List<int> heap;
            public Heap()
            {
                heap = new List<int>();
            }

            // Helper functions - standard Heap stuff
            // Get left child
            public int LeftChildIndex(int index) => index * 2 + 1;
            public int RightChildIndex(int index) => index * 2 + 2;
            public int GetParentIndex(int index) => (index - 1) / 2;

            public bool HasLeftChild(int index) => LeftChildIndex(index) < heap.Count;
            public bool HasRightChild(int index) => RightChildIndex(index) < heap.Count;
            public bool HasParent(int index) => GetParentIndex(index) >= 0;

            private int LeftChild(int index) => heap[LeftChildIndex(index)];
            private int RightChild(int index) => heap[RightChildIndex(index)];
            private int Parent(int index) => heap[GetParentIndex(index)];

            public int Print()
            {
                return heap[0];
            }

            public void Insert(int val)
            {
                // Insert at the bottom-left of the heap
                heap.Add(val);
                // Need to bubble up until the parent is smaller than the value
                int currentIndex = heap.Count - 1;
                while (HasParent(currentIndex) && Parent(currentIndex) > heap[currentIndex])
                {
                    // Swap values
                    swap(GetParentIndex(currentIndex), currentIndex);
                    currentIndex = GetParentIndex(currentIndex);
                }
            }

            public void Remove(int val)
            {
                // The array is not guaranteed to be in order, cannot do a binary search.
                // Need to traverse the whole heap until we find the value, no choice. Time: O(n).
                int removeIdx = -1;
                for (int i = 0; i < heap.Count; i++)
                {
                    if (heap[i] == val)
                    {
                        removeIdx = i;
                        break;
                    }
                }

                // To remove this item we will replace it with the last item in the heap
                heap[removeIdx] = heap[heap.Count - 1];
                // Then remove the last item (thus removing this item)
                heap.RemoveAt(heap.Count - 1);

                int currentIdx = removeIdx;
                // Then bubble down from this index so the heap is valid
                // Only need to check for a left child. If no left child, there will be no right child.
                while (HasLeftChild(currentIdx))
                {
                    int smallerChildIndex = LeftChildIndex(currentIdx);
                    if (HasRightChild(currentIdx) && RightChild(currentIdx) < LeftChild(currentIdx))
                    {
                        smallerChildIndex = RightChildIndex(currentIdx);
                    }

                    if (heap[currentIdx] < heap[smallerChildIndex])
                        break;

                    // Do the swap
                    swap(smallerChildIndex, currentIdx);
                    currentIdx = smallerChildIndex;
                }
            }

            private void swap(int idx1, int idx2)
            {
                int temp = heap[idx1];
                heap[idx1] = heap[idx2];
                heap[idx2] = temp;
            }
        }

    }
}