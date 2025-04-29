using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
   // In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order.The order of the alphabet is some permutation of lowercase letters.
   // Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographically in this alien language.
    /// </summary>
    public class _0953_AlienDictionary_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = IsAlienSorted2(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz");
            Assert.AreEqual(true, answer); // As 'h' comes before 'l' in this language, then the sequence is sorted.

            answer = IsAlienSorted2(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz");
            Assert.AreEqual(false, answer); // As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.

            answer = IsAlienSorted2(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz");
            Assert.AreEqual(false, answer); // The first three characters "app" match, and the second string is shorter (in size.) According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character
        }

        // Online
        public bool IsAlienSorted2(string[] words, string order)
        {
            // USE AN INT ARRAY - NOT A HASHMAP - FOR LETTER COMPARISONS!!!!!!!!
            int[] orderMap = new int[26];
            for (int i = 0; i < order.Length; i++)
            {
                orderMap[order[i] - 'a'] = i;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {

                for (int j = 0; j < words[i].Length; j++)
                {
                    // If we do not find a mismatch letter between words[i] and words[i + 1],
                    // we need to examine the case when words are like ("apple", "app").
                    if (j >= words[i + 1].Length) return false;

                    if (words[i][j] != words[i + 1][j])
                    {
                        int currentWordChar = words[i][j] - 'a';
                        int nextWordChar = words[i + 1][j] - 'a';
                        if (orderMap[currentWordChar] > orderMap[nextWordChar]) return false;
                        // if we find the first different letter and they are sorted,
                        // then there's no need to check remaining letters
                        else break;
                    }
                }
            }

            return true;
        }


        //public bool IsAlienSorted(string[] words, string order)
        //{
        //    if (words.Length == 1)
        //        return true;

        //    // Quick lookup of a characters order
        //    Dictionary<char, int> characterOrder = new Dictionary<char, int>();

        //    // Build the characterOrder dictionary
        //    for (int i = 0; i < order.Length; i++)
        //    {
        //        characterOrder.Add(order[i], i);
        //    }

        //    // Loop through each word first
        //    for (int j = 0; j < words.Length - 1; j++) 
        //    {
        //        string thisWord = words[j];
        //        string nextWord = words[j + 1];

        //        int maxLetterLength = Math.Max(thisWord.Length, nextWord.Length);
        //        // Check each word with its next word, can skip the last word since no word is after that
        //        for (int i = 0; i < maxLetterLength; i++)
        //        {
        //            // Short Circuit the loop if one of the words has ended
        //            // This word ends first is good, no need to check more letters
        //            if (i == thisWord.Length)
        //                break;
        //            // Next word ending first is bad, return false
        //            if (i == nextWord.Length)
        //                return false;

        //            int comp = LetterCompare(thisWord, nextWord, i, characterOrder);

        //            if (comp == 1)
        //                return false;

        //            // Words passed, break out of the word comp
        //            if (comp == -1)
        //                break;

        //            // Notice if comp is 0, we continue the letter loop since the letters at this index were equal
        //        }
        //    }

        //    return true;
        //}

        //// Returns 0 of the letters match, -1 if first is less than second, 1 if first is greater than second
        //public int LetterCompare(string word1, string word2, int index, Dictionary<char, int> characterOrder)
        //{
        //    int word1Index = GetIndex(word1, index, characterOrder);
        //    int word2Index = GetIndex(word2, index, characterOrder);
        //    if (word1Index == word2Index)
        //        return 0;
        //    if (word1Index < word2Index)
        //        return -1;
        //    return 1;
        //}

        //public int GetIndex(string word, int index, Dictionary<char, int> characterOrder)
        //{
        //    // If word has ended, it is considered "first" in the order sequence
        //    if (index >= word.Length)
        //        return -1;

        //    return characterOrder[word[index]];
        //}






    }
}