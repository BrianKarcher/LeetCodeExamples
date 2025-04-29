using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00909_SnakesAndLadders_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var ans = PositionToGrid(8, 6);
            Console.WriteLine($"{ans.r}, {ans.c}");

            ans = PositionToGrid(6, 6);
            Console.WriteLine($"{ans.r}, {ans.c}");

            ans = PositionToGrid(7, 6);
            Console.WriteLine($"{ans.r}, {ans.c}");

            ans = PositionToGrid(36, 6);
            Console.WriteLine($"{ans.r}, {ans.c}");

            //var ans2 = sol.SnakesAndLadders(new int[][] {new int[] {-1,-1,-1,-1,-1,-1},new int[] {-1,-1,-1,-1,-1,-1},new int[] {-1,-1,-1,-1,-1,-1},new int[] {-1,35,-1,-1,13,-1},new int[] {-1,-1,-1,-1,-1,-1},new int[] {-1,15,-1,-1,-1,-1}});

            //Console.WriteLine($"{ans2}");

            //var ans2 = sol.SnakesAndLadders(new int[][] {new int[] {1, 1, -1},new int[] {1, 1, 1},new int[] {-1, 1, 1}});

            //Console.WriteLine($"{ans2}");

            var ans2 = SnakesAndLadders(new int[][] { new int[] { -1, -1, -1 }, new int[] { -1, 9, 8 }, new int[] { -1, 8, 9 } });

            Console.WriteLine($"{ans2}");
        }

        public int SnakesAndLadders(int[][] board)
        {
            // Do a BFS
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            int step = 0;
            int boardWidth = board.Length;
            int boardSize = boardWidth * boardWidth;
            HashSet<int> visited = new HashSet<int>();

            bool reverse = false;
            for (int i = board.Length - 1; i >= 0; i--)
            {
                // Reverse every other row
                if (reverse)
                {
                    //Console.WriteLine($"Reversing row {i}");
                    Array.Reverse(board[i]);
                }
                reverse = !reverse;
            }
            // Translates the board position to a grid position in a Boustrophedon style
            Array.Reverse(board);

            /*for (int i = 0; i < boardWidth; i++)
            {
                for (int c = 0; c < boardWidth; c++) {
                Console.Write($"{board[i][c]} ");
                }
                
                Console.WriteLine();
            }*/
            while (queue.Any())
            {
                step++;
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var pos = queue.Dequeue();

                    // Can roll a 1 to 6 on the dice from here
                    for (int j = 1; j <= 6; j++)
                    {
                        int newPos = Math.Min((pos + j), boardSize);
                        //Console.WriteLine($"{step} {newPos}");

                        // Skipping backwards cycles
                        if (visited.Contains(newPos))
                            continue;
                        visited.Add(newPos);

                        var gridPosition = PositionToGrid(newPos, boardWidth);
                        // See if the user hits a snake or ladder (and thus is moved)

                        if (newPos >= boardSize)
                            return step;
                        int updatedPos = newPos;
                        if (board[gridPosition.r][gridPosition.c] != -1)
                            updatedPos = board[gridPosition.r][gridPosition.c];
                        //Console.WriteLine($"{step} {newPos} {updatedPos} Position: {gridPosition.r} {gridPosition.c}");
                        // A snake or ladder can land you on the end position. In that case, we are done!
                        if (updatedPos >= boardSize)
                            return step;
                        queue.Enqueue(updatedPos);
                    }
                }
            }
            return -1;
        }

        public (int r, int c) PositionToGrid(int n, int boardWidth)
        {
            n = n - 1; // Convert to zero-based for a grid lookup
            int r = n / boardWidth;
            //bool goingRight = r % 2 == 0 ? true : false;
            int c = n % boardWidth;
            //Console.WriteLine($"Row: {r}, Going Right: {goingRight}, ColsToMove: {colsToMove}");
            //int c = goingRight ? colsToMove : boardWidth - colsToMove - 1;
            //return (boardWidth - r - 1, c);
            return (r, c);
        }
    }
}