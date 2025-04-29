using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully(left and right) justified.
    //   You should pack your words in a greedy approach; that is, pack as many words as you can in each line.Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.

    //   Extra spaces between words should be distributed as evenly as possible.If the number of spaces on a line does not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.
    //   For the last line of text, it should be left-justified and no extra space is inserted between words.
    //   Note:


    //   A word is defined as a character sequence consisting of non-space characters only.
    //   Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
    //   The input array words contains at least one word.
    /// </summary>
    public class _00068_TextJustification2_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = FullJustify(new string[] { "This", "is", "an", "example", "of", "text", "justification." }, 16);
            Assert.AreEqual(new List<string> {
               "This    is    an",
               "example  of text",
               "justification.  "
            }, answer);

            answer = FullJustify(new string[] { "What", "must", "be", "acknowledgment", "shall", "be" }, 16);
            Assert.AreEqual(new List<string> {
               "What   must   be",
              "acknowledgment  ",
              "shall be        "
            }, answer);

            answer = FullJustify(new string[] { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" }, 20);
            Assert.AreEqual(new List<string> {
                "Science  is  what we",
                  "understand      well",
                  "enough to explain to",
                  "a  computer.  Art is",
                  "everything  else  we",
                  "do                  "
            }, answer);

            answer = FullJustify(new string[] { "ask", "not", "what", "your", "country", "can", "do", "for", "you", "ask", "what", "you", "can", "do", "for", "your", "country" }, 16);
            Assert.AreEqual(new List<string> {
                "ask   not   what","your country can","do  for  you ask","what  you can do","for your country"
            }, answer);

        }

        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            int i = 0;
            List<string> sentences = new List<string>();

            // Fill out a line.
            int lineStart = i;
            int lineEnd = i;
            int currentLettersInLine = 0;
            while (i < words.Length)
            {
                int nextWordCount = i == words.Length ? 0 : words[i].Length;
                // Have we exceeded current line (include single spaces between words)?
                if (currentLettersInLine + nextWordCount + (lineEnd - lineStart) > maxWidth)
                {
                    // Left justify if last line
                    if (lineEnd == words.Length || lineStart == lineEnd - 1)
                        sentences.Add(LeftJustify(lineStart, lineEnd, currentLettersInLine, words, maxWidth));
                    else // Full justify if not last line
                        sentences.Add(FullJustify(lineStart, lineEnd, currentLettersInLine, words, maxWidth));
                    // Starting a new line.
                    lineStart = i;
                    lineEnd = i;
                    currentLettersInLine = 0;
                }
                currentLettersInLine += words[i].Length;
                i++;
                lineEnd = i;
            }

            // Left over words? Left justify.
            if (lineStart != lineEnd)
            {
                sentences.Add(LeftJustify(lineStart, lineEnd, currentLettersInLine, words, maxWidth));
            }
            return sentences;
        }


        string LeftJustify(int lineStart, int lineEnd, int currentLettersInLine, string[] words, int maxWidth)
        {
            string sentence = string.Empty;
            for (int i = lineStart; i < lineEnd; i++)
            {
                sentence = sentence + words[i];
                // No extra spaces after last word.
                if (i == lineEnd - 1)
                    break;

                sentence = sentence + " ";
            }
            sentence = sentence.PadRight(maxWidth);
            return sentence;
        }

        string FullJustify(int lineStart, int lineEnd, int currentLettersInLine, string[] words, int maxWidth)
        {
            // Calculate excess spaces.
            int leftOverSpaces = maxWidth - currentLettersInLine;
            int extraSpaceBetweenAllWords = leftOverSpaces / (lineEnd - lineStart - 1); // We do n - 1 space gaps
            int extraSpaceFirstNWords = leftOverSpaces % (lineEnd - lineStart - 1);
            string sentence = string.Empty;
            for (int i = lineStart; i < lineEnd; i++)
            {
                sentence = sentence + words[i];
                // No extra spaces after last word.
                if (i == lineEnd - 1)
                    break;
                // Add obligatory "all spaces" plus possible extra space for the first N words
                int spaceCount = extraSpaceBetweenAllWords + ((i - lineStart) < extraSpaceFirstNWords ? 1 : 0);
                sentence = sentence.PadRight(sentence.Length + spaceCount);
            }
            return sentence;
        }
    }


}
