using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    There are n cars on an infinitely long road.The cars are numbered from 0 to n - 1 from left to right and each car is present at a unique point.
    //    You are given a 0-indexed string directions of length n.directions[i] can be either 'L', 'R', or 'S' denoting whether the ith car is moving towards the left, towards the right, or staying at its current point respectively.Each moving car has the same speed.
    //    The number of collisions can be calculated as follows:

    //    When two cars moving in opposite directions collide with each other, the number of collisions increases by 2.
    // When a moving car collides with a stationary car, the number of collisions increases by 1.
    // After a collision, the cars involved can no longer move and will stay at the point where they collided. Other than that, cars cannot change their state or direction of motion.

    //    Return the total number of collisions that will happen on the road.
    /// </summary>
    public class _02211_CountCollisionsOnARoad
    {
        public int CountCollisions(string directions)
        {
            int count = 0;
            Stack<char> stack = new();
            // Process cars left to right
            for (int i = 0; i < directions.Length; i++)
            {
                char dir = directions[i];
                if (stack.Count == 0)
                {
                    stack.Push(dir);
                }
                // Going to the right or stationary cannot collide with any cars that have been processed
                else if (dir == 'R')
                {
                    stack.Push(dir);
                }
                else if (dir == 'S')
                {
                    while (stack.Count != 0 && stack.Peek() == 'R')
                    {
                        char prev = stack.Pop();
                        count++;
                    }
                    // Push THIS stationary car to the Stack
                    stack.Push('S');
                }
                else if (dir == 'L')
                {
                    if (stack.Count != 0 && stack.Peek() == 'S')
                    {
                        count++;
                        dir = 'S';
                    }
                    else
                    {
                        while (stack.Count != 0 && stack.Peek() == 'R')
                        {
                            char prev = stack.Pop();
                            if (prev == 'R' && dir == 'S')
                            {
                                count++;
                            }
                            else if (prev == 'R')
                            {
                                count += 2;
                                dir = 'S';
                            }
                        }
                    }
                    stack.Push(dir);
                }
            }
            return count;
        }

        public int countCollisions(String dir)
        {

            int res = 0, n = dir.Length, i = 0, carsFromRight = 0;

            while (i < n && dir[i] == 'L') i++;

            for (; i < n; i++)
            {
                if (dir[i] == 'R') carsFromRight++;
                else
                {
                    res += (dir[i] == 'S') ? carsFromRight : carsFromRight + 1;
                    carsFromRight = 0;
                }
            }
            return res;
        }

        public int countCollisions2(String directions)
        {
            int collisions = 0;
            Stack<char> stack = new();
            stack.Push(directions[0]);
            for (int i = 1; i < directions.Length; i++)
            {
                char curr = directions[i];
                if (stack.Peek() == 'R' && curr == 'L')
                {
                    collisions += 2;
                    stack.Pop();
                    curr = 'S';
                }
                else if (stack.Peek() == 'S' && curr == 'L')
                {
                    curr = 'S';
                    collisions += 1;
                }
                while (stack.Count != 0 && stack.Peek() == 'R' && curr == 'S')
                {
                    collisions += 1;
                    stack.Pop();
                }
                stack.Push(curr);
            }
            return collisions;
        }
    }
}