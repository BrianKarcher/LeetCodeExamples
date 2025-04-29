using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Design a time-based key-value data structure that can store multiple values for the same key at different time stamps and retrieve the key's value at a certain timestamp.

    // Implement the TimeMap class:

    // TimeMap() Initializes the object of the data structure.
    // void set(String key, String value, int timestamp) Stores the key key with the value value at the given time timestamp.
    // String get(String key, int timestamp) Returns a value such that set was called previously, with timestamp_prev <= timestamp.If there are multiple such values, it returns the value associated with the largest timestamp_prev.If there are no values, it returns "".
    /// </summary>
    public class _00981_TimeBasedKeyValueStore_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            TimeMap timeMap = new TimeMap();
            timeMap.Set("foo", "bar", 1);  // store the key "foo" and value "bar" along with timestamp = 1.
            var ans = timeMap.Get("foo", 1);         // return "bar"
            Assert.AreEqual("bar", ans);
            timeMap.Get("foo", 3);         // return "bar", since there is no value corresponding to foo at timestamp 3 and timestamp 2, then the only value is at timestamp 1 is "bar".
            timeMap.Set("foo", "bar2", 4); // store the key "foo" and value "ba2r" along with timestamp = 4.
            ans = timeMap.Get("foo", 4);         // return "bar2"
            Assert.AreEqual("bar2", ans);
            ans = timeMap.Get("foo", 5);         // return "bar2"
            Assert.AreEqual("bar2", ans);

            timeMap = new TimeMap();
            timeMap.Set("love", "high", 10);
            timeMap.Set("love", "low", 20);
            ans = timeMap.Get("love", 5);
            Assert.AreEqual("", ans);
            ans = timeMap.Get("love", 10);
            Assert.AreEqual("high", ans);
            ans = timeMap.Get("love", 15);
            Assert.AreEqual("high", ans);
            ans = timeMap.Get("love", 20);
            Assert.AreEqual("low", ans);
            ans = timeMap.Get("love", 25);
            Assert.AreEqual("low", ans);
        }

        public class TimeMap
        {
            private Dictionary<string, List<(int timestamp, string value)>> _kvp;

            /** Initialize your data structure here. */
            public TimeMap()
            {
                _kvp = new Dictionary<string, List<(int timestamp, string value)>>();
            }

            public void Set(string key, string value, int timestamp)
            {
                if (!_kvp.ContainsKey(key))
                {
                    _kvp.Add(key, new List<(int, string)>() {  (timestamp, value) });
                    return;
                }
                var lst = _kvp[key];
                // Per the instructions the timestamps are already sent in order, no need to sort
                lst.Add((timestamp, value));
            }

            public string Get(string key, int timestamp)
            {
                if (!_kvp.ContainsKey(key))
                    return string.Empty;

                var lst = _kvp[key];
                if (lst.Count == 0)
                    return string.Empty;
                // perform a binary search by timestamp
                int lo = 0;
                int hi = lst.Count - 1;
                int rtn = 0;
                while (lo <= hi)
                {
                    int mi = (lo + hi) / 2;
                    int ts = lst[mi].timestamp;
                    if (timestamp < ts)
                    {
                        // Constraint: Returns a value such that set was called previously, with timestamp_prev <= timestamp 
                        // Thus, if we exceed to the upper bound, return the highest value
                        rtn = mi - 1;
                        // Go left
                        hi = mi - 1;
                    }
                    else if (timestamp > ts)
                    {
                        rtn = mi;
                        // Go right
                        lo = mi + 1;
                    }
                    else
                    {
                        rtn = mi;
                        // A match!
                        break;
                    }
                }
                if (hi == -1)
                    return string.Empty;

                return lst[rtn].value;
            }
        }
        /**
         * Your TimeMap object will be instantiated and called as such:
         * TimeMap obj = new TimeMap();
         * obj.Set(key,value,timestamp);
         * string param_2 = obj.Get(key,timestamp);
         */
    }
}