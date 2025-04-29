using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given a string s of '(' , ')' and lowercase English characters.
    //    Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions) so that the resulting parentheses string is valid and return any valid string.
    //  Formally, a parentheses string is valid if and only if:
    //  It is the empty string, contains only lowercase characters, or
    //  It can be written as AB(A concatenated with B), where A and B are valid strings, or
    //  It can be written as (A), where A is a valid string.
    /// </summary>
    public class _01249_MinimumRemoveToMakeValidParenthesis
    {
        public string MinRemoveToMakeValid(string s)
        {
            string res = string.Empty;
            Stack<char> stack = new();
            // Left pass
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsLetter(s[i]))
                {
                    res += s[i];
                }
                else if (s[i] == '(')
                {
                    res += s[i];
                    stack.Push('(');
                }
                else if (s[i] == ')')
                {
                    if (stack.Count != 0)
                    {
                        // A successful open and close parenthesis
                        stack.Pop();
                        // It is valid so add it
                        res += s[i];
                    }
                }
            }

            string finalResult = string.Empty;
            // Right pass
            stack = new();
            for (int i = res.Length - 1; i >= 0; i--)
            {
                if (Char.IsLetter(res[i]))
                {
                    finalResult += res[i];
                }
                else if (res[i] == ')')
                {
                    finalResult += res[i];
                    stack.Push(')');
                }
                else if (res[i] == '(')
                {
                    if (stack.Count != 0)
                    {
                        // A successful open and close parenthesis
                        stack.Pop();
                        // It is valid so add it
                        finalResult += res[i];
                    }
                }
            }

            char[] charArray = finalResult.ToCharArray();
            Array.Reverse(charArray);
            return String.Concat(charArray);
        }
    }
}