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
        public bool WordBreak(string s, IList<string> wordDict)
        {
            TrieNode root = new(' ');
            // Build trie tree.
            foreach (string word in wordDict)
            {
                TrieNode iter = root;
                foreach (char c in word)
                {
                    if (!iter.children.ContainsKey(c))
                    {
                        iter.children.Add(c, new TrieNode(c));
                    }
                    iter = iter.children[c];
                }
                iter.IsWord = true;
            }

            //PrintTree(root, 0);

            // Determines whether a word can start at the given i
            bool[] canStart = new bool[s.Length];
            canStart[0] = true;
            for (int i = 0; i < s.Length; i++)
            {
                if (!canStart[i])
                {
                    continue;
                }
                // For every possible starting position, check against the dictionary 
                // for possible valid words for either the end, or new starting points.
                int j = i;
                root.children.TryGetValue(s[j], out TrieNode iter);
                while (j < s.Length && iter != null)
                {
                    /*if (iter != null)
                        Console.WriteLine($"Checking char {iter.c}");*/
                    if (iter.IsWord)
                    {
                        // Found the word that finishes the sequence?
                        if (j == s.Length - 1)
                        {
                            return true;
                        }
                        // Next word can stat after the end of this character.
                        canStart[j + 1] = true;
                    }
                    j++;
                    if (j == s.Length)
                    {
                        break;
                    }
                    iter.children.TryGetValue(s[j], out iter);
                }
            }
            return false;
        }

        public class TrieNode
        {
            public char c;
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public bool IsWord;
            public TrieNode(char c)
            {
                this.c = c;
            }
        }

        // Debugging purposes.
        public void PrintTree(TrieNode node, int index)
        {
            if (node == null)
                return;

            Console.WriteLine(index + node.c.ToString());
            foreach (var child in node.children)
            {
                PrintTree(child.Value, index + 1);
            }
        }


        /// <summary>
        /// /////////////////////////////////
        /// </summary>

        class Node
        {
            public char ch;
            public bool isWord = false;
            public Dictionary<char, Node> children = new Dictionary<char, Node>();
        }

        Node Trie = new Node();

        public bool WordBreak2(string s, IList<string> wordDict)
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