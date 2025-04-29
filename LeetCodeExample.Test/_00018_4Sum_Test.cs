using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class _00018_4Sum_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            var answer = FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);
            Assert.AreEqual(new List<List<int>>() { new List<int> { -2, -1, 1, 2 },
                new List<int> {-2,0,0,2 }, new List<int> { -1,0,0,1 } }, answer);

            //_matchCheck = new HashSet<(int, int, int, int)>();
            answer = FourSum(new int[] { 2,2,2,2,2 }, 8);
            Assert.AreEqual(new List<List<int>>() { new List<int> { 2,2,2,2 } }, answer);
        }

        //public IList<IList<int>> FourSum(int[] nums, int target)
        //{
        //    if (nums.Length < 4)
        //        return null;

        //    nums = nums.OrderBy(i => i).ToArray();
        //    List<IList<int>> rtn = new List<IList<int>>();

        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        for (int j = i + 1; j < nums.Length; j++)
        //        {
        //            rtn.AddRange(TwoSum(nums, i, j, target - nums[i] - nums[j]));
        //        }
        //    }

        //    return rtn;
        //}

        //// Do a 2-Sum O(n) time
        //public IList<IList<int>> TwoSum(int[] nums, int a, int b, int target)
        //{
        //    int l = b + 1;
        //    int r = nums.Length - 1;
        //    List<IList<int>> rtn = new List<IList<int>>();
        //    while (l < r)
        //    {
        //        var val = nums[l] + nums[r];
        //        if (val < target)
        //            l++;
        //        else if (val > target)
        //            r--;
        //        else
        //        {
        //            var indexArray = new int[] { a, b, l, r };
        //            if (!MatchCheck(indexArray))
        //            {
        //                rtn.Add(new List<int> { nums[a], nums[b], nums[l], nums[r] });
        //            }
        //            r--;
        //        }
        //    }
        //    return rtn;
        //}

        ////HashSet<int> _matchCheck = new HashSet<int>();
        ////public bool MatchCheck(int[] nums)
        ////{
        ////    _matchCheck.Clear();
        ////    for (int i = 0; i < nums.Length; i++)
        ////    {
        ////        if (_matchCheck.Contains(nums[i]))
        ////            return true;
        ////        _matchCheck.Add(nums[i]);
        ////    }
        ////    return false;
        ////}

        //HashSet<(int, int, int, int)> _matchCheck = new HashSet<(int, int, int, int)>();
        //public bool MatchCheck(int a, int b, int c, int d)
        //{
        //    // Easier to do a dupe check when the four numbers are in order
        //    // nums = nums.OrderBy(i => i).ToArray();
        //    //for (int i = 0; i < nums.Length; i++)
        //    //{
        //        if (_matchCheck.Contains((nums[0], nums[1], nums[2], nums[3])))
        //            return true;
        //        _matchCheck.Add((nums[0], nums[1], nums[2], nums[3]));
        //    //}
        //    return false;
        //}

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            nums = nums.OrderBy(i => i).ToArray();
            return kSum(nums, target, 0, 4);
        }

        public List<IList<int>> kSum(int[] nums, int target, int start, int k)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (start == nums.Length || nums[start] * k > target || target > nums[nums.Length - 1] * k)
                return res;
            if (k == 2)
                return twoSum(nums, target, start);

            for (int i = start; i < nums.Length; ++i)
                if (i == start || nums[i - 1] != nums[i])
                    foreach (List<int> subset in kSum(nums, target - nums[i], i + 1, k - 1))
                    {
                        res.Add(new List<int>() { nums[i] });
                        //res.Add(new ArrayList<>(Arrays.asList(nums[i])));
                        (res[res.Count - 1] as List<int>).AddRange(subset);
                        //res.get(res.size() - 1).addAll(subset);
                    }

            return res;
        }

        public List<IList<int>> twoSum(int[] nums, int target, int start)
        {
            List<IList<int>> res = new List<IList<int>>();
            HashSet<int> s = new HashSet<int>();

            for (int i = start; i < nums.Length; ++i)
            {
                if (!res.Any() || res[res.Count - 1][1] != nums[i])
                    if (s.Contains(target - nums[i]))
                    {
                        res.Add(new List<int>() { target - nums[i], nums[i] });
                    }    
                s.Add(nums[i]);
            }

            return res;
        }
    }
}