using System;

namespace LeetCodeExample.Test;

/// <summary>
//Given a rectangular pizza represented as a rows x cols matrix containing the following characters: 'A' (an apple) and '.' (empty cell) and given the integer k.You have to cut the pizza into k pieces using k-1 cuts.
//For each cut you choose the direction: vertical or horizontal, then you choose a cut position at the cell boundary and cut the pizza into two pieces.If you cut the pizza vertically, give the left part of the pizza to a person.If you cut the pizza horizontally, give the upper part of the pizza to a person.Give the last piece of pizza to the last person.
//Return the number of ways of cutting the pizza such that each piece contains at least one apple.Since the answer can be a huge number, return this modulo 10^9 + 7.
/// </summary>
public class _01444_NumberOfWaysOfCuttingAPizza
{
    //appleCounts[i][j] is the amount of apples in the pizza rectangular (i,j) ~ (row - 1, column - 1)
    int[,] appleCounts;
    // map[i][j][k] is the number of ways of cutting the pizza rectangular (i,j) ~ (row - 1, column - 1) into k pieces
    int?[,,] map;
    int cols;
    int rows;
    const int mod = 1000000007;

    public int Ways(string[] pizza, int k)
    {
        rows = pizza.Length;
        cols = pizza[0].Length;
        map = new int?[rows, cols, k];
        appleCounts = new int[rows, cols];
        appleCounts[rows - 1, cols - 1] = pizza[rows - 1][cols - 1] == 'A' ? 1 : 0;
        // With the way we sum it up, we can determine whether an apple resides in a given box by subtracting the top-left and
        // bottom-right corners in appleCounts and see if > 0.
        for (int r = rows - 2; r >= 0; r--)
        {
            appleCounts[r, cols - 1] = appleCounts[r + 1, cols - 1] + (pizza[r][cols - 1] == 'A' ? 1 : 0);
        }
        for (int c = cols - 2; c >= 0; c--)
        {
            appleCounts[rows - 1, c] = appleCounts[rows - 1, c + 1] + (pizza[rows - 1][c] == 'A' ? 1 : 0);
        }
        for (int r = rows - 2; r >= 0; r--)
        {
            for (int c = cols - 2; c >= 0; c--)
            {
                appleCounts[r, c] = appleCounts[r + 1, c] + appleCounts[r, c + 1] - appleCounts[r + 1, c + 1] + (pizza[r][c] == 'A' ? 1 : 0);
            }
        }
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Console.Write(appleCounts[r, c]);
            }
            Console.WriteLine();
        }
        int count = dp(pizza, 0, 0, k - 1);
        return count;
    }

    public int dp(string[] pizza, int x, int y, int k)
    {
        //Console.WriteLine($"Checking {x1}, {y1}, {x2}, {y2}, k = {k}");
        // base case.
        if (appleCounts[y, x] == 0)
        {
            map[y, x, k] = 0;
            return 0;
        }
        if (k <= 0)
        {
            return 1;
        }
        if (map[y, x, k] != null)
        {
            return map[y, x, k].Value;
        }

        int count = 0;
        // In the cuts we give away the top or left piece. Record if that other cut 
        // has an apple to reduce calculations.

        // Vertical cut.
        for (int cut = x + 1; cut < cols; cut++)
        {
            int applesInLeftPart = appleCounts[y, x] - appleCounts[y, cut];
            // Can we do a cut?
            if (applesInLeftPart > 0)
            {
                //Console.WriteLine($"Vertical cut at {x}");
                count = (count + dp(pizza, cut, y, k - 1)) % mod;
            }
        }

        // Horizontal cut.
        for (int cut = y + 1; cut < rows; cut++)
        {
            int applesInTopPart = appleCounts[y, x] - appleCounts[cut, x];
            // Can we do a cut?
            if (applesInTopPart > 0)
            {
                //Console.WriteLine($"Horizontal cut at {y}");
                count = (count + dp(pizza, x, cut, k - 1)) % mod;
            }
        }
        map[y, x, k] = count;
        //Console.WriteLine($"Finished {x1}, {y1}, {x2}, {y2}, {k} = {count}");
        return count;
    }
}