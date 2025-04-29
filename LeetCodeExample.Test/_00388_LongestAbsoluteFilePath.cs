using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Suppose we have a file system that stores both files and directories.An example of one system is represented in the following picture:
    /// </summary>
    public class _00388_LongestAbsoluteFilePath
    {
        List<string> split;
        public int LengthLongestPath(string input)
        {
            int lengthLongestPath = 0;
            split = input.Split("\n", System.StringSplitOptions.None).ToList();

            Stack<string> stack = new Stack<string>();
            int currentPathLength = 0;
            int currentTabCount = -1;

            for (int i = 0; i < split.Count; i++)
            {
                string path = split[i];
                int tabCount = 0;

                while (path[tabCount] == '\t')
                {
                    tabCount++;
                }

                while (currentTabCount >= tabCount)
                {
                    currentPathLength -= stack.Pop().Length;
                    currentTabCount--;
                }

                String s = split[i].Substring(tabCount) + '/';

                // Is this a file?
                if (s.Contains('.'))
                {
                    // - 1 because we added '/' at the end
                    lengthLongestPath = Math.Max(lengthLongestPath, currentPathLength + s.Length - 1);
                }

                stack.Push(s);
                currentPathLength += s.Length;
                currentTabCount++;
            }

            return lengthLongestPath;
        }
    }