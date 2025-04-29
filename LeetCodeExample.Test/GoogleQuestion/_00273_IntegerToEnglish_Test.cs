using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    // In an alien language, surprisingly, they also use English lowercase letters, but possibly in a different order.The order of the alphabet is some permutation of lowercase letters.
    // Given a sequence of words written in the alien language, and the order of the alphabet, return true if and only if the given words are sorted lexicographically in this alien language.
    /// </summary>
    public class _0273_IntegerToEnglish_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //List<string> lst = new List<string>();

            var answer = NumberToWords(2);
            Assert.AreEqual("Two", answer);

            answer = NumberToWords(12);
            Assert.AreEqual("Twelve", answer);

            answer = NumberToWords(100);
            Assert.AreEqual("One Hundred", answer);

            answer = NumberToWords(123);
            Assert.AreEqual("One Hundred Twenty Three", answer);

            answer = NumberToWords(12345);
            Assert.AreEqual("Twelve Thousand Three Hundred Forty Five", answer);

            answer = NumberToWords(1234567);
            Assert.AreEqual("One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven", answer);

            answer = NumberToWords(1234567891);
            Assert.AreEqual("One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One", answer);

            answer = NumberToWords(1000010);
            Assert.AreEqual("One Million Ten", answer);

        }

        //public Dictionary<char, string> DigitToEnglish = new Dictionary<char, string> {
        //    { '1', "One" },
        //    { '2', "Two" },
        //    { '3', "Three" },
        //    { '4', "Four" },
        //    { '5', "Five" },
        //    { '6', "Six" },
        //    { '7', "Seven" },
        //    { '8', "Eight" },
        //    { '9', "Nine" },
        //};

        //// Tens place, where the first digit is a one, and the second digit is x
        //public Dictionary<char, string> TeensToEnglish = new Dictionary<char, string>
        //{
        //    {'1', "Eleven" },
        //    {'2', "Twelve" },
        //    {'3', "Thirteen" },
        //    {'4', "Fourteen" },
        //    {'5', "Fifteen" },
        //    {'6', "Sixteen" },
        //    {'7', "Seventeen" },
        //    {'8', "Eighteen" },
        //    {'9', "Nineteen" },
        //};

        //public Dictionary<char, string> TensToEnglish = new Dictionary<char, string>
        //{
        //    {'2', "Twenty" },
        //    {'3', "Thirty" },
        //    {'4', "Fourty" },
        //    {'5', "Fifty" },
        //    {'6', "Sixty" },
        //    {'7', "Seventy" },
        //    {'8', "Eighty" },
        //    {'9', "Ninety" },
        //};

        //Dictionary<int, string> joiners = new Dictionary<int, string>()
        //    {
        //        { 1, "Thousand" },
        //        { 2, "Million" },
        //        { 3, "Billion" }
        //    };

        //public string NumberToWords(int num)
        //{
        //    if (num == 0)
        //        return "Zero";

        //    // Convert to a string, makes for easy parsing
        //    var numstr = num.ToString();

        //    List<string> list = new List<string>();

        //    int groupCounter = 0;
        //    // Group by 3's
        //    for (int i = numstr.Length - 1; i >= 0; i -= 3)
        //    {
        //        int indexToGrab = i - 3;
        //        if (indexToGrab < 0)
        //            indexToGrab = 0;
        //        string group3 = numstr.Substring(indexToGrab, numstr.Length - indexToGrab < 3 ? numstr.Length - indexToGrab  : 3);
        //        if (group3 == "000")
        //        {
        //            // We skip 000 groups, still must increment the Group Counter
        //            groupCounter++;
        //            continue;
        //        }
        //        ConvertThreeGroup(group3, list);
        //        if (groupCounter > 0)
        //        {
        //            list.Add(joiners[groupCounter]);
        //        }
        //        groupCounter++;
        //    }

        //    var arrList = list.ToArray();
        //    Array.Reverse(arrList);

        //    return String.Join(' ', arrList);
        //}

        //// Do it from right to left, may seem awkward, list will be built in reverse order
        //public void ConvertThreeGroup(string num, List<string> list)
        //{
        //    // Ensure always the same format, 2 turns into 002
        //    // Reduces edge cases we have to handle
        //    num = num.PadLeft(3, '0');
        //    // single digit, or something like 002
        //    if (num[0] == '0' && num[1] == '0')
        //    {
        //        list.Add(DigitToEnglish[num[2]]);
        //        return;
        //    }

        //    // Take care of the two digit place
        //    // Take care of the teens edge case
        //    if (num[1] == '1')
        //    {
        //        list.Add(TeensToEnglish[num[2]]);
        //    }
        //    else
        //    {
        //        // Need to add the second and first digit, for example, 25
        //        // right to left order!
        //        if (num[2] != '0')
        //            list.Add(DigitToEnglish[num[2]]);
        //        if (num[1] != '0')
        //        list.Add(TensToEnglish[num[1]]);

        //    }

        //    // There's a hundreds place
        //    if (num.Length == 3 && num[0] != '0')
        //    {
        //        list.Add("Hundred");
        //        list.Add(DigitToEnglish[num[0]]);
        //    }
        //}

        public Dictionary<int, string> under20 = new Dictionary<int, string> {
            { 1, "One" },
            { 2, "Two" },
            { 3, "Three" },
            { 4, "Four" },
            { 5, "Five" },
            { 6, "Six" },
            { 7, "Seven" },
            { 8, "Eight" },
            { 9, "Nine" },
            { 10, "Ten" },
            { 11, "Eleven" },
            { 12, "Twelve" },
            { 13, "Thirteen" },
            { 14, "Fourteen" },
            { 15, "Fifteen" },
            { 16, "Sixteen" },
            { 17, "Seventeen" },
            { 18, "Eighteen" },
            { 19, "Nineteen" },
        };

        public Dictionary<int, string> TensMap = new Dictionary<int, string>
        {
            {2, "Twenty" },
            {3, "Thirty" },
            {4, "Forty" },
            {5, "Fifty" },
            {6, "Sixty" },
            {7, "Seventy" },
            {8, "Eighty" },
            {9, "Ninety" },
        };

        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            return Process(num);
        }

        public string Process(int num)
        {
            List<string> lst = new List<string>();
            int billions = num / 1000000000;
            if (billions > 0)
            {
                ConvertHundreds(billions, lst);
                lst.Add("Billion");
                num %= 1000000000;
            }

            int millions = num / 1000000;
            if (millions > 0)
            {
                ConvertHundreds(millions, lst);
                lst.Add("Million");
                num %= 1000000;
            }

            int thousands = num / 1000;
            if (thousands > 0)
            {
                ConvertHundreds(thousands, lst);
                lst.Add("Thousand");
                num %= 1000;
            }

            if (num > 0)
                ConvertHundreds(num, lst);

            var rtn = string.Join(' ', lst.ToArray());
            return rtn;
        }

        public void ConvertHundreds(int num, List<string> list)
        {
            var hundreds = num / 100;

            if (hundreds > 0)
            {
                list.Add(under20[hundreds]);
                list.Add("Hundred");
                num %= 100;
            }

            if (num == 0)
                return;

            if (num < 20)
            {
                list.Add(under20[num]);
                return;
            }
            else // between 20 and 99
            {
                var tens = num / 10;
                list.Add(TensMap[tens]);
                num %= 10;
                if (num > 0)
                {
                    list.Add(under20[num]);
                }
            }
        }
    }
}