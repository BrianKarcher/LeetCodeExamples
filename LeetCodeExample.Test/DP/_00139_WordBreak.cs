using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.
    // Note that the same word in the dictionary may be reused multiple times in the segmentation.
    /// </summary>
    public class _00139_WordBreak
    {
        // Would be faster to store the dictionary in a Trie, change to a Trie when I have time
        //HashSet<string> Dict = new HashSet<string>();
        class Node
        {
            public char ch;
            public bool isWord = false;
            public Dictionary<char, Node> children = new Dictionary<char, Node>();
        }

        Node Trie = new Node();

        public bool WordBreak(string s, IList<string> wordDict)
        {
            foreach (var word in wordDict)
            {
                Node trie = Trie;
                foreach (char c in word)
                {
                    if (!trie.children.ContainsKey(c))
                        trie.children.Add(c, new Node());
                    trie = trie.children[c];
                }
                trie.isWord = true;
                //Dict.Add(word);
            }

            return dp(s, 0);
        }

        Dictionary<int, bool> memo = new Dictionary<int, bool>();

        bool dp(string s, int start)
        {
            // base case
            if (start >= s.Length)
                return true;

            if (memo.ContainsKey(start))
                return memo[start];

            // Max size of a word in the dictionary is 20 characters
            //string sub = "";
            var trie = Trie;
            for (int i = 0; i < 20 && i + start < s.Length; i++)
            {
                char ch = s[start + i];
                if (!trie.children.ContainsKey(ch))
                    break;
                trie = trie.children[ch];
                if (!trie.isWord)
                    continue;

                //string sub = s.Substring(start, i);
                //sub += s[start + i - 1];
                //Console.WriteLine($"Sub: {sub}");
                //if (!Dict.Contains(sub))
                //    continue;
                bool res = dp(s, start + i + 1);
                if (res)
                {
                    memo.Add(start, true);
                    return true;
                }
            }
            memo.Add(start, false);
            return false;
        }
    }
}