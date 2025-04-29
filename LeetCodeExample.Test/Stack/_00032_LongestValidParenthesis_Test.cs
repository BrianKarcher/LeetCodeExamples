using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given a string containing just the characters '(' and ')', find the length of the longest valid(well-formed) parentheses substring.
    /// </summary>
    public class _00032_LongestValidParenthesis_Test
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

        // O(n)
        public int LongestValidParentheses(String s)
        {
            int maxans = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxans = Math.Max(maxans, i - stack.Peek());
                    }
                }
            }
            return maxans;
        }

        // TLE - uses stack buckets for each character
        //public int LongestValidParentheses(string s)
        //{
        //    //Dictionary<int, Stack<char> stack> = new Dictionary<int, Stack<char> stack>();
        //    List<(int Index, Stack<char> Stack)> lst = new List<(int index, Stack<char> stack)>(s.Length);
        //    int[] count = new int[s.Length];
        //    //Stack<char> stack = new Stack<char>();
        //    //int currentValidCount = 0;
        //    int maxValidCount = 0;
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        char ch = s[i];
        //        List<int> indexesToRemove = new List<int>();
        //        for (int j = 0; j < lst.Count; j++)
        //        {
        //            if (ch == ')')
        //            {
        //                if (lst[j].Stack.Count == 0 || lst[j].Stack.Peek() != '(')
        //                {
        //                    // Stack has become invalidated
        //                    //Console.WriteLine($"Removing index {lst[j].Index}");
        //                    indexesToRemove.Add(j);
        //                    continue;
        //                }
        //                // Pop off the '('
        //                lst[j].Stack.Pop();
        //                count[lst[j].Index] += 2;
        //                if (lst[j].Stack.Count == 0)
        //                    maxValidCount = Math.Max(maxValidCount, count[lst[j].Index]);
        //            }
        //            else
        //                lst[j].Stack.Push('(');

        //        }
        //        // Remove invalidated indexes so they are no longer searched
        //        // Do it backwards so the indexes remain intact for the rest of the removal
        //        for (int r = indexesToRemove.Count - 1; r >= 0; r--)
        //            lst.RemoveAt(indexesToRemove[r]);

        //        if (ch == '(')
        //        {
        //            // Add this new bucket
        //            lst.Add((i, new Stack<char>()));
        //            lst[lst.Count - 1].Stack.Push('(');
        //        }
        //    }
        //    return maxValidCount;
        //}

        //public int LongestValidParentheses(string s)
        //{
        //    int max = 0;
        //    Stack<char> stack = new Stack<char>();
        //    for (int i = 0; i < s.Length; i++)
        //    {

        //    }
        //}
    }
}