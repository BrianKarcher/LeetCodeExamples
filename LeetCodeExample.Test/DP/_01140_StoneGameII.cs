using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Alice and Bob continue their games with piles of stones.There are a number of piles arranged in a row, and each pile has a positive integer number of stones piles[i].  The objective of the game is to end with the most stones. 
    //Alice and Bob take turns, with Alice starting first.  Initially, M = 1.
    //On each player's turn, that player can take all the stones in the first X remaining piles, where 1 <= X <= 2M.  Then, we set M = max(M, X).
    //The game continues until all the stones have been taken.

    //Assuming Alice and Bob play optimally, return the maximum number of stones Alice can get.
    /// </summary>
    public class _01140_StoneGameII
    {
        public int StoneGameII(int[] piles)
        {
            return dp(0, 1, piles, true);
        }

        public Dictionary<(int i, int m, bool isAlice), int> memo = new Dictionary<(int i, int m, bool isAlice), int>();

        int dp(int i, int m, int[] piles, bool isAlice)
        {
            if (i >= piles.Length)
                return 0;
            if (i == piles.Length - 1)
            {
                return isAlice ? piles[i] : 0;
            }

            if (memo.ContainsKey((i, m, isAlice)))
                return memo[(i, m, isAlice)];

            int runningCount = 0;
            int minmax = isAlice ? Int32.MinValue : Int32.MaxValue;
            for (int x = 1; x <= 2 * m && i + x < piles.Length; x++)
            {
                if (isAlice)
                {
                    runningCount += piles[i + x - 1];
                    int val = dp(i + x, Math.Max(m, x), piles, false);
                    minmax = Math.Max(minmax, runningCount + val);
                }
                else
                {
                    runningCount += 0; // Bob sets his count to 0, not negative, since we need
                                       // to tally Alice's count
                    minmax = Math.Min(minmax, runningCount + dp(i + x, Math.Max(m, x), piles, true));
                }
            }
            memo.Add((i, m, isAlice), minmax);
            Console.WriteLine($"i {i}, m {m}, isAlice {isAlice}, minmax {minmax}");

            return minmax;
        }
    }
}