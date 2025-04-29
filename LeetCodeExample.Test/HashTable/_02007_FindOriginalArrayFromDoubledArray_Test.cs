using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    // An integer array original is transformed into a doubled array changed by appending twice the value of every element in original, and then randomly shuffling the resulting array.
    // Given an array changed, return original if changed is a doubled array.If changed is not a doubled array, return an empty array.The elements in original may be returned in any order.
    /// </summary>
    public class _02007_FindOriginalArrayFromDoubledArray_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        public int[] FindOriginalArray(int[] changed)
        {
            // Ensures the smaller value will always come before its doubled value
            var ordered = changed.OrderBy(i => i).ToList();

            //HashSet<int> smallerValues = new HashSet<int>();

            // value : count
            Dictionary<int, int> smallerValues = new Dictionary<int, int>();

            List<int> rtn = new List<int>();
            for (int i = 0; i < ordered.Count; i++)
            {
                // Can only halve even numbers
                if (ordered[i] % 2 == 0)
                {
                    // Try to locate the halved value
                    int halvedValue = ordered[i] / 2;
                    if (smallerValues.ContainsKey(halvedValue) && smallerValues[halvedValue] > 0)
                    {
                        rtn.Add(halvedValue);
                        //smallerValues.Remove(halvedValue);
                        smallerValues[halvedValue]--;
                        continue;
                    }
                }
                if (smallerValues.ContainsKey(ordered[i]))
                    smallerValues[ordered[i]]++;
                else
                    smallerValues.Add(ordered[i], 1);
            }

            // return an empty list if the array is invalid
            // All counts must return to zero for a successful doubling
            foreach (var val in smallerValues)
            {
                if (val.Value != 0)
                    return new int[0];
            }

            return rtn.ToArray();
        }
    }
}