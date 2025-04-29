using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given an integer n, return the least number of perfect square numbers that sum to n.
    // A perfect square is an integer that is the square of an integer; in other words, it is the product of some integer with itself.For example, 1, 4, 9, and 16 are perfect squares while 3 and 11 are not.
    /// </summary>
    public class _00279_TwoSum_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = NumSquares(12);
            Assert.AreEqual(3, answer);

            answer = NumSquares(13);
            Assert.AreEqual(2, answer);

            answer = NumSquares(4);
            Assert.AreEqual(1, answer);
        }

        //public int NumSquares(int n)
        //{
        //    List<int> perfectSquares = new List<int>();

        //    int currentPs = 1;
        //    int psIndex = 1;
        //    while (currentPs < n)
        //    {
        //        currentPs = psIndex * psIndex;
        //        perfectSquares.Add(currentPs);
        //        psIndex++;
        //    }

        //    Queue<int> queue = new Queue<int>();
        //    // Doing a BFS, keeping track of how many levels deep we are
        //    int level = 0;
        //    queue.Enqueue(n);
        //    while (queue.Any())
        //    {
        //        level = level + 1;
        //        int size = queue.Count;
        //        for (int i = 0; i < size; i++)
        //        {
        //            int cur = queue.Dequeue();
        //            for (int j = 0; j < perfectSquares.Count; j++)
        //            {
        //                // Create "children" that is simply every single possibility at this level
        //                int child = cur - perfectSquares[j];
        //                if (child < 0)
        //                    continue;
        //                if (child == 0)
        //                    return level;
        //                queue.Enqueue(child);
        //            }
        //        }
        //    }

        //    return level;
        //}

        //Time complexity: \mathcal{O}( \frac{\sqrt{n}^{h+1} - 1}{\sqrt{n} - 1} ) = \mathcal{O}(n^{\frac{h}{2}})O( 
//        n
//​
// −1
//n
//​
  
//h+1
// −1
//​
// )=O(n
//2
//h
//​
 
// ) where h is the height of the N-ary tree.One can see the detailed explanation on the previous Approach #3.

//Space complexity: \mathcal{ O}\Big((\sqrt{ n})^h\Big)O((
//n
//​
// )
//h
// ), which is also the maximal number of nodes that can appear at the level h.As one can see, though we keep a list of square_nums, the main consumption of the space is the queue variable, which keep track of the remainders to visit for a given level of N-ary tree.
        public int NumSquares(int n)
        {
            List<int> perfectSquares = new List<int>();

            int currentPs = 1;
            int psIndex = 1;
            while (currentPs < n)
            {
                currentPs = psIndex * psIndex;
                perfectSquares.Add(currentPs);
                psIndex++;
            }

            // Using HashSets to remove the redundancy of remainders.
            HashSet<int> queue = new HashSet<int>();
            // Doing a BFS, keeping track of how many levels deep we are
            int level = 0;
            queue.Add(n);
            while (queue.Any())
            {
                level = level + 1;
                HashSet<int> next_queue = new HashSet<int>();

                int size = queue.Count;
                foreach (var cur in queue)
                {
                    for (int j = 0; j < perfectSquares.Count; j++)
                    {
                        // Create "children" that is simply every single possibility at this level
                        int child = cur - perfectSquares[j];
                        if (child < 0)
                            continue;
                        if (child == 0)
                            return level;
                        next_queue.Add(child);
                    }
                }
                queue = next_queue;
            }

            return level;
        }
    }
}