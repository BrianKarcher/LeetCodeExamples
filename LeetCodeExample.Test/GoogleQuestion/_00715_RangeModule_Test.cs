using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
   // A Range Module is a module that tracks ranges of numbers.Design a data structure to track the ranges represented as half-open intervals and query about them.
   // A half-open interval [left, right) denotes all the real numbers x where left <= x<right.
   // Implement the RangeModule class:
   // RangeModule() Initializes the object of the data structure.
   // void addRange(int left, int right) Adds the half-open interval[left, right), tracking every real number in that interval.Adding an interval that partially overlaps with currently tracked numbers should add any numbers in the interval[left, right) that are not already tracked.
   // boolean queryRange(int left, int right) Returns true if every real number in the interval[left, right) is currently being tracked, and false otherwise.
   // void removeRange(int left, int right) Stops tracking every real number currently being tracked in the half - open interval[left, right).
    /// </summary>
    public class _00715_RangeModule_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            RangeModule rangeModule = new RangeModule();
            rangeModule.AddRange(10, 20);
            rangeModule.RemoveRange(14, 16);
            var answer = rangeModule.QueryRange(10, 14); // return True,(Every number in [10, 14) is being tracked)
            Assert.IsTrue(answer);
            answer = rangeModule.QueryRange(13, 15); // return False,(Numbers like 14, 14.03, 14.17 in [13, 15) are not being tracked)
            Assert.IsFalse(answer);
            answer = rangeModule.QueryRange(16, 17); // return True, (The number 16 in [16, 17) is still being tracked, despite the remove operation)
            Assert.IsTrue(answer);

            rangeModule = new RangeModule();
            rangeModule.AddRange(10, 180);
            rangeModule.AddRange(150, 200);
            rangeModule.AddRange(250, 500);
            rangeModule.QueryRange(50, 100);
            rangeModule.QueryRange(180, 300);
            rangeModule.QueryRange(600, 1000);
            rangeModule.RemoveRange(50, 150);
            answer = rangeModule.QueryRange(50, 100);
            Assert.IsFalse(answer);

            rangeModule = new RangeModule();
            rangeModule.AddRange(5, 8);
            rangeModule.QueryRange(3, 4);
            rangeModule.RemoveRange(5, 6);
            rangeModule.RemoveRange(3, 6);
            rangeModule.AddRange(1, 3);
            rangeModule.QueryRange(2, 3);
            rangeModule.AddRange(4, 8);
            rangeModule.QueryRange(2, 3);
            rangeModule.RemoveRange(4, 9);

            rangeModule = new RangeModule();
            rangeModule.AddRange(8, 9);
            answer = rangeModule.QueryRange(1, 8);
            rangeModule.RemoveRange(1, 8);
            answer = rangeModule.QueryRange(5, 8);
            rangeModule.RemoveRange(3, 9);
            rangeModule.AddRange(8, 9);
            answer = rangeModule.QueryRange(4, 5);
            rangeModule.RemoveRange(2, 9);
            rangeModule.AddRange(5, 6);
        }

        // RULE: Never allow two ranges to overlap, merge or split if needed
        public class RangeModule
        {
            // left : (left,right)
            private SortedList<int, (int Left, int Right)> _list;

            public RangeModule()
            {
                _list = new SortedList<int, (int Left, int Right)>();
            }

            public void AddRange(int left, int right)
            {
                // Find and merge any overlappers
                // There can be many overlaps
                while (FindOverlappingRange(left, right, out var overlapTupleIndex))
                {
                    var overlapTuple = _list.Values[overlapTupleIndex];
                    left = Math.Min(left, overlapTuple.Left);
                    right = Math.Max(right, overlapTuple.Right);
                    // Remove the overlapped tuple since it has been merged
                    _list.RemoveAt(overlapTupleIndex);
                }

                // Add the tuple, key is the Middle of the range
                _list.Add(left, (left, right));
            }

            // Returns the index of the overlapping range
            private bool FindOverlappingRange(int left, int right, out int index)
            {
                index = -1;
                if (!_list.Any())
                    return false;
                // Do a binary search - the list is sorted

                int lIndex = 0;
                int rIndex = _list.Count() - 1;

                while (lIndex <= rIndex)
                {
                    int middle = (lIndex + rIndex) / 2;
                    var tuple = _list.Values[middle];
                    if (right < tuple.Left)
                    {
                        // Shift window to the left
                        rIndex = middle - 1;
                    }
                    else if (left > tuple.Right)
                    {
                        // Shift window to the right
                        lIndex = middle + 1;
                    }
                    else
                    {
                        // Found a match!
                        index = middle;
                        return true;
                    }
                }

                return false;
            }

            public bool QueryRange(int left, int right)
            {
                if (!FindOverlappingRange(left, right, out var overlapIndex))
                    return false;

                // Make sure it is an exact overlap
                var overlap = _list.Values[overlapIndex];
                return left >= overlap.Left && right <= overlap.Right;
            }

            public void RemoveRange(int left, int right)
            {
                if (right - left <= 1)
                    return;
                // Find and remove any overlappers
                // There can be many overlaps
                while (FindOverlappingRange(left + 1, right - 1, out var overlapTupleIndex))
                {
                    var overlapTuple = _list.Values[overlapTupleIndex];
                    // If the range is completely within the left and right, remove it from the list
                    if (left <= overlapTuple.Left && right >= overlapTuple.Right)
                    {
                        _list.RemoveAt(overlapTupleIndex);
                        continue;
                    }
                    else if (left > overlapTuple.Left && right < overlapTuple.Right)
                    {
                        // Range to remove falls completely within the tuple
                        // Split the tuple into two
                        _list.RemoveAt(overlapTupleIndex);
                        // Add the section on the left
                        AddRange(overlapTuple.Left, left);
                        // Add the section on the right
                        //AddRange(overlapTuple.Right - 1, right);
                        AddRange(right, overlapTuple.Right);
                        continue;
                    }
                    if (left < overlapTuple.Right)
                    {
                        // Remove and add to recalculate the "middle" key
                        _list.RemoveAt(overlapTupleIndex);
                        overlapTuple.Right = left - 1;
                        AddRange(overlapTuple.Left, overlapTuple.Right);
                    }
                    if (right > overlapTuple.Left)
                    {
                        // Remove and add to recalculate the "middle" key
                        _list.RemoveAt(overlapTupleIndex);
                        overlapTuple.Left = right + 1;
                        AddRange(overlapTuple.Left, overlapTuple.Right);
                    }
                }
            }
        }
    }
}