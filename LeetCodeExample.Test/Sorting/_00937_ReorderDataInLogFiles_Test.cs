using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an array of logs.Each log is a space-delimited string of words, where the first word is the identifier.

    //   There are two types of logs:


    //   Letter-logs: All words (except the identifier) consist of lowercase English letters.
    //   Digit-logs: All words(except the identifier) consist of digits.
    //  Reorder these logs so that:

    //The letter-logs come before all digit-logs.
    //The letter-logs are sorted lexicographically by their contents.If their contents are the same, then sort them lexicographically by their identifiers.
    //The digit-logs maintain their relative ordering.
    //Return the final order of the logs.
    /// </summary>
    public class _00937_ReorderDataInLogFiles_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        public string[] ReorderLogFiles(string[] logs)
        {
            //Array.Sort(logs, new CustomCompare());
            List<string> lst = logs.ToList();
            lst.Sort(new CustomCompare());
            return lst.ToArray();
        }

        public class CustomCompare : IComparer<string>
        {
            public int Compare(string first, string second)
            {
                string[] fSplit = first.Split(' ', 2);
                string[] sSplit = second.Split(' ', 2);
                bool isFirstDigit = Char.IsDigit(fSplit[1][0]);
                bool isSecondDigit = Char.IsDigit(sSplit[1][0]);
                // both digits? They are equal - no reordering
                if (isFirstDigit && isSecondDigit)
                    return 0;
                else if (isFirstDigit && !isSecondDigit)
                    return 1; // characters are pulled forward
                else if (!isFirstDigit && isSecondDigit)
                    return -1;

                // Now for the string compare
                // First compare the "data" part
                int cmp = fSplit[1].CompareTo(sSplit[1]);
                if (cmp != 0)
                    return cmp;

                // If the data mates, just return the label compare
                return fSplit[0].CompareTo(sSplit[0]);
            }
        }
    }
}