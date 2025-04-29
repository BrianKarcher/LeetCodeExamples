using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given a string S and a set of words D, find the longest word in D that is a subsequence of S.
    // Word W is a subsequence of S if some number of characters, possibly zero, can be deleted from S to form W, without reordering the remaining characters.
    // Note: D can appear in any format (list, hash table, prefix tree, etc.
    /// </summary>
    public class LongestWordThatIsASubsequence_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var ans = LongestSubsequence(new string[] { "able", "ale", "apple", "bale", "kangaroo" }, "abppplee");

        }

        // Each letter is a bucket for the words that are currently at this index
        // Index: index into the string, wIndex: index into the words array
        Dictionary<char, List<(int index, int arrayIndex)>> buckets = new Dictionary<char, List<(int, int)>>();

        public string LongestSubsequence(string[] words, string target)
        {
            char ch = 'a';
            for (int i = 0; i < 26; i++)
            {
                buckets.Add(ch, new List<(int, int)>());
                ch++;
            }

            // Put every word in the bucket for the first character
            for (int i = 0; i < words.Length; i++)
            {
                buckets[words[i][0]].Add((0, i));
            }

            // The goal is the loop through the target word only once ever.
            // And also to limit the amount of loops through the array of words
            string longestWord = "";

            foreach (char c in target)
            {
                // Get the bucket for this character
                var bucket = buckets[c];
                // Go through every word in this bucket
                // We are removing items, so loop backwards
                for (int i = bucket.Count - 1; i >= 0; i--)
                {
                    // Remove word from the bucket
                    var item = bucket[i];
                    bucket.RemoveAt(i);
                    // Increment the index
                    int index = item.index + 1;

                    // If we have reached the end of the word
                    if (index > words[item.arrayIndex].Length - 1)
                    {
                        if (words[item.arrayIndex].Length > longestWord.Length)
                            longestWord = words[item.arrayIndex];
                        // Do not add this word back to a bucket - just continue to the next word
                        continue;
                    }

                    // Add the word back to a bucket at the proper character
                    buckets[words[item.arrayIndex][index]].Add((index, item.arrayIndex));
                    //item = new(item.index + 1, item.arrayIndex);
                }
            }

            return longestWord;
        }
    }
}