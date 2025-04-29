using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You have a lock in front of you with 4 circular wheels.Each wheel has 10 slots: '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'. The wheels can rotate freely and wrap around: for example we can turn '9' to be '0', or '0' to be '9'. Each move consists of turning one wheel one slot.
    //The lock initially starts at '0000', a string representing the state of the 4 wheels.
    //You are given a list of deadends dead ends, meaning if the lock displays any of these codes, the wheels of the lock will stop turning and you will be unable to open it.
    //Given a target representing the value of the wheels that will unlock the lock, return the minimum total number of turns required to open the lock, or -1 if it is impossible.
    /// </summary>
    public class _00752_OpenTheLock
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = OpenLock(new string[] { "0201", "0101", "0102", "1212", "2002" }, "0202");
            Assert.AreEqual(6, answer);
            answer = OpenLock(new string[] { "8888" }, "0009");
            Assert.AreEqual(1, answer);
            answer = OpenLock(new string[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" }, "8888");
            Assert.AreEqual(-1, answer);
            answer = OpenLock(new string[] { "0000" }, "8888");
            Assert.AreEqual(-1, answer);
        }

        //public int OpenLock(string[] deadends, string target)
        //{
        //    if (target == "0000")
        //        return 0;

        //    //var targetChars = target.ToCharArray().Select(i => (int)(i - '0')).ToArray();
        //    var targetChars = target.ToCharArray();

        //    HashSet<(char, char, char, char)> visited = new HashSet<(char, char, char, char)>();
        //    // Consider deadends to be already visited nodes
        //    for (int i = 0; i < deadends.Length; i++)
        //    {
        //        var chars = deadends[i].ToCharArray();
        //        visited.Add((chars[0], chars[1], chars[2], chars[3]));
        //    }
        //    int steps = 0;
        //    //char a = 'a';
        //    Queue<(char, char, char, char)> queue = new Queue<(char, char, char, char)>();
        //    queue.Enqueue(('0', '0', '0', '0'));

        //    while (queue.Any())
        //    {
        //        // Do a BFS, incrementing the steps each row we go
        //        int size = queue.Count;
        //        // Do an entire "breadth" in one swoop
        //        for (int i = 0; i < size; i++)
        //        {
        //            var current = queue.Dequeue();
        //            if (visited.Contains(current))
        //                continue;

        //            // Found target?
        //            if (current.Item1 == targetChars[0] && current.Item2 == targetChars[1] && current.Item3 == targetChars[2]
        //                && current.Item4 == targetChars[3])
        //                return steps;

        //            // Add each possible combination of a child
        //            queue.Enqueue((CheckBounds((char)(current.Item1 + 1)), current.Item2, current.Item3, current.Item4));
        //            queue.Enqueue((CheckBounds((char)(current.Item1 - 1)), current.Item2, current.Item3, current.Item4));
        //            queue.Enqueue((current.Item1, CheckBounds((char)(current.Item2 + 1)), current.Item3, current.Item4));
        //            queue.Enqueue((current.Item1, CheckBounds((char)(current.Item2 - 1)), current.Item3, current.Item4));
        //            queue.Enqueue((current.Item1, current.Item2, CheckBounds((char)(current.Item3 + 1)), current.Item4));
        //            queue.Enqueue((current.Item1, current.Item2, CheckBounds((char)(current.Item3 - 1)), current.Item4));
        //            queue.Enqueue((current.Item1, current.Item2, current.Item3, CheckBounds((char)(current.Item4 + 1))));
        //            queue.Enqueue((current.Item1, current.Item2, current.Item3, CheckBounds((char)(current.Item4 - 1))));
        //            visited.Add(current);
        //        }
        //        steps = steps + 1;
        //    }

        //    return -1;
        //}

        //public char CheckBounds(char c)
        //{
        //    // Loop around
        //    if (c > '9')
        //        return '0';
        //    if (c < '0')
        //        return '9';
        //    return c;
        //}

        //        Time Complexity: O(N^2 * A^N + D)O(N^2 ∗A^N + D) where A
        //    A is the number of digits in our alphabet, N is the number of digits in the lock, and D is the size of deadends.We might visit every lock combination, plus we need to instantiate our set dead. When we visit every lock combination, we spend O(N^2)O(N
        //2
        // ) time enumerating through and constructing each node.

        //Space Complexity: OA^N + D)O(A^N +D), for the queue and the set dead.
        public int OpenLock(String[] deadends, String target)
        {
            HashSet<String> dead = new HashSet<String>();
            foreach (String d in deadends) dead.Add(d);

            Queue<String> queue = new Queue<string>();
            queue.Enqueue("0000");
            queue.Enqueue(null);

            HashSet<String> seen = new HashSet<string>();
            seen.Add("0000");

            int depth = 0;
            while (queue.Any())
            {
                String node = queue.Dequeue();
                if (node == null)
                {
                    depth++;
                    //if (queue.Peek() != null)
                    if (queue.Any())
                        queue.Enqueue(null);
                }
                else if (node.Equals(target))
                {
                    return depth;
                }
                else if (!dead.Contains(node))
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        for (int d = -1; d <= 1; d += 2)
                        {
                            int y = ((node[i] - '0') + d + 10) % 10;
                            // Substring has O(N) time complexity - plays into the complexity of the whole method.
                            String nei = node.Substring(0, i) + ("" + y) + node.Substring(i + 1);
                            if (!seen.Contains(nei))
                            {
                                seen.Add(nei);
                                queue.Enqueue(nei);
                            }
                        }
                    }
                }
            }
            return -1;
        }
    }
}