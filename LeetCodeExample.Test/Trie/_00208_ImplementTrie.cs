using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//A trie(pronounced as "try") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings.There are various applications of this data structure, such as autocomplete and spellchecker.

//Implement the Trie class:

//Trie() Initializes the trie object.
//void insert(String word) Inserts the string word into the trie.
//boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
//boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.
/// </summary>
public class _00208_ImplementTrie
{
    public class Trie
    {
        public class Node
        {
            public Dictionary<char, Node> Children = new();
            public char ch;
            public bool IsWord;
        }

        Node root;

        public Trie()
        {
            root = new Node();
        }

        public void Insert(string word)
        {
            Node current = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!current.Children.TryGetValue(word[i], out Node child))
                {
                    child = new Node();
                    child.ch = word[i];
                    current.Children.Add(word[i], child);
                }
                current = child;
            }
            current.IsWord = true;
        }

        public bool Search(string word)
        {
            (_, bool IsWord) = SearchPrefix(word);
            return IsWord;
        }

        public bool StartsWith(string prefix)
        {
            (bool IsFound, _) = SearchPrefix(prefix);
            return IsFound;
        }

        private (bool IsFound, bool IsWord) SearchPrefix(string prefix)
        {
            Node current = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                if (!current.Children.TryGetValue(prefix[i], out Node child))
                {
                    return (false, false);
                }
                current = child;
            }
            return (true, current.IsWord);
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}