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

        /*public int[] MaxSlidingWindow(int[] nums, int k) {
        PriorityQueue<int> pq = new PriorityQueue<int>((i1, i2) => 
                                                       {
                                                           if (i1 > i2) return -1;
                                                           else if (i1 == i2) return 0;
                                                           return 1;
                                                        });
        
        //PriorityQueue<(int index, int val)> pq = new PriorityQueue<(int index, int val)>((i1, i2) => 
        //                                               {
        //                                                   if (i1.val > i2.val) return -1;
        //                                                   else if (i1.val == i2.val) return 0;
        //                                                   return 1;
        //                                                });
        
        // Kickstart the pq
        for (int i = 0; i < k; i++) {     
            Console.WriteLine($"Queueing up {nums[i]}");
            pq.Enqueue(nums[i]);
            //pq.Enqueue((i, nums[i]));
        }
        
        List<int> res = new List<int>();
        Console.WriteLine($"Adding to list {pq.Peek()}");
        res.Add(pq.Peek());
        int left = 1;
        int right = k;
        // Queue's left moves at a different rate than the real left
        // queue left only moves when its item is the max item in the queue and the queue has moved
        // past this index already
        int queuesLeft = 0;
        
        // We've already processed the first item, start at index 1
        //for (int i = 1; i + k < nums.Length; i++) {
        while (right < nums.Length) {
            //if (nums[left - 1] < pq.Peek().val) {
                // Element we are removing is smaller than the largest element, just remove
                // every element of this size
                //pq.RemoveAll(i => i.val == nums[left - 1]);
            //}
            //else {
                // Element we are removing is the same size or greater than the biggest item in the pq
                // Just remove this index from the queue
                //pq.RemoveAll(i => i.index == left - 1);
            //}
            
            // Move the queue's left index closest to the left as possible
            while (queuesLeft < left && nums[queuesLeft] == pq.Peek()) {
                var item = pq.Peek();
                Console.WriteLine($"Removing item {item} from queue at index {queuesLeft}");
                pq.Dequeue();
                queuesLeft++;
            }
        
            // First, remove the previous index from the queue
            //pq.RemoveAll(i => i ==    
            //pq.Enqueue((right, nums[right]));
            Console.WriteLine($"Queueing up {nums[right]}");
            pq.Enqueue(nums[right]);
            Console.WriteLine($"Adding to list {nums[right]}");
            res.Add(pq.Peek());
            
            left++;
            right++;
        }
        return res.ToArray();
    }*/
    }
}