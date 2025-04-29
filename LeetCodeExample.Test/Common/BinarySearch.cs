using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeExample.Test.Common
{
    class BinarySearch
    {
        // Recursive
        public bool BinarySearchRecursive(int[] array, int x, int left, int right)
        {
            if (left > right)
                return false;
            int midIdx = (left + right) / 2;
            int mid = array[midIdx];
            if (x == mid)
                return true;
            else if (x < mid)
                return BinarySearchRecursive(array, x, left, midIdx - 1);
            else
                return BinarySearchRecursive(array, x, midIdx + 1, right);
        }

        public bool BinarySearchRecursive(int[] array, int x)
        {
            return BinarySearchRecursive(array, x, 0, array.Length - 1);
        }

        // Iteratively
        public bool BinarySearchIterative(int[] array, int x)
        {
            if (array == null || array.Length == 0)
                return false;

            int l = 0;
            int r = array.Length - 1;
            while (l <= r)
            {
                int midIdx = l + (r - l) / 2;
                if (x == array[midIdx])
                    return true;
                else if (x < array[midIdx])
                    r = midIdx - 1;
                else
                    l = midIdx + 1;
            }
            return false;
        }
    }
}
