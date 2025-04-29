using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // Alice and Bob play a game with piles of stones.There are an even number of piles arranged in a row, and each pile has a positive integer number of stones piles[i].
    // The objective of the game is to end with the most stones. The total number of stones across all the piles is odd, so there are no ties.
    // Alice and Bob take turns, with Alice starting first. Each turn, a player takes the entire pile of stones either from the beginning or from the end of the row.This continues until there are no more piles left, at which point the person with the most stones wins.
    // Assuming Alice and Bob play optimally, return true if Alice wins the game, or false if Bob wins.
    /// </summary>
    public class _00877_StoneGame
    {
        public bool StoneGame(int[] piles)
        {
            // This is a zero sum game, so if the end result is > 0, Alice wins, if < 0, Bob wins
            // zero-sum makes the calculations of the "winner" easier, and tabulations also easier.
            var ans = dp(0, piles.Length - 1, true, piles);
            return ans >= 0;
        }

        Dictionary<(int l, int r, bool isAlice), int> memo = new Dictionary<(int l, int r, bool isAlice), int>();

        int dp(int l, int r, bool isAlice, int[] piles)
        {
            // base case
            if (l == r)
            {
                if (isAlice)
                    return piles[l];
                return -piles[r];
            }

            if (memo.ContainsKey((l, r, isAlice)))
                return memo[(l, r, isAlice)];

            // Use Minimax
            // Alice is Max, always wants to add to the answer and picks the greatest next value
            // Bob is Min, always wants to subtract from the answer and picks the lowest next value
            int val = 0;
            if (isAlice)
            {
                // Max
                // Pick left
                int left = piles[l] + dp(l + 1, r, false, piles);
                // Pick right
                int right = piles[r] + dp(l, r - 1, false, piles);
                val = Math.Max(left, right);
            }
            else
            {
                // Min
                // Pick left
                int left = -piles[l] + dp(l + 1, r, true, piles);
                // Pick right
                int right = -piles[r] + dp(l, r - 1, true, piles);
                val = Math.Min(left, right);
            }
            memo.Add((l, r, isAlice), val);
            return val;
        }
    }
}