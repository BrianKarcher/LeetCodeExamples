using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RomanToInt()
        {
            int answer;
            answer = RomanToInt("III");
            Assert.AreEqual(answer, 3);
            answer = RomanToInt("IV");
            Assert.AreEqual(answer, 4);
            answer = RomanToInt("IX");
            Assert.AreEqual(answer, 9);
            answer = RomanToInt("LVIII");
            Assert.AreEqual(answer, 58);
            answer = RomanToInt("MCMXCIV");
            Assert.AreEqual(answer, 1994);
        }

        public int RomanToInt(string s)
        {
            char prev;
            int currentValue = 0;
            char currentChar;

            for (int i = 0; i < s.Length; i++)
            {
                currentChar = s[i];
                if (i < s.Length - 1)
                {
                    char nextChar = s[i + 1];
                    if (currentChar == 'I' && nextChar == 'V')
                    {
                        currentValue += 4;
                        // Since the two values are combined in Roman Numerals, skip the next value
                        i++;
                    }                        
                    else if (currentChar == 'I' && nextChar == 'X')
                    {
                        currentValue += 9;
                        i++;
                    }                        
                    else if (currentChar == 'X' && nextChar == 'L')
                    {
                        currentValue += 40;
                        i++;
                    }                        
                    else if (currentChar == 'X' && nextChar == 'C')
                    {
                        currentValue += 90;
                        i++;
                    }                        
                    else if (currentChar == 'C' && nextChar == 'D')
                    {
                        currentValue += 400;
                        i++;
                    }                        
                    else if (currentChar == 'C' && nextChar == 'M')
                    {
                        currentValue += 900;
                        i++;
                    }
                    else
                    {
                        currentValue += SingleRomanToInt(currentChar);
                    }
                }
                else
                {
                    // We reached the last character, just add it
                    currentValue += SingleRomanToInt(currentChar);
                }
            }

            return currentValue;
        }

        public int SingleRomanToInt(char roman)
        {
            if (roman == 'I')
                return 1;
            else if (roman == 'V')
                return 5;
            else if (roman == 'X')
                return 10;
            else if (roman == 'L')
                return 50;
            else if (roman == 'C')
                return 100;
            else if (roman == 'D')
                return 500;
            else if (roman == 'M')
                return 1000;
            return 0;
        }
    }
}