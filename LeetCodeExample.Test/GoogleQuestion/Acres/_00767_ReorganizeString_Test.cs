using LeetCodeExample.Test.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // Given a string s, rearrange the characters of s so that any two adjacent characters are not the same.
    // Return any possible rearrangement of s or return "" if not possible.
    /// </summary>
    public class _00767_ReorganizeString_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = ReorganizeString("aab");
            Assert.AreEqual("aba", answer);

            answer = ReorganizeString("aabbccaallppddd");
            Assert.AreEqual("adadablpcpcadlb", answer);

            answer = ReorganizeString("aaab");
            Assert.AreEqual("", answer);
        }

        public string ReorganizeString(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "";
            Dictionary<char, int> dec = new Dictionary<char, int>();
            //int[] d = new int[26];
            foreach (var c in s)
            {
                //d[c - 'a']++;
                if (!dec.ContainsKey(c))
                    dec.Add(c, 1);
                else
                    dec[c]++;
            }

            //var lst = dec.OrderByDescending(i => i.Value).ToList();

            PriorityQueue<(char Key, int Value)> pq = new PriorityQueue<(char Key, int Value)>(Comparer<(char Key, int Value)>.Create((a, b) =>
            {
                if (b.Value > a.Value)
                    return 1;
                else if (a.Value > b.Value)
                    return -1;
                return 0;
            }));

            //PriorityQueue<KeyVal<char, int>> pq = new PriorityQueue<KeyVal<char, int>>((a, b) =>
            //{
            //    if (b.Value > a.Value)
            //        return 1;
            //    else if (a.Value > b.Value)
            //        return -1;
            //    return 0;
            //});

            foreach (var item in dec)
            {
                //pq.Enqueue(new KeyVal<char, int>(item.Key, item.Value));
                pq.Enqueue((item.Key, item.Value));
            }

            StringBuilder sb = new StringBuilder();

            while (sb.Length < s.Length)
            {
                var first = pq.Dequeue();

                // Next character a repeat?
                if (sb.Length > 0 && sb[sb.Length - 1] == first.Key)
                {
                    // A repeat, and no more other characters to put in its place, this string is invalid
                    if (pq.Count() == 0)
                        return "";

                    var second = pq.Dequeue();
                    sb.Append(second.Key);
                    second.Value = second.Value - 1;

                    if (second.Value > 0)
                        pq.Enqueue(second);

                    pq.Enqueue(first);
                }
                else
                {
                    sb.Append(first.Key);
                    first.Value = first.Value - 1;
                    if (first.Value > 0)
                        pq.Enqueue(first);
                }
            }
            return sb.ToString();

            //char lastChar = lst[0].Key;
            //string rtn = "";
            //rtn += lst[0].Key;
            //lst[0] = new KeyValuePair<char, int>(lst[0].Key, lst[0].Value - 1);

        }
    }
}