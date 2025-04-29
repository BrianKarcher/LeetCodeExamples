using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    In a row of dominoes, tops[i] and bottoms[i] represent the top and bottom halves of the ith domino. (A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)

    //We may rotate the ith domino, so that tops[i] and bottoms[i] swap values.

    //Return the minimum number of rotations so that all the values in tops are the same, or all the values in bottoms are the same.

    //If it cannot be done, return -1.
    /// </summary>
    public class _01007_MinDominoRotationsForEqualRow
    {
        public int MinDominoRotations(int[] tops, int[] bottoms)
        {
            // Tally up the counts so we don't have to account for them later if too few
            // num : count
            Dictionary<int, int> nums = new Dictionary<int, int>();
            for (int i = 1; i <= 6; i++)
                nums.Add(i, 0);

            for (int i = 0; i < tops.Length; i++)
            {
                nums[tops[i]]++;
                nums[bottoms[i]]++;
            }

            int minRotations = Int32.MaxValue;
            foreach (var num in nums)
            {
                // Skip the impossibilities
                if (num.Value < tops.Length)
                    continue;
                int rotations = 0;
                // # of rotations from bottom to top
                bool finished = true;
                for (int i = 0; i < tops.Length; i++)
                {
                    if (tops[i] == num.Key)
                        continue;
                    if (bottoms[i] != num.Key)
                    {
                        finished = false;
                        break;
                    }
                    rotations++;
                }
                if (finished)
                    minRotations = Math.Min(minRotations, rotations);

                rotations = 0;
                finished = true;
                for (int i = 0; i < tops.Length; i++)
                {
                    if (bottoms[i] == num.Key)
                        continue;
                    if (tops[i] != num.Key)
                    {
                        finished = false;
                        break;
                    }
                    rotations++;
                }
                if (finished)
                    minRotations = Math.Min(minRotations, rotations);
            }
            return minRotations == Int32.MaxValue ? -1 : minRotations;
        }
    }
}