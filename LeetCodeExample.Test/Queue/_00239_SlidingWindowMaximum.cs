using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right.You can only see the k numbers in the window. Each time the sliding window moves right by one position.

    //Return the max sliding window.
    /// </summary>
    public class _00239_SlidingWindowMaximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            // val: index
            LinkedList<int> lst = new LinkedList<int>();
            List<int> res = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                // Remove first element if the window has moved past it
                if (lst.Count != 0 && lst.First() == i - k)
                {
                    lst.RemoveFirst();
                }

                // The newly added number munches smaller ones, ultimately making this a monotomic
                // decreasing "queue".
                while (lst.Count != 0 && nums[lst.Last.Value] < nums[i])
                {
                    lst.RemoveLast();
                }
                lst.AddLast(i);

                if (i >= k - 1)
                    res.Add(nums[lst.First.Value]);
            }
            return res.ToArray();
        }

        public int[] MaxSlidingWindow2(int[] nums, int k)
        {
            //PriorityQueue<int> pq = new PriorityQueue<int>((i1, i2) => 
            //                                               {
            //                                                   if (i1 > i2) return -1;
            //                                                   else if (i1 == i2) return 0;
            //                                                   return 1;
            //                                                });

            PriorityQueue<(int index, int val)> pq = new PriorityQueue<(int index, int val)>((i1, i2) =>
            {
                if (i1.val > i2.val) return -1;
                else if (i1.val == i2.val) return 0;
                return 1;
            });

            // Kickstart the pq
            for (int i = 0; i < k; i++)
            {
                //Console.WriteLine($"Queueing up {nums[i]}");
                pq.Enqueue((i, nums[i]));
            }

            List<int> res = new List<int>();
            //Console.WriteLine($"Adding to list {pq.Peek()}");
            res.Add(pq.Peek().val);
            int left = 1;
            int right = k;

            while (right < nums.Length)
            {
                // Pop off any older numbers, ie the window has passed
                while (pq.Count() != 0 && pq.Peek().index < left)
                {
                    pq.Dequeue();
                }

                //Console.WriteLine($"Queueing up {nums[right]}");
                pq.Enqueue((right, nums[right]));
                //Console.WriteLine($"Adding to list {nums[right]}");
                res.Add(pq.Peek().val);

                left++;
                right++;
            }
            return res.ToArray();
        }
    }
}