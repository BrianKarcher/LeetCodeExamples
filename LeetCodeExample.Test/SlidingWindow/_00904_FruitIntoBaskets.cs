using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are visiting a farm that has a single row of fruit trees arranged from left to right.The trees are represented by an integer array fruits where fruits[i] is the type of fruit the ith tree produces.
    //    You want to collect as much fruit as possible.However, the owner has some strict rules that you must follow:

    //    You only have two baskets, and each basket can only hold a single type of fruit.There is no limit on the amount of fruit each basket can hold.
    //    Starting from any tree of your choice, you must pick exactly one fruit from every tree (including the start tree) while moving to the right.The picked fruits must fit in one of your baskets.
    //Once you reach a tree with fruit that cannot fit in your baskets, you must stop.
    //    Given the integer array fruits, return the maximum number of fruits you can pick.
    /// </summary>
    public class _00904_FruitIntoBaskets
    {
        public int TotalFruit(int[] fruits)
        {
            // type : count
            Dictionary<int, int> baskets = new Dictionary<int, int>();
            int left = 0;

            int max = 0;
            for (int right = 0; right < fruits.Length; right++)
            {
                if (!baskets.ContainsKey(fruits[right]))
                    baskets.Add(fruits[right], 0);
                // Keep count of how many fruits are in a basket
                baskets[fruits[right]]++;
                while (baskets.Count > 2)
                {
                    // Oh oh, too many baskets! Let's move the Left pointer to the right
                    // until a basket is empty, then remove the empty basket
                    baskets[fruits[left]]--;
                    if (baskets[fruits[left]] == 0)
                        baskets.Remove(fruits[left]);
                    left++;
                }

                max = Math.Max(max, right - left + 1);
                //Console.WriteLine($"{left}, {right}, {max}");
            }
            return max;
        }
    }
}