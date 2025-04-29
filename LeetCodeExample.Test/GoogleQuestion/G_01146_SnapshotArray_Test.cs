using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    Implement a SnapshotArray that supports the following interface:

    //    SnapshotArray(int length) initializes an array-like data structure with the given length.Initially, each element equals 0.
    //void set(index, val) sets the element at the given index to be equal to val.
    //    int snap() takes a snapshot of the array and returns the snap_id: the total number of times we called snap() minus 1.
    //int get(index, snap_id) returns the value at the given index, at the time we took the snapshot with the given snap_id
    /// </summary>
    public class SnapshotArray
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {

        }

        List<Dictionary<int, int>> snapshots;
        Dictionary<int, int> current;

        public SnapshotArray(int length)
        {
            current = new Dictionary<int, int>();
            snapshots = new List<Dictionary<int, int>>(50000);
        }

        public void Set(int index, int val)
        {
            if (current.ContainsKey(index))
                current[index] = val;
            else
                current.Add(index, val);
        }

        public int Snap()
        {
            Dictionary<int, int> snapshot = new Dictionary<int, int>();
            foreach (var curr in current)
            {
                snapshot.Add(curr.Key, curr.Value);
            }
            snapshots.Add(snapshot);
            return snapshots.Count - 1;
        }

        public int Get(int index, int snap_id)
        {
            var snapshot = snapshots[snap_id];
            if (!snapshot.ContainsKey(index))
                return 0;
            return snapshot[index];
        }
    }
}