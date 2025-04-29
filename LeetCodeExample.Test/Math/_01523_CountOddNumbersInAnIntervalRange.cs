using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given two non-negative integers low and high.Return the count of odd numbers between low and high(inclusive).
/// </summary>
public class _01523_CountOddNumbersInAnIntervalRange
{
    public int CountOdds(int low, int high)
    {
        if (low == high)
        {
            return low % 2 == 1 ? 1 : 0;
        }
        int count = 0;
        // The count of odd numbers between two even ones is count / 2 (it rounds down)
        if (low % 2 == 1)
        {
            count++;
            low++;
        }
        if (high % 2 == 1)
        {
            count++;
            high--;
        }
        int diff = high - low;
        // Avoid divide by zero
        if (diff == 0)
        {
            return count + (low % 2 == 1 ? 1 : 0);
        }
        return count + (diff / 2);
    }
}