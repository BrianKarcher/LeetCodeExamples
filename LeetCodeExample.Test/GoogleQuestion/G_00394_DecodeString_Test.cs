using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given an encoded string, return its decoded string.
    // The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times.Note that k is guaranteed to be a positive integer.
    // You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.
    // Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k.For example, there won't be input like 3a or 2[4].
    /// </summary>
    public class G_00394_DecodeString_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = DecodeString("3[a]2[bc]");
            Assert.AreEqual("aaabcbc", answer);

            answer = DecodeString("3[a2[c]]");
            Assert.AreEqual("accaccacc", answer);

            answer = DecodeString("2[abc]3[cd]ef");
            Assert.AreEqual("abcabccdcdcdef", answer);

            answer = DecodeString("abc3[cd]xyz");
            Assert.AreEqual("abccdcdcdxyz", answer);

        }

        public string DecodeString(string s)
        {
            return Recurse(s, 0, s.Length);
        }

        // Based on "terms". A term is some letters, followed possibly by a number, then [].
        // Inside the brackets is another term, to be recursed through.
        public string Recurse(string s, int start, int end)
        {
            string decoded = string.Empty;
            int i = start;
            //for (int i = start; i < end; i++)
            while (i < end)
            {
                // Just add letters as is, they do not have anything to do with a sub term
                while (!(s[i] >= '0' && s[i] <= '9'))
                {
                    decoded += s[i];
                    i++;
                    if (i == end)
                        return decoded;
                }

                // We hit a number, let's set up the recursive call and multiplier
                string number = string.Empty;
                // Extract the number
                while (s[i] != '[')
                {
                    number += s[i];
                    i++;
                }

                // Extract the inner term - continue until we find the proper closing bracket
                i++;
                int innerTermStart = i;
                int bracketCount = 1;
                while (bracketCount > 0)
                {
                    if (s[i] == '[')
                        bracketCount++;
                    if (s[i] == ']')
                        bracketCount--;
                    i++;
                }
                int innerTermEnd = i - 1;
                var innerCalculation = Recurse(s, innerTermStart, innerTermEnd);
                int iNumber = Int32.Parse(number);
                // Repeat the inner term
                for (int j = 0; j < iNumber; j++)
                    decoded += innerCalculation;

            }
            return decoded;
        }

        //int index = 0;
        //String decodeString(String s)
        //{
        //    StringBuilder result = new StringBuilder();
        //    while (index < s.length() && s.charAt(index) != ']')
        //    {
        //        if (!Character.isDigit(s.charAt(index)))
        //            result.append(s.charAt(index++));
        //        else
        //        {
        //            int k = 0;
        //            // build k while next character is a digit
        //            while (index < s.length() && Character.isDigit(s.charAt(index)))
        //                k = k * 10 + s.charAt(index++) - '0';
        //            // ignore the opening bracket '['    
        //            index++;
        //            String decodedString = decodeString(s);
        //            // ignore the closing bracket ']'
        //            index++;
        //            // build k[decodedString] and append to the result
        //            while (k-- > 0)
        //                result.append(decodedString);
        //        }
        //    }
        //    return new String(result);
        //}
    }
}