using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given an integer n, return a string array answer(1-indexed) where:

//answer[i] == "FizzBuzz" if i is divisible by 3 and 5.
//answer[i] == "Fizz" if i is divisible by 3.
//answer[i] == "Buzz" if i is divisible by 5.
//answer[i] == i(as a string) if none of the above conditions are true.
/// </summary>
public class _00412_FizzBuzz
{
    public IList<string> FizzBuzz(int n)
    {
        List<string> rtn = new();
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                rtn.Add("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                rtn.Add("Fizz");
            }
            else if (i % 5 == 0)
            {
                rtn.Add("Buzz");
            }
            else
            {
                rtn.Add(i.ToString());
            }
        }
        return rtn;
    }
}