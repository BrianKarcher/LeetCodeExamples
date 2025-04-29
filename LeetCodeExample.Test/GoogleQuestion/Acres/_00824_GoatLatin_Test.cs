using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    You are given a string sentence that consist of words separated by spaces.Each word consists of lowercase and uppercase letters only.

    //   We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.) The rules of Goat Latin are as follows:

    //If a word begins with a vowel('a', 'e', 'i', 'o', or 'u'), append "ma" to the end of the word.
    //For example, the word "apple" becomes "applema".
    //If a word begins with a consonant (i.e., not a vowel), remove the first letter and append it to the end, then add "ma".
    //For example, the word "goat" becomes "oatgma".
    //Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
    //For example, the first word gets "a" added to the end, the second word gets "aa" added to the end, and so on.
    //Return the final sentence representing the conversion from sentence to Goat Latin.
    /// </summary>
    public class _00824_GoatLatin_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public string ToGoatLatin(string sentence)
        {
            var words = sentence.Split(' ');
            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                char firstLetter = word[0];
                if (vowels.Contains(firstLetter))
                {
                    word = word + "ma";
                }
                else
                {
                    // Move first letter to the end, then add "ma" for constinents
                    word = word.Substring(1) + firstLetter + "ma";
                }
                word = word.PadRight(word.Length + i + 1, 'a');
                words[i] = word;
            }
            return String.Join(' ', words);
        }
    }
}