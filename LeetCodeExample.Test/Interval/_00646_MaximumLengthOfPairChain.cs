using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are given an array of n pairs pairs where pairs[i] = [lefti, righti]
    //    and lefti<righti.

    //A pair p2 = [c, d] follows a pair p1 = [a, b] if b<c.A chain of pairs can be formed in this fashion.

    //    Return the length longest chain which can be formed.

    //    You do not need to use up all the given intervals.You can select pairs in any order.
    /// </summary>
    public class _00646_MaximumLengthOfPairChain
    {
        public int FindLongestChain(int[][] pairs)
        {
            pairs = pairs.OrderBy(i => i[0]).ToArray();
            int max = 1;
            int preEnd = pairs[0][1];
            for (int i = 1; i < pairs.Length; i++)
            {
                if (pairs[i][0] > preEnd)
                {
                    max++;
                    preEnd = pairs[i][1];
                }
                else
                {
                    preEnd = Math.Min(preEnd, pairs[i][1]);
                }
            }
            return max;
        }

        public int FindLongestChain2(int[][] pairs)
        {
            pairs = pairs.OrderBy(i => i[0]).ToArray();
            int[] dp = new int[pairs.Length];
            dp[0] = 1;
            int max = 1;
            for (int i = 1; i < pairs.Length; i++)
            {
                int sub = 1;
                for (int j = 0; j < i; j++)
                {
                    // If this pair starts after the previous pair ends
                    // They can be chained
                    if (pairs[i][0] > pairs[j][1])
                    {
                        sub = Math.Max(sub, dp[j] + 1);
                    }
                }
                dp[i] = sub;
                max = Math.Max(max, sub);
            }
            return max;
        }
    }
}