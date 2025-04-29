using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//You are given two positive integers startPos and endPos.Initially, you are standing at position startPos on an infinite number line.With one step, you can move either one position to the left, or one position to the right.

//Given a positive integer k, return the number of different ways to reach the position endPos starting from startPos, such that you perform exactly k steps.Since the answer may be very large, return it modulo 109 + 7.

//Two ways are considered different if the order of the steps made is not exactly the same.

//Note that the number line includes negative integers.
/// </summary>
public class _02400_NumberOfWaysToReachAPositionAfterKSteps
{
    public int NumberOfWays(int startPos, int endPos, int k)
    {
        int mod = 1_000_000_007;

        // The numbers will be offset to the middle of this array to prevent
        // going out of bounds. This is faster than using a Dictionary.
        int arrSize = Math.Abs(endPos - startPos) + (k * 2) + 2;
        Console.WriteLine($"startPos = {startPos}, end = {endPos}, k = {k}, size = {arrSize}");
        int[] arr = new int[arrSize];
        arr[k + 1] = 1;
        for (int count = 0; count < k; count++)
        {
            int[] newArr = new int[arrSize];
            for (int i = 1; i < arrSize - 1; i++)
            {
                newArr[i] = (arr[i - 1] + arr[i + 1]) % mod;
            }
            arr = newArr;
            for (int i = 0; i < arrSize; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
        return arr[k + 1 + Math.Abs(endPos - startPos)];
    }

    public int NumberOfWays2(int startPos, int endPos, int k)
    {
        int mod = 1_000_000_007;
        int smaller = Math.Min(startPos, endPos);
        int bigger = Math.Max(startPos, endPos);
        // Shift so the smaller number is on 0.
        int move = -smaller;
        smaller = 0;
        bigger += move;

        // The numbers will be offset to the middle of this array to prevent
        // going out of bounds. This is faster than using a Dictionary.
        int arrSize = bigger - smaller + (k * 2) + 2;
        //Console.WriteLine($"startPos = {smaller}, end = {bigger}, k = {k}, size = {arrSize}");
        int[] arr = new int[arrSize];
        arr[k + 1 + smaller] = 1;
        for (int count = 0; count < k; count++)
        {
            int[] newArr = new int[arrSize];
            for (int i = 1; i < arrSize - 1; i++)
            {
                newArr[i] = (arr[i - 1] + arr[i + 1]) % mod;
            }
            arr = newArr;
            /*for (int i = 0; i < arrSize; i++) {
                Console.Write(arr[i]);
            }
            Console.WriteLine();*/
        }
        return arr[k + 1 + bigger];
    }
}