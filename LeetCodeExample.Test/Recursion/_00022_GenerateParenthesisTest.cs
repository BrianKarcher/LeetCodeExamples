using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
    /// </summary>
    public class _00022_GenerateParenthesisTest
    {
        public IList<string> GenerateParenthesis(int n)
        {
            GenerateAll(new char[n * 2], 0);
            return result;
        }

        public List<string> result = new List<string>();

        // Brute force, check all combination possibilities
        public void GenerateAll(char[] ch, int pos)
        {
            if (pos == ch.Length)
            {
                if (IsValid(ch))
                {
                    result.Add(new String(ch));
                }
            }
            else
            {
                ch[pos] = '(';
                GenerateAll(ch, pos + 1);
                ch[pos] = ')';
                GenerateAll(ch, pos + 1);
            }
        }

        public bool IsValid(char[] ch)
        {
            int balance = 0;
            foreach (var c in ch)
            {
                if (c == '(')
                    balance++;
                else
                    balance--;
                if (balance < 0)
                    return false;
            }
            return balance == 0;
        }
    }
}