using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
        //    Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        //    An input string is valid if:
        // Open brackets must be closed by the same type of brackets.
        // Open brackets must be closed in the correct order.
    /// </summary>
    public class _00020_ValidParenthesis_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = IsValid("()");
            Assert.AreEqual(true, answer);

            answer = IsValid("()[]{}");
            Assert.AreEqual(true, answer);

            answer = IsValid("(]");
            Assert.AreEqual(false, answer);

            answer = IsValid("([)]");
            Assert.AreEqual(false, answer);

            answer = IsValid("{[]}");
            Assert.AreEqual(true, answer);
        }

        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> map = new Dictionary<char, char>();
            map.Add(')', '(');
            map.Add('}', '{');
            map.Add(']', '[');

            for (int i = 0; i < s.Length; i++)
            {
                var letter = s[i];
                if (map.ContainsKey(letter))
                {
                    // A closing removes the last opening bracket
                    if (stack.Count == 0)
                        return false;
                    var opening = stack.Pop();
                    if (map[letter] != opening)
                        return false;

                    // Do not add a closing bracket to the stack
                    continue;
                }

                stack.Push(letter);
            }

            return stack.Count == 0;

        }
    }
}