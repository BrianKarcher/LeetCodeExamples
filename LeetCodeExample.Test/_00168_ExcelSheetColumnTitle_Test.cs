using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.

    //    For example:

    // A -> 1
    // B -> 2
    // C -> 3
    // ...
    // Z -> 26
    // AA -> 27
    // AB -> 28 
    // ...
    /// </summary>
    public class _00168_ExcelSheetColumnTitle_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = ConvertToTitle(1);
            Assert.AreEqual("A", answer);

            answer = ConvertToTitle(28);
            Assert.AreEqual("AB", answer);

            answer = ConvertToTitle(701);
            Assert.AreEqual("ZY", answer);

            answer = ConvertToTitle(2147483647);
            Assert.AreEqual("FXSHRXW", answer);

            answer = ConvertToTitle(52);
            Assert.AreEqual("AZ", answer);

            answer = ConvertToTitle(27);
            Assert.AreEqual("AA", answer);
        }

        public string ConvertToTitle(int columnNumber)
        {
            string str = string.Empty;
            while (columnNumber > 0)
            {
                // columnNumber starts counting at 1, we need it at base 0
                columnNumber--;
                str = Char.ConvertFromUtf32('A' + (columnNumber) % 26) + str;
                columnNumber /= 26;
            }
            return str;
        }
    }
}