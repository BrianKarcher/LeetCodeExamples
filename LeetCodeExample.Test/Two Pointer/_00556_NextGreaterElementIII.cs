using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given a positive integer n, find the smallest integer which has exactly the same digits existing in the integer n and is greater in value than n.If no such positive integer exists, return -1.

//Note that the returned integer should fit in 32-bit integer, if there is a valid answer but it does not fit in 32-bit integer, return -1.
/// </summary>
public class _00556_NextGreaterElementIII
{
    public int NextGreaterElement(int n)
    {
        char[] c = n.ToString().ToCharArray();
        int i = c.Length - 2;
        // Find first decreasing digit.
        while (i >= 0 && c[i + 1] <= c[i])
        {
            i--;
        }
        if (i < 0)
        {
            return -1;
        }
        // Find minimum digit for c[i] after c[i].
        int j = c.Length - 1;
        while (c[j] <= c[i])
        {
            j--;
        }
        Swap(c, i, j);
        // Reverse the digits after i.
        Reverse(c, i + 1);
        if (!Int32.TryParse(c, out int val))
        {
            return -1;
        }
        return val;
    }

    void Reverse(char[] c, int start)
    {
        int i = start;
        int j = c.Length - 1;
        while (i <= j)
        {
            Swap(c, i, j);
            i++;
            j--;
        }
    }

    void Swap(char[] c, int i, int j)
    {
        char temp = c[i];
        c[i] = c[j];
        c[j] = temp;
    }
}