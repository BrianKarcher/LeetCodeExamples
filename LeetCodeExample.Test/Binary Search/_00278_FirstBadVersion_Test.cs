using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
       // You are a product manager and currently leading a team to develop a new product.Unfortunately, the latest version of your product fails the quality check.Since each version is developed based on the previous version, all the versions after a bad version are also bad.
       //Suppose you have n versions[1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
       //You are given an API bool isBadVersion(version) which returns whether version is bad.Implement a function to find the first bad version.You should minimize the number of calls to the API.
    /// </summary>
    public class _00278_FirstBadVersion_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //var answer = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);

            //answer = TwoSum(new int[] { 3, 2, 4 }, 6);
            //Assert.AreEqual(1, answer[0]);
            //Assert.AreEqual(2, answer[1]);

            //answer = TwoSum(new int[] { 3, 3 }, 6);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);
        }

        public int FirstBadVersion(int n)
        {
            int l = 0;
            int r = n;
            // 2-space
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                bool thisVersion = IsBadVersion(mid);
                bool nextVersion = IsBadVersion(mid + 1);
                if (!thisVersion && nextVersion)
                    return mid + 1;
                if (thisVersion == false)
                    l = mid + 1;
                else
                    r = mid;
            }
            return l;
        }

        public bool IsBadVersion(int n)
        {
            return true;
        }
    }
}