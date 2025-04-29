using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00224_BasicCalculator_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        // Using a Stack. This is a really poor implmentation, really hacky. I need to refine this
        // Maybe also consider making it compatible with multiple and divide and other types of order of operation
        // considerations
        public int Calculate(string s)
        {
            Stack<Object> stack = new Stack<Object>();
            int sign = 1;
            int calc = 0;
            int num = 0;
            // Put each expression onto the Stack. Ints can consist of multiple characters.
            //while (index < s.Length)
            // Make all operators "+" so they are commutative (A+B = B+A) - when popping off the stack
            // in reverse order
            stack.Push('(');
            //for (int i = 0; i < s.Length; i++)
            int i = 0;
            while (i < s.Length)
            {
                if (Char.IsDigit(s[i]))
                {
                    // If we were working on a number, push that to the stack and reset the variables
                    while (i < s.Length && Char.IsDigit(s[i]))
                    {
                        num = num * 10 + (int)Char.GetNumericValue(s[i]);
                        i++;
                    }
                    stack.Push('+');
                    stack.Push(num * sign);
                    num = 0;
                    sign = 1;
                    continue;
                }
                else if (s[i] == '-')
                {
                    sign = -1;
                    //stack.Push('+');
                }
                else if (s[i] == '+')
                {
                    stack.Push('+');
                }
                else if (s[i] == '(')
                {
                    if (sign == -1)
                    {
                        stack.Push(-1);
                        sign = 1;
                        //stack.Push('+');
                    }
                    stack.Push('(');
                }
                else if (s[i] == ')')
                {
                    //PrintStack(stack);
                    // Notice we have not done any actual calculations until now. Now since we are
                    // ending a parenthesis, let's calculate everything inside of this parenthesis
                    // Then Push that calculated value back onto the Stack
                    int c = CalcGroup(stack);
                    // Pop off the (
                    stack.Pop();
                    if (stack.Peek().GetType() == typeof(int))
                    {
                        int sin = (int)stack.Pop();
                        c = c * sin;
                    }
                    sign = 1;

                    stack.Push(c);
                }
                i++;
            }

            if (num != 0)
            {
                //stack.Push('+');
                stack.Push(num * sign);
            }
            //stack.Push(')');

            //PrintStack(stack);
            calc = CalcGroup(stack);
            return calc;
        }

        //public void PrintStack(Stack<Object> stack) {
        //    foreach (var obj in stack) {
        //        Console.Write($"{obj}");
        //    }
        //    Console.WriteLine();
        //}

        public int CalcGroup(Stack<Object> stack)
        {
            int calc = 0;
            int oper = 1;
            while (stack.Count != 0 && (stack.Peek().GetType() == typeof(int) || (char)stack.Peek() != '('))
            {
                object val = stack.Pop();
                if (val.GetType() == typeof(int))
                {
                    calc += (int)val;
                }
            }
            return calc;
        }

        // Using Recursion
        public int CalculateRec(string s)
        {
            return RecurseCalculator(s);
        }

        // Keep the index outside of the recursion for reuse
        int index = 0;

        public int RecurseCalculator(string s)
        {
            int calc = 0;

            while (index < s.Length)
            {
                // Calculations are done by two terms and an operand between them.
                // Operands can be + or -
                // The terms can use parenthesis, in which case we need to Recurse to find the results of the inner term

                if (s[index] == ')')
                {
                    //Console.WriteLine($"Exiting parenthesis, calc = {calc}, index = {index}");
                    index++;
                    return calc;
                }

                // Remove spaces
                while (index < s.Length && s[index] == ' ')
                    index++;

                // Next character an operand? (it won't be if it's the first number)
                char operand = '+';
                if (s[index] == '+')
                {
                    operand = '+';
                    index++;
                }
                else if (s[index] == '-')
                {
                    operand = '-';
                    index++;
                }

                bool isNegative = false;
                // Remove spaces
                while (index < s.Length && s[index] == ' ')
                    index++;

                if (index >= s.Length)
                    return calc;

                if (s[index] == '-')
                {
                    isNegative = true;
                    index++;
                }

                int term = 0;

                // Is the term a parenthesized query?
                if (s[index] == '(')
                {
                    //Console.WriteLine("Entering parenthesis");
                    index++;
                    term = RecurseCalculator(s);
                }
                else
                {
                    // The term is a regular value, let's calculate the integer
                    while (index < s.Length && Char.IsDigit(s[index]))
                    {
                        term *= 10;
                        term += (int)Char.GetNumericValue(s[index]);
                        index++;
                    }
                }

                if (isNegative) term = -term;

                //Console.WriteLine($"{calc} {operand} {term}");

                int result;
                if (operand == '-')
                    result = calc - term;
                else
                    result = calc + term;

                //Console.WriteLine($"{calc} {operand} {term} = {result}, index = {index}");

                calc = result;

                // Remove spaces
                while (index < s.Length && s[index] == ' ')
                    index++;
            }

            return calc;
        }
    }
}