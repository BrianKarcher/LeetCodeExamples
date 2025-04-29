using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You have some coins.The i-th coin has a probability prob[i] of facing heads when tossed.

    //Return the probability that the number of coins facing heads equals target if you toss every coin exactly onc
    /// </summary>
    public class _01230_TossStrangeCoins
    {
        public double ProbabilityOfHeads(double[] prob, int target)
        {
            double[,] dp = new double[prob.Length, target + 1];


            for (int i = 0; i < prob.Length; i++)
            {
                for (int j = 0; j <= target; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            dp[i, j] = 1 - prob[i];
                        }
                        else if (j == 1)
                        {
                            dp[i, j] = prob[i];
                        }
                        continue;
                    }

                    dp[i, j] += prob[i] * (j > 0 ? dp[i - 1, j - 1] : 0);
                    dp[i, j] += (1 - prob[i]) * dp[i - 1, j];
                }
            }

            return dp[prob.Length - 1, target];
        }
        //prob_target=combination(n,target)*p^(target)*(1-p)^(n-target)
        //combination(n,target)=n!/(target!*(n-target)!)
    }
}