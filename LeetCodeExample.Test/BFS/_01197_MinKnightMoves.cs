using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    In an infinite chess board with coordinates from -infinity to +infinity, you have a knight at square[0, 0].
    //A knight has 8 possible moves it can make, as illustrated below.Each move is two squares in a cardinal direction, then one square in an orthogonal direction.

    //Return the minimum number of steps needed to move the knight to the square [x, y]. It is guaranteed the answer exists.
    /// </summary>
    public class _01197_MinKnightMoves
    {
        public int MinKnightMoves(int x, int y)
        {
            if (x == 0 && y == 0)
            {
                return 0;
            }
            Queue<(int x, int y)> q = new Queue<(int x, int y)>();
            q.Enqueue((0, 0));
            int size = 0;
            List<(int x, int y)> dirs = new List<(int, int)> { (1, -2), (2, -1), (2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2) };
            HashSet<(int x, int y)> visited = new HashSet<(int x, int y)>();
            while (q.Count != 0)
            {
                size++;
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    (int qx, int qy) = q.Dequeue();
                    foreach (var dir in dirs)
                    {
                        int newX = qx + dir.x;
                        int newY = qy + dir.y;
                        if (visited.Contains((newX, newY)))
                        {
                            continue;
                        }
                        // Bounds Check
                        if (newX < -300 || newX > 300 || newY < -300 || newY > 300)
                        {
                            continue;
                        }
                        if (newX == x && newY == y)
                        {
                            return size;
                        }
                        visited.Add((newX, newY));
                        q.Enqueue((newX, newY));
                    }
                }
            }
            return -1;
        }
    }
}