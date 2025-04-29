using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    The count-and-say sequence is a sequence of digit strings defined by the recursive formula:

    //countAndSay(1) = "1"
    //countAndSay(n) is the way you would "say" the digit string from countAndSay(n-1), which is then converted into a different digit string.
    //To determine how you "say" a digit string, split it into the minimal number of substrings such that each substring contains exactly one unique digit.Then for each substring, say the number of digits, then say the digit.Finally, concatenate every said digit.
    //For example, the saying and conversion for digit string "3322251":

    //Given a positive integer n, return the nth term of the count-and-say sequence.
    /// </summary>
    public class _00038_CountAndSay
    {
        public string CountAndSay(int n)
        {
            // base case
            string rtn = "1";
            for (int i = 2; i <= n; i++)
            {
                StringBuilder sb = new StringBuilder();
                char prev = rtn[0];
                int count = 1;
                for (int j = 1; j < rtn.Length; j++)
                {
                    if (prev == rtn[j])
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count);
                        sb.Append(prev);
                        count = 1;
                        prev = rtn[j];
                    }
                }
                // There will always be one char/count left over after the loop above
                sb.Append(count);
                sb.Append(prev);
                rtn = sb.ToString();
            }
            return rtn;
        }
    }
}