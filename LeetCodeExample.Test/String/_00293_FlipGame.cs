using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//You are playing a Flip Game with your friend.
//You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.
//Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list[].
/// </summary>
public class _00293_FlipGame
{
    public IList<string> GeneratePossibleNextMoves(string currentState)
    {
        char[] chars = currentState.ToCharArray();
        List<string> rtn = new();
        for (int i = 0; i < currentState.Length - 1; i++)
        {
            if (currentState[i] == '+' && currentState[i + 1] == '+')
            {
                // Is this the beginning of a consecutive?
                chars[i] = '-';
                chars[i + 1] = '-';
                rtn.Add(new string(chars));
                // Backtrack
                chars[i] = '+';
                chars[i + 1] = '+';
            }
        }
        return rtn;
    }
}