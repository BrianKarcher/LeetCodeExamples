using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //Given a string s, return true if the s can be palindrome after deleting at most one character from it.
    /// </summary>
    public class _00680_ValidPalindromeII_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public bool ValidPalindrome(string s)
        {
            return Recurse(s, 0, s.Length - 1, false);
        }

        public bool Recurse(string s, int left, int right, bool foundInvalid)
        {
            // Exit if there is only one character left, one character left = valid palindrome
            while (left < right)
            {
                if (s[left] == s[right])
                {
                    // valid, continue
                    left++;
                    right--;
                }
                else
                {
                    // Invalid character found
                    // If we have already removed a character, then this palindrome is invalid
                    if (foundInvalid == true)
                        return false;
                    // Next we need to decide which character to remove - and we're not 100% sure so we will
                    // check both directions
                    if (Recurse(s, left + 1, right, true) || Recurse(s, left, right - 1, true))
                        return true;
                    else
                        return false;
                }
            }
            return true;
        }
    }
}