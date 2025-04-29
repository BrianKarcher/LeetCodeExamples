using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are playing a game that contains multiple characters, and each of the characters has two main properties: attack and defense.You are given a 2D integer array properties where properties[i] = [attacki, defensei] represents the properties of the ith character in the game.
    //A character is said to be weak if any other character has both attack and defense levels strictly greater than this character's attack and defense levels. More formally, a character i is said to be weak if there exists another character j where attackj > attacki and defensej > defensei.

    //Return the number of weak characters.
    /// </summary>
    public class _01996_TheNumberOfWeakCharactersInGame
    {
        public int NumberOfWeakCharacters(int[][] properties)
        {
            Array.Sort(properties, Comparer<int[]>.Create((a, b) =>
            {
                return a[0] == b[0] ? (b[1] - a[1]) : a[0] - b[0];
            }));

            int weakCharacters = 0;
            int maxDefense = 0;
            for (int i = properties.Length - 1; i >= 0; i--)
            {
                if (properties[i][1] < maxDefense)
                {
                    weakCharacters++;
                }
                maxDefense = Math.Max(maxDefense, properties[i][1]);
            }
            return weakCharacters;
        }

        public int NumberOfWeakCharacters2(int[][] properties)
        {
            // Sort by highest attack descending
            int[][] ordered = properties.OrderByDescending(i => i[0]).ToArray();
            int currentAttackLevel = ordered[0][0];
            int maxDefense = 0;
            int currentLevelMaxDefense = 0;
            int count = 0;
            for (int i = 0; i < ordered.Length; i++)
            {
                // If we are still in the first (highest attack) group, just record
                // the defense value for highest defender in the group
                if (ordered[i][0] == currentAttackLevel)
                {
                    currentLevelMaxDefense = Math.Max(currentLevelMaxDefense, ordered[i][1]);
                    //Console.WriteLine($"{i}, setting currentLevelMaxDefense to {currentLevelMaxDefense}");
                }
                else
                {
                    // We have stepped down an attack level. Set the maxDefense seen so far
                    // and reset the current level values
                    maxDefense = Math.Max(maxDefense, currentLevelMaxDefense);
                    currentLevelMaxDefense = ordered[i][1];
                    currentAttackLevel = ordered[i][0];
                }
                //Console.WriteLine($"Checking if weaker, {i}, {ordered[i][1]} < {maxDefense}?");
                if (ordered[i][1] < maxDefense)
                {
                    count++;
                }
            }
            return count;
        }
    }
}