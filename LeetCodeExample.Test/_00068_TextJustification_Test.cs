using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeExample.Test
{
    public class TextJustification_68_Test
    {
        /// <summary>
        /// Given an array of words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.

        ///        You should pack your words in a greedy approach; that is, pack as many words as you can in each line.Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.


        ///        Extra spaces between words should be distributed as evenly as possible.If the number of spaces on a line do not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.

        ///        For the last line of text, it should be left justified and no extra space is inserted between words.

        ///        Note:


        ///        A word is defined as a character sequence consisting of non-space characters only.
        ///        Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
        ///        The input array words contains at least one word.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            IList<string> answer;
            string[] words;
            words = new string[] { "This", "is", "an", "example", "of", "text", "justification." };
            answer = FullJustify(words, 16);
            Assert.AreEqual(new List<string>() {
               "This    is    an",
               "example  of text",
               "justification.  "
             }, answer);

            words = new string[] { "What", "must", "be", "acknowledgment", "shall", "be" };
            answer = FullJustify(words, 16);
            Assert.AreEqual(new List<string>() {
               "What   must   be",
               "acknowledgment  ",
               "shall be        "
             }, answer);

            words = new string[] { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" };
            answer = FullJustify(words, 20);
            Assert.AreEqual(new List<string>() {
               "Science  is  what we",
               "understand      well",
               "enough to explain to",
               "a  computer.  Art is",
               "everything  else  we",
               "do                  "
             }, answer);


            //answer = NumDecodings("226");
            //Assert.AreEqual(3, answer);
            //answer = NumDecodings("0");
            //Assert.AreEqual(0, answer);
            //answer = NumDecodings("06");
            //Assert.AreEqual(0, answer);
            //answer = NumDecodings("111111111111111111111111111111111111111111111");

        }

        //public IList<string> FullJustify(string[] words, int maxWidth)
        //{
        //    List<string> wordDocument = new List<string>();
        //    List<string> wordsInCurrentLine = new List<string>();
            
        //    // Cache the current line length so we don't have to keep on counting wordsInCurrentLine.
        //    int currentLineLength = 0;

        //    for (int i = 0; i < words.Length; i++)
        //    {
        //        var word = words[i];
        //        // Can we fit the word into the current line?
        //        // The 1 is for the minimum required space between words
        //        if (currentLineLength + word.Length + 1 < maxWidth)
        //        {
        //            wordsInCurrentLine.Add(word);
        //            currentLineLength += word.Length + 1;
        //        }
        //        else
        //        {
        //            // Line Length exceeded. Must jusify current line, add it, and move onto next line.
        //            int spacesNeeded = maxWidth - currentLineLength;
        //            // Divide spaces between words
        //            int spacesNeededBetweenWords = 1;
        //            // Not the last line? Calculate the spaces between each word to justify the line.
        //            if (i != words.Length - 1)
        //            {
        //                spacesNeededBetweenWords = spacesNeeded / wordsInCurrentLine.Count;
        //            }
        //            // How many words on the left get an extra space due to a possible uneven division above.
        //            int extraSpacesNotFitted = spacesNeeded % wordsInCurrentLine.Count;
        //            string line = string.Empty;
        //            // Fit the words into a line
        //            for (int k = 0; k < wordsInCurrentLine.Count; k++)
        //            {

        //            }

        //            currentLineLength = 0;
        //        }
        //    }
        //}

        //public string CreateFittedLine(List<string> wordsInCurrentLine, bool isLastLine)
        //{

        //}

        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            List<string> wordDocument = new List<string>();
            List<List<string>> unfittedDocument = new List<List<string>>();
            List<string> wordsInCurrentLine = new List<string>();

            // Cache the current line length so we don't have to keep on counting wordsInCurrentLine.
            int currentLineLength = 0;

            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                // Can we fit the word into the current line?
                // The 1 is for the minimum required space between words
                if (currentLineLength + word.Length - 1 < maxWidth)
                {
                    wordsInCurrentLine.Add(word);
                    currentLineLength += word.Length + 1;
                    continue;
                }
                // Line Length exceeded. Add it, and move onto next line.
                unfittedDocument.Add(wordsInCurrentLine);
                // Newline
                //wordsInCurrentLine.Clear();
                wordsInCurrentLine = new List<string>();
                // Put word into new line
                wordsInCurrentLine.Add(word);
                currentLineLength = word.Length + 1;
            }
            if (wordsInCurrentLine.Count != 0)
            {
                // Add any unfinished line.
                unfittedDocument.Add(wordsInCurrentLine);
            }

            // Justify the unfitted document
            for (int i = 0; i < unfittedDocument.Count; i++)
            {
                var unfittedLine = unfittedDocument[i];
                currentLineLength = 0;
                //unfittedLine.Select(i => currentLineLength += i.Length);
                currentLineLength += unfittedLine.Sum(i => i.Length);
                //currentLineLength += unfittedLine.Count - 1;
                int spacesNeeded = maxWidth - currentLineLength;
                // Divide spaces between words
                int spacesNeededBetweenWords = 1;
                // Subtract word count by one. Example, three words have two gaps of spaces between them.
                int spaceGaps = unfittedLine.Count - 1;
                // Not the last line? Calculate the spaces between each word to justify the line.
                if (i != unfittedDocument.Count - 1 && spaceGaps > 0)
                {                    
                    spacesNeededBetweenWords = spacesNeeded / spaceGaps;
                }
                currentLineLength += spacesNeededBetweenWords * spaceGaps;
                // How many words on the left get an extra space due to a possible uneven division above.
                //int extraSpacesNotFitted = spacesNeeded % unfittedLine.Count;
                int extraSpacesNotFitted = 0;
                // Last line is left-justified.
                if (i != unfittedDocument.Count - 1 && spaceGaps > 0)
                {
                    extraSpacesNotFitted = maxWidth - currentLineLength;
                }
                StringBuilder line = new StringBuilder();
                // Fit the words into a line
                for (int k = 0; k < unfittedLine.Count; k++)
                {
                    line.Append(unfittedLine[k]);
                    // Last word in line does not get spaces to the right. (exception on the last line is below);
                    if (k == unfittedLine.Count - 1)
                        continue;
                    line.Append(CreateSpaces(spacesNeededBetweenWords));
                    if (extraSpacesNotFitted > 0)
                    {
                        line.Append(" ");
                        extraSpacesNotFitted--;
                    }
                }

                // For use on the last line, add all extra spaces needed.
                line.Append(CreateSpaces(maxWidth - line.Length));

                wordDocument.Add(line.ToString());
            }
            return wordDocument;
        }

        public string CreateSpaces(int count)
        {
            string s = string.Empty;
            for (int i = 0; i < count; i++)
            {
                s += " ";
            }
            return s;
        }
    }
}