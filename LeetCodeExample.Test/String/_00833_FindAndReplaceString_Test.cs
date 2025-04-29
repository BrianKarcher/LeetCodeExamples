using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given a 0-indexed string s that you must perform k replacement operations on.The replacement operations are given as three 0-indexed parallel arrays, indices, sources, and targets, all of length k.


    //    To complete the ith replacement operation:


    //    Check if the substring sources[i] occurs at index indices[i] in the original string s.
    //If it does not occur, do nothing.
    //    Otherwise if it does occur, replace that substring with targets[i].
    //For example, if s = "abcd", indices[i] = 0, sources[i] = "ab", and targets[i] = "eee", then the result of this replacement will be "eeecd".


    //    All replacement operations must occur simultaneously, meaning the replacement operations should not affect the indexing of each other. The testcases will be generated such that the replacements will not overlap.


    //    For example, a testcase with s = "abc", indices = [0, 1], and sources = ["ab", "bc"] will not be generated because the "ab" and "bc" replacements overlap.
    //Return the resulting string after performing all replacement operations on s.


    //    A substring is a contiguous sequence of characters in a string.
    /// </summary>
    public class _00833_FindAndReplaceString_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            List<(int i, string s, string t)> rep = new List<(int, string, string)>();
            for (int i = 0; i < indices.Length; i++)
            {
                rep.Add((indices[i], sources[i], targets[i]));
            }
            var orderedRep = rep.OrderBy(i => i.i).ToList();

            // Build new string
            string rtn = "";
            // Index in the original string
            int index = 0;
            for (int i = 0; i < orderedRep.Count; i++)
            {
                // Validate
                string cmp = s.Substring(orderedRep[i].i, orderedRep[i].s.Length);
                if (cmp != orderedRep[i].s)
                {
                    continue;
                }
                // Add what is before this indice
                rtn += s.Substring(index, orderedRep[i].i - index);
                // Add the target
                rtn += orderedRep[i].t;
                // Increment the index by the SOURCE length
                index = orderedRep[i].i + orderedRep[i].s.Length;
            }
            // Copy whatever is left over
            rtn += s.Substring(index);
            return rtn;
        }
    }
}