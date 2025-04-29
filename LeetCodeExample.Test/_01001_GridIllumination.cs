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
        //Dictionary<int, (int x, int y)> columns = new HashSet<int>();
        // Key: Column, Value: Count of lamps in column
        // Columns and rows also act as X and Y intercepts for the diagonals
        Dictionary<int, int> columns = new();

        // Key: Column, Value: Count of lamps in column
        Dictionary<int, int> rows = new();

        // Count of lamps stored at each position
        // This is used for finding lamps for removal (via the queries)
        // Key: Position, Value: Count
        Dictionary<(int y, int x), int> lampPos = new();

        public int[] GridIllumination(int n, int[][] lamps, int[][] queries)
        {


            // For the diagonals, let's store the X and Y intercepts for quick lookup
            // Key: X-Intercept, Value: Count
            //Dictionary<int, int> diagXInt = new ();

            // Key: Y-Intercept, Value: Count
            //Dictionary<int, int> diagYInt = new ();

            // Cache the lamps into the counters
            for (int i = 0; i < lamps.Length; i++)
            {
                var y = lamps[i][0];
                var x = lamps[i][1];
                AddColumn(x);
                AddRow(y);
                // Now do the diagonals via X and Y intercepts
                int x1 = x - y;
                int x2 = x + y;
                int y1 = y - x;
                int y2 = y + x;
                AddColumn(x1);
                AddColumn(x2);
                AddRow(y1);
                AddRow(y2);
                if (!lampPos.ContainsKey((y, x)))
                    lampPos.Add((y, x), 0);
                lampPos[(y, x)]++;
            }

            int[] res = new int[queries.Length];

            List<(int y, int x)> dirs = new List<(int, int)>() {(0, 0), (-1, -1), (-1, 0), (1, 0), (0, -1),
                                                         (0, 1), (1, -1), (1, 0), (1, 1)};

            foreach (var c in columns)
                Console.WriteLine($"Column {c.Key}, {c.Value}");

            // Run the queries
            for (int i = 0; i < queries.Length; i++)
            {
                int y = queries[i][0];
                int x = queries[i][1];
                // Now do the diagonals via X and Y intercepts
                int x1 = x - y;
                int x2 = x + y;
                int y1 = y - x;
                int y2 = y + x;
                // Check to see if this lamp is lit
                bool isLit = false;
                if (columns.ContainsKey(x) && columns[x] > 0)
                    isLit = true;
                else if (rows.ContainsKey(y) && rows[y] > 0)
                    isLit = true;

                else if (columns.ContainsKey(x1) && columns[x1] > 0)
                    isLit = true;
                else if (columns.ContainsKey(x2) && columns[x2] > 0)
                    isLit = true;
                else if (rows.ContainsKey(y1) && rows[y1] > 0)
                    isLit = true;
                else if (rows.ContainsKey(y2) && rows[y2] > 0)
                    isLit = true;

                Console.WriteLine($"Query {y},{x}, {isLit}");

                res[i] = isLit ? 1 : 0;

                // Turn off all nearby lamps
                foreach (var dir in dirs)
                {
                    CheckAndTurnOffLamp(y + dir.y, x + dir.x);
                }
                /*CheckAndTurnOffLamp(y, x);
                CheckAndTurnOffLamp(y - 1, x - 1);
                CheckAndTurnOffLamp(y - 1, x);
                CheckAndTurnOffLamp(y + 1, x);
                CheckAndTurnOffLamp(y, x - 1);
                CheckAndTurnOffLamp(y, x + 1);
                CheckAndTurnOffLamp(y + 1, x - 1);
                CheckAndTurnOffLamp(y + 1, x);
                CheckAndTurnOffLamp(y + 1, x + 1);*/
            }

            return res;
        }

        void AddColumn(int x)
        {
            if (!columns.ContainsKey(x))
                columns.Add(x, 0);
            columns[x]++;
        }

        void AddRow(int y)
        {
            if (!rows.ContainsKey(y))
                rows.Add(y, 0);
            rows[y]++;
        }

        void RemoveColumn(int x)
        {
            columns[x]--;
        }

        void RemoveRow(int y)
        {
            rows[y]--;
        }

        void CheckAndTurnOffLamp(int y, int x)
        {
            if (lampPos.ContainsKey((y, x)) && lampPos[(y, x)] > 0)
            {
                RemoveColumn(x);
                RemoveRow(y);
                // Now do the diagonals via X and Y intercepts
                int x1 = x - y;
                int x2 = x + y;
                int y1 = y - x;
                int y2 = y + x;
                RemoveColumn(x1);
                RemoveColumn(x2);
                RemoveRow(y1);
                RemoveRow(y2);

                lampPos[(y, x)]--;
            }
        }
    }
}