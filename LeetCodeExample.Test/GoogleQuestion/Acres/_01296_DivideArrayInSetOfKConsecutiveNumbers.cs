using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //Given an array of integers nums and a positive integer k, check whether it is possible to divide this array into sets of k consecutive numbers.
    //Return true if it is possible.Otherwise, return false.
    /// </summary>
    public class _01296_DivideArrayInSetOfKConsecutiveNumbers
    {
        public bool IsPossibleDivide(int[] nums, int k)
        {
            // num : count
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], 0);
                dict[nums[i]]++;
            }

            var sortedDict = dict.OrderBy(i => i.Key).ToList();

            while (sortedDict.Count != 0)
            {
                int currentNum = 0;
                // See if we have a group of k consecutive numbers, starting at the bottom
                int count = 0;
                List<int> itemsToRemove = new List<int>();

                for (int i = 0; i < k && i < sortedDict.Count; i++)
                {
                    if (i != 0)
                    {
                        // Non-consecutive? return false
                        if (sortedDict[i].Key != currentNum + 1)
                            return false;
                    }
                    currentNum = sortedDict[i].Key;
                    count++;
                    sortedDict[i] = new KeyValuePair<int, int>(sortedDict[i].Key, sortedDict[i].Value - 1);
                    if (sortedDict[i].Value <= 0)
                        itemsToRemove.Add(i);
                    // If we satisfied the k condition, break out since this group is complete
                    if (count == k)
                        break;
                }
                // We ran out of numbers, didn't complete the last set!
                if (count != k)
                    return false;

                for (int i = itemsToRemove.Count - 1; i >= 0; i--)
                {
                    sortedDict.RemoveAt(itemsToRemove[i]);
                }
            }
            return true;
        }
    }
}