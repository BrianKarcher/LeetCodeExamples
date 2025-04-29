using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //There is a new alien language that uses the English alphabet.However, the order among the letters is unknown to you.

    //You are given a list of strings words from the alien language's dictionary, where the strings in words are sorted lexicographically by the rules of this new language.

    //Return a string of the unique letters in the new alien language sorted in lexicographically increasing order by the new language's rules. If there is no solution, return "". If there are multiple solutions, return any of them.

    //A string s is lexicographically smaller than a string t if at the first letter where they differ, the letter in s comes before the letter in t in the alien language.If the first min(s.length, t.length) letters are the same, then s is smaller if and only if s.length<t.length.

    //Example 1:


    //Input: words = ["wrt", "wrf", "er", "ett", "rftt"]
    //Output: "wertf"
    //Example 2:

    //Input: words = ["z","x"]
    //    Output: "zx"
    //Example 3:

    //Input: words = ["z","x","z"]
    //    Output: ""
    //Explanation: The order is invalid, so return "".
    /// </summary>
    public class G_00269_AlienDictionary_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        // maps the topological ordering (what letter goes after another) - sort of like a dependency list
        Dictionary<char, List<char>> adjList = new Dictionary<char, List<char>>();
        // Doesn't exist = WHITE. Exists but false = GRAY, Exists but true = BLACK
        Dictionary<char, bool> seen = new Dictionary<char, bool>();
        //List<char> finalList = new List<char>();
        string finalList = "";

        public string AlienOrder(string[] words)
        {
            //foreach (var word in words) {
            //    foreach (var c in word) {
            //        adjList.TryAdd(
            //    }
            //}

            // Step 0: Put all unique letters into reverseAdjList as keys.
            foreach (string word in words)
            {
                foreach (char c in word)
                {
                    adjList.TryAdd(c, new List<char>());
                }
            }

            // Compare the words to find the ordering
            // A word is only comparable to the word directly after it
            for (int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];
                // Skip if word 2 is a prefix for word 1
                if (word1.Length > word2.Length && word1.StartsWith(word2))
                    return "";
                // Find the difference
                for (int c = 0; c < Math.Min(word1.Length, word2.Length); c++)
                {
                    if (word1[c] != word2[c])
                    {
                        // Doing a reverse Adjacency List since otherwise the order prints backwards in DFS
                        //if (!adjList.ContainsKey(word2[c]))
                        //    adjList.Add(word2[c], new List<char>());
                        // Add the relationship
                        //Console.WriteLine($"Adding character relationship {word1[c]} -> {word2[c]}");
                        adjList[word2[c]].Add(word1[c]);
                        // Every word compare has only one actionable relationship for the "dictionary"
                        break;
                    }
                }
            }

            //Console.WriteLine(adjList.ToString());
            foreach (var ch in adjList.Keys)
            {
                //Console.WriteLine($"dfs on key {ch}");
                if (!dfs(ch))
                    return "";
            }
            return finalList;
        }

        bool dfs(char c)
        {
            // Gray status = cycle loop = failure
            if (seen.ContainsKey(c))
            {
                return seen[c];
            }

            // Turn it GRAY
            seen.TryAdd(c, false);

            //if (adjList.ContainsKey(c)) {
            foreach (var ch in adjList[c])
            {
                if (!dfs(ch))
                    return false; // bubble up a cycle failure
            }
            //}

            finalList += c;
            // Turn it BLACK
            seen[c] = true;
            return true;
        }
    }
}