using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    Given an integer numRows, return the first numRows of Pascal's triangle.

    //In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
    /// </summary>
    public class _00118_PascalsTriangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> rows = new List<IList<int>>();

            List<int> oldRow = new List<int>();

            for (int i = 0; i < numRows; i++)
            {
                List<int> newRow = new List<int>();
                rows.Add(newRow);
                //  Left 1
                newRow.Add(1);
                if (i == 0)
                {
                    oldRow = newRow;
                    continue;
                }

                for (int j = 1; j < i; j++)
                {
                    newRow.Add(oldRow[j - 1] + oldRow[j]);
                }

                // Right 1
                newRow.Add(1);
                oldRow = newRow;
            }
            return rows;
        }

        public IList<IList<int>> Generate2(int numRows)
        {
            List<IList<int>> rtn = new List<IList<int>>();
            List<int> oldList = new List<int> { 1 };
            rtn.Add(oldList);
            for (int i = 2; i <= numRows; i++)
            {
                List<int> newList = new List<int>();
                rtn.Add(newList);
                for (int j = 0; j < i; j++)
                {
                    int firstNum = j == 0 ? 0 : oldList[j - 1];
                    int secondNum = j == i - 1 ? 0 : oldList[j];
                    newList.Add(firstNum + secondNum);
                }
                oldList = newList;
            }
            return rtn;
        }
    }
}