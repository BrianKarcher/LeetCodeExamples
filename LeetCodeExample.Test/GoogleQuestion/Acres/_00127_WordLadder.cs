using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    A transformation sequence from word beginWord to word endWord using a dictionary wordList is a sequence of words beginWord -> s1 -> s2 -> ... -> sk such that:

    //Every adjacent pair of words differs by a single letter.
    //Every si for 1 <= i <= k is in wordList.Note that beginWord does not need to be in wordList.
    //sk == endWord
    //Given two words, beginWord and endWord, and a dictionary wordList, return the number of words in the shortest transformation sequence from beginWord to endWord, or 0 if no such sequence exists.
    /// </summary>
    public class _00127_WordLadder
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            Dictionary<string, List<string>> adj = new Dictionary<string, List<string>>();
            if (!wordList.Contains(beginWord))
                wordList.Add(beginWord);

            // Initialization
            for (int i = 0; i < wordList.Count; i++)
            {
                adj.Add(wordList[i], new List<string>());
            }

            // TODO : See if we can find a way to reduce this from N^2
            for (int i = 0; i < wordList.Count; i++)
            {
                for (int j = i; j < wordList.Count; j++)
                {
                    if (IsOneDistance(wordList[i], wordList[j]))
                    {
                        // Undirected graph, go in both directions
                        adj[wordList[i]].Add(wordList[j]);
                        adj[wordList[j]].Add(wordList[i]);
                    }
                }
            }

            // Do BFS
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            HashSet<string> visited = new HashSet<string>();
            visited.Add(beginWord);
            int count = 1;
            while (queue.Count != 0)
            {
                count++;
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var word = queue.Dequeue();
                    var adjWords = adj[word];
                    for (int j = 0; j < adjWords.Count; j++)
                    {
                        if (visited.Contains(adjWords[j]))
                            continue;
                        visited.Add(adjWords[j]);
                        if (adjWords[j] == endWord)
                            return count;
                        queue.Enqueue(adjWords[j]);
                    }
                }
            }
            return 0;
        }

        public bool IsOneDistance(string w1, string w2)
        {
            int diffCount = 0;
            for (int i = 0; i < w1.Length; i++)
            {
                if (w1[i] != w2[i])
                {
                    diffCount++;
                    if (diffCount > 1)
                        return false;
                }
            }
            return diffCount == 1;
        }
    }
}