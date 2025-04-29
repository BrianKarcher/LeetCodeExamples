using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // There is a 2D grid of size n x n where each cell of this grid has a lamp that is initially turned off.
    // You are given a 2D array of lamp positions lamps, where lamps[i] = [rowi, coli] indicates that the lamp at grid[rowi][coli] is turned on. Even if the same lamp is listed more than once, it is turned on.
    // When a lamp is turned on, it illuminates its cell and all other cells in the same row, column, or diagonal.
    // You are also given another 2D array queries, where queries[j] = [rowj, colj].For the jth query, determine whether grid[rowj][colj] is illuminated or not.After answering the jth query, turn off the lamp at grid[rowj][colj] and its 8 adjacent lamps if they exist. A lamp is adjacent if its cell shares either a side or corner with grid[rowj][colj].
    // Return an array of integers ans, where ans[j] should be 1 if the cell in the jth query was illuminated, or 0 if the lamp was not.
    /// </summary>
    public class _01001_GridIllumination
    {
        // The grid is faaar too big to store in memory, need to get fancy
        // The lamps go in a straight line, and also diagonally.
        // column : x/y of lamps
        // Key: Column, Value: Count of lamps in column
        Dictionary<int, int> columns = new();

        // Key: Column, Value: Count of lamps in column
        Dictionary<int, int> rows = new();

        // Diagonal 1
        Dictionary<int, int> diag1 = new();

        // Diagonal 2
        Dictionary<int, int> diag2 = new();

        // Count of lamps stored at each position
        // This is used for finding lamps for removal (via the queries)
        // Key: Position, Value: Count
        Dictionary<(int y, int x), int> lampPos = new();

        public int[] GridIllumination(int n, int[][] lamps, int[][] queries)
        {
            // Cache the lamps into the counters
            for (int i = 0; i < lamps.Length; i++)
            {
                var y = lamps[i][0];
                var x = lamps[i][1];

                if (!columns.ContainsKey(x))
                    columns.Add(x, 0);
                columns[x]++;

                if (!rows.ContainsKey(y))
                    rows.Add(y, 0);
                rows[y]++;

                // Now do the diagonals via X and Y intercepts
                if (!diag1.ContainsKey(x - y))
                    diag1.Add(x - y, 0);
                diag1[x - y]++;

                if (!diag2.ContainsKey(x + y))
                    diag2.Add(x + y, 0);
                diag2[x + y]++;

                if (!lampPos.ContainsKey((y, x)))
                    lampPos.Add((y, x), 0);
                lampPos[(y, x)]++;
            }

            /*Console.WriteLine($"Columns");
            foreach (var i in columns) {
                Console.WriteLine($"{i.Key}, Count {i.Value}");
            }
            Console.WriteLine($"Rows");
            foreach (var i in rows) {
                Console.WriteLine($"{i.Key}, Count {i.Value}");
            }
            Console.WriteLine($"Diag1");
            foreach (var i in diag1) {
                Console.WriteLine($"{i.Key}, Count {i.Value}");
            }
            Console.WriteLine($"Diag2");
            foreach (var i in diag2) {
                Console.WriteLine($"{i.Key}, Count {i.Value}");
            }*/

            int[] res = new int[queries.Length];

            List<(int y, int x)> dirs = new List<(int, int)>() {(0, 0), (-1, -1), (-1, 0), (-1, 1), (0, -1),
                                                         (0, 1), (1, -1), (1, 0), (1, 1)};

            //foreach (var c in columns)
            //    Console.WriteLine($"Column {c.Key}, {c.Value}");

            // Run the queries
            for (int i = 0; i < queries.Length; i++)
            {
                int y = queries[i][0];
                int x = queries[i][1];
                // Check to see if this lamp is lit
                bool isLit = false;
                if (columns.ContainsKey(x) && columns[x] > 0)
                    isLit = true;
                else if (rows.ContainsKey(y) && rows[y] > 0)
                    isLit = true;
                // Now do the diagonals via X and Y intercepts
                else if (diag1.ContainsKey(x - y) && diag1[x - y] > 0)
                    isLit = true;
                else if (diag2.ContainsKey(x + y) && diag2[x + y] > 0)
                    isLit = true;

                //Console.WriteLine($"Query {y},{x}, {isLit}");

                res[i] = isLit ? 1 : 0;

                //Console.WriteLine($"Turning off lamps near {y}{x}");
                // Turn off all nearby lamps
                foreach (var dir in dirs)
                {
                    CheckAndTurnOffLamp(y + dir.y, x + dir.x);
                }
            }

            return res;
        }

        void CheckAndTurnOffLamp(int y, int x)
        {
            if (!lampPos.ContainsKey((y, x)))
                return;

            while (lampPos[(y, x)] > 0)
            {
                columns[x]--;
                rows[y]--;
                diag1[x - y]--;
                diag2[x + y]--;

                /*Console.WriteLine($"Turning off {y},{x}");

                Console.WriteLine($"Columns");
                foreach (var i in columns) {
                    Console.WriteLine($"{i.Key}, Count {i.Value}");
                }
                Console.WriteLine($"Rows");
                foreach (var i in rows) {
                    Console.WriteLine($"{i.Key}, Count {i.Value}");
                }
                Console.WriteLine($"Diag1");
                foreach (var i in diag1) {
                    Console.WriteLine($"{i.Key}, Count {i.Value}");
                }
                Console.WriteLine($"Diag2");
                foreach (var i in diag2) {
                    Console.WriteLine($"{i.Key}, Count {i.Value}");
                }*/

                lampPos[(y, x)]--;
            }
        }
    }
}