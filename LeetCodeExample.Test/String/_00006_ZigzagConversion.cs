using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

    //P A H N
    //A P L S I I G
    //Y I R
    //And then read line by line: "PAHNAPLSIIGYIR"

    //Write the code that will take a string and make this conversion given a number of rows:

    //string convert(string s, int numRows);
    /// </summary>
    /// 

    // Looking back, WTF was I thinking?
    public class _00006_ZigzagConversion
    {
        public string Convert(string s, int numRows)
        {
            List<string> rows = new List<string>(numRows);
            for (int j = 0; j < numRows; j++)
            {
                rows.Add(string.Empty);
            }
            int row = 0;
            int i = 0;
            while (i < s.Length)
            {
                // Go down
                while (i < s.Length && row < numRows)
                {
                    rows[row] += s[i];
                    //Console.WriteLine($"Row: {row}, i: {i}");
                    row++;
                    i++;
                }
                row = Math.Max(rows.Count - 2, 0);
                // zigzag up
                while (i < s.Length && row >= 0)
                {
                    //Console.WriteLine($"Row: {row}, i: {i}");
                    rows[row] += s[i];
                    row--;
                    i++;
                }
                row = Math.Min(1, rows.Count - 1);
            }
            string rtn = string.Empty;
            for (int j = 0; j < rows.Count; j++)
            {
                //Console.WriteLine(rows[j]);
                rtn += rows[j];
            }
            return rtn;
        }
    }
}