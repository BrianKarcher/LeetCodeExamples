using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test;

/// <summary>
//Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.
//You can return the answer in any order.
/// </summary>
public class _00289_GameOfLife
{
    public void GameOfLife(int[][] board)
    {
        // In order to do all calculations in-place we will have a few more states.
        // 0 - dead
        // 1 - alive.
        // 2 - was alive, now dead.
        // 3 - was dead, now alive.
        List<(int r, int c)> dirs = new() { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                int nCount = 0;
                foreach ((int r, int c) in dirs)
                {
                    int newR = i + r;
                    int newC = j + c;
                    if (newR < 0 || newC < 0 || newR >= board.Length || newC >= board[0].Length)
                    {
                        continue;
                    }
                    if (board[newR][newC] == 1 || board[newR][newC] == 2)
                        nCount++;
                }
                int current = board[i][j];
                bool isAlive = current == 1 || current == 2;
                int next = 0;
                if (current == 1 && nCount < 2)
                    next = 2;
                else if (current == 1 && (nCount == 2 || nCount == 3))
                    next = 1;
                else if (current == 1 && nCount > 3)
                    next = 2;
                else if (current == 0 && nCount == 3)
                    next = 3;
                else
                    next = current;

                board[i][j] = next;
            }
        }

        // We need to mutate the existing board.
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (board[i][j] == 2)
                    board[i][j] = 0;
                else if (board[i][j] == 3)
                    board[i][j] = 1;
            }
        }
    }
}