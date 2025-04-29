using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test
{
    public class IntToRomanTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IntToRoman()
        {
            string answer;
            answer = IntToRoman(3);
            Assert.AreEqual(answer, "III");
            answer = IntToRoman(4);
            Assert.AreEqual(answer, "IV");
            answer = IntToRoman(9);
            Assert.AreEqual(answer, "IX");
            answer = IntToRoman(58);
            Assert.AreEqual(answer, "LVIII");
            answer = IntToRoman(1994);
            Assert.AreEqual(answer, "MCMXCIV");
        }

        public string IntToRoman(int num)
        {
            List<(int value, string numeral)> mapper = new List<(int, string)>()
            {
                (1000, "M"),
                (900, "CM"),
                (500, "D"),
                (400, "CD"),
                (100, "C"),
                (90, "XC"),
                (50, "L"),
                (40, "XL"),
                (10, "X"),
                (9, "IX"),
                (5, "V"),
                (4, "IV"),
                (1, "I")
            };

            StringBuilder answer = new StringBuilder();
            int currentNumeral = 0;

            while (num > 0)
            {
                // Has num become smaller than the numeral we are on?
                if (mapper[currentNumeral].value > num)
                {
                    // Are we at the edge case of next numeral minus this one? ie 4 = IV?


                    // Increment the numeral to the next value
                    currentNumeral++;
                    continue;
                }
                answer.Append(mapper[currentNumeral].numeral);
                num -= mapper[currentNumeral].value;
            }

            return answer.ToString();
        }

        public string IntToRoman3(int num)
        {
            List<(int value, string numeral)> mapper = new List<(int, string)>()
            {
                (1000, "M"),
                (900, "CM"),
                (500, "D"),
                (400, "CD"),
                (100, "C"),
                (90, "XC"),
                (50, "L"),
                (40, "XL"),
                (10, "X"),
                (9, "IX"),
                (5, "V"),
                (4, "IV"),
                (1, "I")
            };

            string answer = "";
            //StringBuilder answer = new StringBuilder();
            int currentNumeral = 0;

            while (num > 0)
            {
                // Has num become smaller than the numeral we are on?
                if (mapper[currentNumeral].value > num)
                {
                    // Are we at the edge case of next numeral minus this one? ie 4 = IV?


                    // Increment the numeral to the next value
                    currentNumeral++;
                    continue;
                }
                answer += mapper[currentNumeral].numeral;
                //answer.Append(mapper[currentNumeral].numeral);
                num -= mapper[currentNumeral].value;
            }

            return answer;
        }

        public string IntToRoman2(int num)
        {
            List<KeyValuePair<int, string>> mapper = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1000, "M"),
                new KeyValuePair<int, string>(900, "CM"),
                new KeyValuePair<int, string>(500, "D"),
                new KeyValuePair<int, string>(400, "CD"),
                new KeyValuePair<int, string>(100, "C"),
                new KeyValuePair<int, string>(90, "XC"),
                new KeyValuePair<int, string>(50, "L"),
                new KeyValuePair<int, string>(40, "XL"),
                new KeyValuePair<int, string>(10, "X"),
                new KeyValuePair<int, string>(9, "IX"),
                new KeyValuePair<int, string>(5, "V"),
                new KeyValuePair<int, string>(4, "IV"),
                new KeyValuePair<int, string>(1, "I")
            };

            StringBuilder answer = new StringBuilder();
            int currentNumeral = 0;

            while (num > 0)
            {
                // Has num become smaller than the numeral we are on?
                if (mapper[currentNumeral].Key > num)
                {
                    // Increment the numeral to the next value
                    currentNumeral++;
                    continue;
                }
                answer.Append(mapper[currentNumeral].Value);
                num -= mapper[currentNumeral].Key;
            }

            return answer.ToString();
        }
    }
}