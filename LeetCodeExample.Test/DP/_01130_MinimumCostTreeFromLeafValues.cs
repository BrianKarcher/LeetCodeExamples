using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given an array arr of positive integers, consider all binary trees such that:

//Each node has either 0 or 2 children;
//The values of arr correspond to the values of each leaf in an in-order traversal of the tree.
//The value of each non-leaf node is equal to the product of the largest leaf value in its left and right subtree, respectively.
//Among all possible binary trees considered, return the smallest possible sum of the values of each non-leaf node.It is guaranteed this sum fits into a 32-bit integer.

//A node is a leaf if and only if it has zero children.
/// </summary>
public class _01130_MinimumCostTreeFromLeafValues
{
    public int mctFromLeafValues(int[] A)
    {
        int res = 0;
        Stack<int> stack = new();
        stack.Push(Int32.MaxValue);
        foreach (int a in A)
        {
            while (stack.Peek() <= a)
            {
                int mid = stack.Pop();
                res += mid * Math.Min(stack.Peek(), a);
            }
            stack.Push(a);
        }
        while (stack.Count() > 2)
        {
            res += stack.Pop() * stack.Peek();
        }
        return res;
    }

    /// <summary>
    /// ///////////////
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public int MctFromLeafValues(int[] arr)
    {
        // The leaves are in-order and this cannot be changed.
        // Create a loop. On each loop, find the minimum product between two 
        // indexes (i and i + 1). Add the product of the two into a result value,
        // then remove the lower of the two values from the array (use a List).
        // Repeat until there are 2 leaves left.

        int ans = 0;
        List<int> lst = arr.ToList();
        while (lst.Count > 2)
        {
            int minProduct = Int32.MaxValue;
            int minProductIndex = -1;
            for (int i = 0; i < lst.Count - 1; i++)
            {
                int prod = lst[i] * lst[i + 1];
                if (prod < minProduct)
                {
                    minProduct = prod;
                    minProductIndex = lst[i] < lst[i + 1] ? i : i + 1;
                }
            }
            //Console.WriteLine($"Adding product {minProduct}");
            ans += minProduct;
            //Console.WriteLine($"removing index {minProductIndex}, adding {lst[minProductIndex]}");
            //ans += lst[minProductIndex];
            //Console.WriteLine($"Removing index {minProductIndex}");
            lst.RemoveAt(minProductIndex);
            //Console.WriteLine($"Ans: {ans}");
        }

        // 2 items left. Prod them and add them.
        //Console.WriteLine($"indexes 0: {lst[0]}, 1: {lst[1]}");
        ans += lst[0] * lst[1];
        //ans += lst[0];
        //ans += lst[1];
        return ans;
    }
}