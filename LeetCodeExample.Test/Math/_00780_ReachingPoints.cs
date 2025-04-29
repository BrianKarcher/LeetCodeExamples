using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given four integers sx, sy, tx, and ty, return true if it is possible to convert the point(sx, sy) to the point(tx, ty) through some operations, or false otherwise.

//The allowed operation on some point(x, y) is to convert it to either(x, x + y) or(x + y, y).
/// </summary>
public class _00780_ReachingPoints
{
    public bool ReachingPoints(int sx, int sy, int tx, int ty)
    {
        while (tx >= sx && ty >= sy)
        {
            if (tx == ty)
                break;
            if (tx > ty)
            {
                if (ty > sy) tx %= ty;
                else return (tx - sx) % ty == 0;
            }
            else
            {
                if (tx > sx) ty %= tx;
                else return (ty - sy) % tx == 0;
            }
        }
        return tx == sx && ty == sy;
    }
}