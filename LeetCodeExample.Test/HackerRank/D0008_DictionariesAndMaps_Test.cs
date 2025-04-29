using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    /// <summary>
    //Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //You can return the answer in any order.
    /// </summary>
    public class D0008_DictionariesAndMaps_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //Main(new string[] { "3", "sam 99912222", "tom 11122222", "harry 12299933", "sam", "edward", "harry" });
            //Assert.AreEqual(0, answer[0]);
            
        }

        void Main2(String[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            //int count = Int32.Parse(args[0]);
            int count = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] split = Console.ReadLine().Split(' ');
                dict.Add(split[0], split[1]);
            }

            string input = Console.ReadLine();

            while (input != null)
            {
                if (!dict.ContainsKey(input))
                    Console.WriteLine("Not found");
                else
                    Console.WriteLine(input + "=" + dict[input]);
                input = Console.ReadLine();
            }
        }
    }
}