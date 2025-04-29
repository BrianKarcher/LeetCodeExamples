using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test.Common
{
    public class SegmentTreeMin
    {
        /// <summary>
        /// Creates a Min Segment Tree as an Array. segTree array gets pre-created and populated with the default value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="segTree"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="pos"></param>
        public void ConstructTree(int[] input, int[] segTree, int low, int high, int pos)
        {
            if (low == high)
            {
                segTree[pos] = input[low];
                return;
            }
            int mid = (low + high) / 2;
            ConstructTree(input, segTree, low, mid, 2 * pos + 1);
            ConstructTree(input, segTree, mid + 1, high, 2 * pos + 2);
            // By the time the recursive calls above have run, the segTree values used below will be filled
            segTree[pos] = Math.Min(segTree[2 * pos + 1], segTree[2 * pos + 2]);
        }

        // Figuring out the size of SegTree:
        public int FindSizeOfSegmentTree(int len)
        {
            // If len is power of 2:
            // return len * 2 - 1;
            // Example  : len = 4, so return 4 * 2 - 1 = 7;
            // If len is NOT a power of 2:
            // (Next power of 2) * 2 - 1;
            // Example : len = 5, so return 8 * 2 - 1 = 15;

            return 0;
        }

        public int RangeMinQuery(int[] segTree, int qLow, int qHigh, int low, int high, int pos)
        {
            if (qLow <= low && qHigh >= high) // Total Overlap
            {
                return segTree[pos];
            }
            if (qLow > high || qHigh < low) // No overlap
            {
                return Int32.MaxValue;
            }
            // Not total, not "No", so it's partial overlap, so try both nodes and return the min.
            int mid = (low + high) / 2;
            return Math.Min(RangeMinQuery(segTree, qLow, qHigh, low, mid, 2 * pos + 1),
                RangeMinQuery(segTree, qLow, qHigh, mid + 1, high, 2 * pos + 2));
        }
    }
}
