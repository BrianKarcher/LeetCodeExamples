using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.DP
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

        int?[] memo = new int?[10_000];

        public int NumSquares(int n)
        {
            List<int> sq = new List<int>();
            // Find perfect square candidates
            for (int i = 1; i * i <= n; i++)
            {
                sq.Add(i * i);
                //Console.WriteLine($"Adding sq {i * i}");
            }
            return dp(n, sq);
        }

        public int dp(int remain, IEnumerable<int> candidates)
        {
            if (remain == 0)
            {
                return 0;
            }
            if (remain < 0)
            {
                return Int32.MaxValue;
            }
            if (memo[remain] != null)
            {
                return memo[remain].Value;
            }
            int count = Int32.MaxValue;
            foreach (int candidate in candidates)
            {
                count = Math.Min(count, dp(remain - candidate, candidates));
            }
            // prevent int overflow
            count = Math.Max(count, count + 1);
            memo[remain] = count;
            //Console.WriteLine($"{remain}, {count}");
            return count;
        }

        public int NumSquares3(int n)
        {
            int[] dp = new int[n + 1];
            Array.Fill(dp, Int32.MaxValue);
            dp[0] = 0;
            int maxSquareIndex = (int)Math.Sqrt(n) + 1;
            int[] squareNums = new int[maxSquareIndex];
            // Find perfect squares.
            for (int i = 1; i < maxSquareIndex; i++)
            {
                squareNums[i] = i * i;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s < maxSquareIndex; s++)
                {
                    if (i < squareNums[s])
                        break;
                    dp[i] = Math.Min(dp[i], dp[i - squareNums[s]] + 1);
                }
            }
            return dp[n];
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

        // Time Complexity: O(n ^ h/2)
        // where h is the maximal number of recursion that could happen. As one might notice, the above formula actually resembles the formula to calculate the number of nodes in a complete N-ary tree. Indeed, the trace of recursive calls in the algorithm form a N-ary tree, where N is the number of squares in square_nums, i.e. \sqrt{n} 
        // . In the worst case, we might have to traverse the entire tree to find the solution.
        // Space Complexity: O(sqrt(n) ^ h)
        // We keep a list of square_nums, which is of \sqrt{n} ​
        //  size.In addition, we would need additional space for the recursive call stack.But as we will learn later, the size of the call track would not exceed 4.
        public int NumSquares2(int n)
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