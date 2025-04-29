using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Implement the RandomizedSet class:

    //    RandomizedSet() Initializes the RandomizedSet object.
    //bool insert(int val) Inserts an item val into the set if not present.Returns true if the item was not present, false otherwise.
    //    bool remove(int val) Removes an item val from the set if present.Returns true if the item was present, false otherwise.
    //    int getRandom() Returns a random element from the current set of elements (it's guaranteed that at least one element exists when this method is called). Each element must have the same probability of being returned.
    //You must implement the functions of the class such that each function works in average O(1) time complexity.
    /// </summary>
    public class _00380_InsertDeleteGetRandom_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            RandomizedSet randomizedSet = new RandomizedSet();
            var boolRtn = randomizedSet.Insert(1); // Inserts 1 to the set. Returns true as 1 was inserted successfully.
            Assert.AreEqual(true, boolRtn);
            boolRtn = randomizedSet.Remove(2); // Returns false as 2 does not exist in the set.
            Assert.AreEqual(false, boolRtn);
            boolRtn = randomizedSet.Insert(2); // Inserts 2 to the set, returns true. Set now contains [1,2].
            Assert.AreEqual(true, boolRtn);
            var ans = randomizedSet.GetRandom(); // getRandom() should return either 1 or 2 randomly.
            Assert.IsTrue(ans == 1 || ans == 2);
            boolRtn = randomizedSet.Remove(1); // Removes 1 from the set, returns true. Set now contains [2].
            Assert.AreEqual(true, boolRtn);
            boolRtn = randomizedSet.Insert(2); // 2 was already in the set, so return false.
            Assert.AreEqual(false, boolRtn);
            ans = randomizedSet.GetRandom(); // Since 2 is the only number in the set, getRandom() will always return 2.
            Assert.AreEqual(2, ans);
        }

        public class RandomizedSet
        {
            // value : index in list
            Dictionary<int, int> dict;
            List<int> list;

            Random rnd;
            /** Initialize your data structure here. */
            public RandomizedSet()
            {
                dict = new Dictionary<int, int>();
                list = new List<int>();
                rnd = new Random();
            }

            /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
            public bool Insert(int val)
            {
                if (dict.ContainsKey(val))
                    return false;

                list.Add(val);
                dict.Add(val, list.Count - 1);

                return true;
            }

            /** Removes a value from the set. Returns true if the set contained the specified element. */
            public bool Remove(int val)
            {
                if (!dict.ContainsKey(val))
                    return false;

                // move the last element to the place idx of the element to delete
                int lastElement = list[list.Count - 1];
                int index = dict[val];
                list[index] = lastElement;
                dict[lastElement] = index;

                // delete the last element
                list.RemoveAt(list.Count - 1);
                dict.Remove(val);

                return true;
            }

            /** Get a random element from the set. */
            public int GetRandom()
            {
                return list[rnd.Next(list.Count)];
            }
        }
    }
}