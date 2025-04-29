using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given two integer arrays pushed and popped each with distinct values, return true if this could have been the result of a sequence of push and pop operations on an initially empty stack, or false otherwise.
    /// </summary>
    public class _00946_ValidateStackSequences
    {
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack<int> stack = new Stack<int>();
            int poppedIndex = 0;
            for (int i = 0; i < pushed.Length; i++)
            {
                stack.Push(pushed[i]);
                while (stack.Count != 0 && stack.Peek() == popped[poppedIndex])
                {
                    stack.Pop();
                    poppedIndex++;
                }
            }
            return stack.Count == 0;
        }
    }
}