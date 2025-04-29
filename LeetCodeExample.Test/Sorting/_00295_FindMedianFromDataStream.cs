using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//The median is the middle value in an ordered integer list.If the size of the list is even, there is no middle value, and the median is the mean of the two middle values.

//For example, for arr = [2, 3, 4], the median is 3.
//For example, for arr = [2, 3], the median is (2 + 3) / 2 = 2.5.
//Implement the MedianFinder class:

//MedianFinder() initializes the MedianFinder object.
//void addNum(int num) adds the integer num from the data stream to the data structure.
//double findMedian() returns the median of all elements so far.Answers within 10-5 of the actual answer will be accepted.
/// </summary>
public class _00295_FindMedianFromDataStream
{
    // Two priority queues (optimal). Insert: O(logN). Find: O(1).
    public class MedianFinder
    {
        PriorityQueue<int, int> lo;
        PriorityQueue<int, int> hi;
        public MedianFinder()
        {
            lo = new PriorityQueue<int, int>(Comparer<int>.Create((i1, i2) => i2 - i1));
            hi = new PriorityQueue<int, int>();
        }

        public void AddNum(int num)
        {
            lo.Enqueue(num, num);
            int loHi = lo.Dequeue();
            // Balance.
            hi.Enqueue(loHi, loHi);
            if (lo.Count < hi.Count)
            {
                // Make sure they are balanced or lo has the larger amount of items.
                int hiLo = hi.Dequeue();
                lo.Enqueue(hiLo, hiLo);
            }
        }

        public double FindMedian()
        {
            if (lo.Count > hi.Count)
            {
                return lo.Peek();
            }
            else
            {
                return (lo.Peek() + hi.Peek()) * 0.5f;
            }
        }
    }


    // Using Insertion Sort. Inserts are O(logN) + O(n) = O(n) time.
    public class MedianFinder2
    {
        List<int> lst;

        public MedianFinder2()
        {
            lst = new();
        }

        public void AddNum(int num)
        {
            // Insertion Sort.
            if (lst.Count == 0)
            {
                //Console.WriteLine($"Adding {num} at 0");
                lst.Add(num);
                return;
            }
            else
            {
                int index = BinarySearch(num);
                //Console.WriteLine($"Adding {num} at {index}");
                lst.Insert(index, num);
            }
        }

        public int BinarySearch(int target)
        {
            int l = 0;
            int r = lst.Count - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (lst[mid] == target)
                {
                    return mid;
                }
                else if (target > lst[mid])
                {
                    // Move right.
                    l = mid + 1;
                }
                else
                {
                    // Move left.
                    r = mid - 1;
                }
            }
            return l;
            //return l == 0 ? 0 : l - 1;
        }

        public double FindMedian()
        {
            //for (int i = 0; i < lst.Count; i++) {
            //    Console.Write($"{lst[i]}, ");
            //}
            //Console.WriteLine();
            if (lst.Count % 2 == 0)
            {
                // Even? Average the two middle values.
                return (lst[lst.Count / 2 - 1] + lst[lst.Count / 2]) * 0.5f;
            }
            else
            {
                // Odd, just return the middle value.
                return lst[lst.Count / 2];
            }
        }
    }
}