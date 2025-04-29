using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Alice and Bob continue their games with piles of stones.There are several stones arranged in a row, and each stone has an associated value which is an integer given in the array stoneValue.
    //Alice and Bob take turns, with Alice starting first. On each player's turn, that player can take 1, 2, or 3 stones from the first remaining stones in the row.

    //The score of each player is the sum of the values of the stones taken.The score of each player is 0 initially.
    //The objective of the game is to end with the highest score, and the winner is the player with the highest score and there could be a tie. The game continues until all the stones have been taken.

    //Assume Alice and Bob play optimally.

    //Return "Alice" if Alice will win, "Bob" if Bob will win, or "Tie" if they will end the game with the same score.
    /// </summary>
    public class _01406_StoneGameIII
    {
        public string StoneGameIII(int[] stoneValue)
        {
            int rtn = dp(0, true, stoneValue);
            if (rtn == 0)
                return "Tie";
            if (rtn < 0)
                return "Bob";
            return "Alice";
        }

        public Dictionary<(int start, bool isAlice), int> memo = new Dictionary<(int start, bool isAlice), int>();

        int dp(int start, bool isAlice, int[] piles)
        {
            // base case
            if (start >= piles.Length)
                return 0;

            if (memo.ContainsKey((start, isAlice)))
                return memo[(start, isAlice)];

            // Use Minimax
            // Alice is Max, always wants to add to the answer and picks the greatest next value
            // Bob is Min, always wants to subtract from the answer and picks the lowest next value
            int minmax = isAlice ? Int32.MinValue : Int32.MaxValue;
            int running = 0;
            for (int i = 0; i < 3 && start + i < piles.Length; i++)
            {
                if (isAlice)
                {
                    // Max
                    running += piles[start + i];
                    int pick = running + dp(start + i + 1, false, piles);
                    minmax = Math.Max(minmax, pick);
                }
                else
                {
                    // Min
                    running -= piles[start + i];
                    int pick = running + dp(start + i + 1, true, piles);
                    minmax = Math.Min(minmax, pick);
                }
            }
            memo.Add((start, isAlice), minmax);
            //Console.WriteLine($"Start: {start}, IsAlice: {isAlice}, Minmax: {minmax}");
            return minmax;
        }
    }
}