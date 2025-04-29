using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an integer array nums.You must perform exactly one operation where you can replace one element nums[i] with nums[i] * nums[i]. 

    //Return the maximum possible subarray sum after exactly one operation.The subarray must be non-empty.
    /// </summary>
    public class _01746_MaximumSubarraySumAfterOneOperation
    {
        public int MaxSumAfterOperation(int[] nums)
        {
            int dp0 = 0;
            int dp1 = 0;
            int ans = Int32.MinValue;
            foreach (int num in nums)
            {
                int tmp = dp0;
                dp0 = Math.Max(tmp + num, num);
                dp1 = Math.Max(Math.Max(tmp + num * num, //dp0 + num*num
                                        num * num), //subarray start from cur position 
                               dp1 + num); //dp1 + num
                ans = Math.Max(dp1, ans);
            }
            return ans;
        }
    }
}