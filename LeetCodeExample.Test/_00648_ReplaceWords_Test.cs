using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    In English, we have a concept called root, which can be followed by some other word to form another longer word - let's call this word successor. For example, when the root "an" is followed by the successor word "other", we can form a new word "another".
    //Given a dictionary consisting of many roots and a sentence consisting of words separated by spaces, replace all the successors in the sentence with the root forming it.If a successor can be replaced by more than one root, replace it with the root that has the shortest length.
    //Return the sentence after the replacement.
    /// </summary>
    public class _00648_ReplaceWords_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = ReplaceWords(new List<string> { "cat", "bat", "rat" }, "the cattle was rattled by the battery");
            Assert.AreEqual("the cat was rat by the bat", answer);

            answer = ReplaceWords(new List<string> { "a", "b", "c" }, "aadsfasf absbs bbab cadsfafs");
            Assert.AreEqual("a a b c", answer);

            answer = ReplaceWords(new List<string> { "a", "aa", "aaa", "aaaa" }, "a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa");
            Assert.AreEqual("a a a a a a a a bbb baba a", answer);

            answer = ReplaceWords(new List<string> { "catt", "cat", "bat", "rat" }, "the cattle was rattled by the battery");
            Assert.AreEqual("the cat was rat by the bat", answer);

            answer = ReplaceWords(new List<string> { "ac", "ab" }, "it is abnormal that this solution is accepted");
            Assert.AreEqual("it is ab that this solution is ac", answer);
        }

        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            var root = BuildTrie(dictionary);

            var words = sentence.Split(' ');
            List<string> newSentence = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                newSentence.Add(FindWord(root, 0, words[i]));
            }
            return String.Join(' ', newSentence.ToArray());
        }

        public TrieNode BuildTrie(IList<string> dictionary)
        {
            TrieNode root = new TrieNode();

            for (int i = 0; i < dictionary.Count; i++)
            {
                TrieNode current = root;
                // Build the trie one letter at a time.
                for (int k = 0; k < dictionary[i].Length; k++)
                {
                    char letter = dictionary[i][k];
                    if (!current.children.ContainsKey(letter))
                        current.children.Add(letter, new TrieNode());
                    // Check for the end of a word, and set flag
                    if (k == dictionary[i].Length - 1)
                    {
                        current.children[letter].IsWord = true;
                        current.children[letter].Word = dictionary[i];
                    }
                    current = current.children[letter];
                }
            }
            return root;
        }

        public string FindWord(TrieNode node, int i, string word)
        {
            if (node.IsWord)
                return node.Word;

            // Not found, return the word
            if (i == word.Length)
                return word;

            // Next letter not found, return word
            if (!node.children.ContainsKey(word[i]))
                return word;

            TrieNode newNode = node.children[word[i]];

            return FindWord(newNode, i + 1, word);
        }

        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public bool IsWord;
            public string Word;
        }
    }
}