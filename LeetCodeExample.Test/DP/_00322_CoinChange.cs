using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
    //Return the fewest number of coins that you need to make up that amount.If that amount of money cannot be made up by any combination of the coins, return -1.

    //You may assume that you have an infinite number of each kind of coin.
    /// </summary>
    public class _00322_CoinChange
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0)
                return 0;
            Queue<int> q = new Queue<int>();
            q.Enqueue(amount);
            //Console.WriteLine($"Queueing {amount}");
            int size = 0;
            HashSet<int> hash = new HashSet<int>();
            hash.Add(amount);
            while (q.Count != 0)
            {
                size++;
                int count = q.Count;
                for (int i = 0; i < count; i++)
                {
                    int amt = q.Dequeue();
                    for (int j = 0; j < coins.Length; j++)
                    {
                        int newamt = amt - coins[j];
                        if (hash.Contains(newamt))
                        {
                            continue;
                        }
                        // Note: We dismiss amounts if they go below 0
                        if (newamt == 0)
                        {
                            return size;
                        }
                        else if (newamt > 0)
                        {
                            q.Enqueue(newamt);
                            hash.Add(newamt);
                            //Console.WriteLine($"Queueing {newamt}");
                        }
                    }
                }
            }
            return -1;
        }
    }
}