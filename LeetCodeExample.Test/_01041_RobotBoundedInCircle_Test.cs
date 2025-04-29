using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    On an infinite plane, a robot initially stands at(0, 0) and faces north.The robot can receive one of three instructions:

    // "G": go straight 1 unit;
    // "L": turn 90 degrees to the left;
    // "R": turn 90 degrees to the right.
    // The robot performs the instructions given in order, and repeats them forever.

    // Return true if and only if there exists a circle in the plane such that the robot never leaves the circle.
    /// </summary>
    public class _01041_RobotBoundedInCircle_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        public bool IsRobotBounded(string instructions)
        {
            int x = 0;
            int y = 0;

            // 0, 1, 2, 3 = N, E, S, W
            int dir = 0;
            (int x, int y)[] dirMove = new (int, int)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
            foreach (char i in instructions)
            {
                if (i == 'G')
                {
                    x += dirMove[dir].x;
                    y += dirMove[dir].y;
                }
                else if (i == 'L')
                {
                    dir--;
                    if (dir < 0)
                        dir = 3;
                }
                else if (i == 'R')
                {
                    dir++;
                    if (dir > 3)
                        dir = 0;
                }
            }
            //The robot stays in the circle iff (looking at the final vector) it changes direction (ie. doesn't stay pointing north), or it moves 0.
            return (x == 0 && y == 0) || dir != 0;
        }
    }
}