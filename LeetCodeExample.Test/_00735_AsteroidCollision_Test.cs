using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //We are given an array asteroids of integers representing asteroids in a row.
    //For each asteroid, the absolute value represents its size, and the sign represents its direction (positive meaning right, negative meaning left). Each asteroid moves at the same speed.
    //Find out the state of the asteroids after all collisions.If two asteroids meet, the smaller one will explode.If both are the same size, both will explode.Two asteroids moving in the same direction will never meet.
    /// </summary>
    public class _00735_AsteroidCollision_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = AsteroidCollision(new int[] { 5, 10, -5 });
            Assert.AreEqual(new int[] { 5, 10 }, answer);

            answer = AsteroidCollision(new int[] { 8, -8 });
            Assert.AreEqual(new int[] { }, answer);

            answer = AsteroidCollision(new int[] { 10, 2, -5 });
            Assert.AreEqual(new int[] { 10 }, answer);

            answer = AsteroidCollision(new int[] { -2, -1, 1, 2 });
            Assert.AreEqual(new int[] { -2, -1, 1, 2 }, answer);

            answer = AsteroidCollision(new int[] { 1, 1, -1, -2 });
            Assert.AreEqual(new int[] { -2 }, answer);
        }

        //public int[] AsteroidCollision(int[] asteroids)
        //{
        //    var astList = asteroids.ToList();

        //    // Keep looping until there are no more asteroids to remove
        //    while (true)
        //    {
        //        bool madeAChange = false;
        //        for (int i = astList.Count - 1; i > 0; i--)
        //        {
        //            int sizeRight = astList[i];
        //            int sizeLeft = astList[i - 1];
        //            // If they are moving in the same direction, skip
        //            if ((sizeRight > 0 && sizeLeft > 0) || (sizeRight < 0 && sizeLeft < 0))
        //                continue;

        //            // If the asteroid on the right is moving to the right, and the one on the left
        //            // to the left, they cannot collide
        //            if (sizeRight > 0 && sizeLeft < 0)
        //                continue;

        //            // Collision!
        //            // Right asteroid larger than left?
        //            if (Math.Abs(sizeRight) > Math.Abs(sizeLeft))
        //            {
        //                // Remove aLeft
        //                astList.RemoveAt(i - 1);
        //                madeAChange = true;
        //            }
        //            else if (Math.Abs(sizeRight) < Math.Abs(sizeLeft))
        //            {
        //                // Right asteroid smaller than left?
        //                // Remove aRight
        //                astList.RemoveAt(i);
        //                madeAChange = true;
        //            }
        //            else
        //            {
        //                // Sizes are equal, remove both.
        //                // Remove the one on the right first so the indexes stay in place
        //                // for the removal on the left
        //                astList.RemoveAt(i);
        //                astList.RemoveAt(i - 1);
        //                // Decrement i one more time since we removed two items.
        //                i--;
        //                madeAChange = true;
        //            }
        //        }
        //        if (!madeAChange)
        //            break;
        //    }
        //    return astList.ToArray();
        //}


        // An O(n) solution using stacks (leetcode solution)
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            // We add astroids to the stack and kaboom as needed
            foreach (var ast in asteroids)
            {
                bool kaboomNewAstroid = false;

                // If there is an item in the Stack, AND the new AST is going left, AND the last
                // item in Stack is going Right, a collision has occured.
                // Loop until the astroid belt is stable
                while (stack.Any() && ast < 0 && 0 < stack.Peek())
                {
                    // Collision occured, figure out which astroid to destroy (or both)
                    var left = stack.Peek();
                    if (left < -ast)
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (left == -ast)
                    {
                        stack.Pop();
                        kaboomNewAstroid = true;
                        break;
                    }
                    else
                    {
                        kaboomNewAstroid = true;
                        break;
                    }
                }

                if (!kaboomNewAstroid)
                    stack.Push(ast);
            }

            int[] rtn = new int[stack.Count];
            for (int i = rtn.Length - 1; i >= 0; i--)
            {
                rtn[i] = stack.Pop();
            }

            return rtn;
        }
    }
}