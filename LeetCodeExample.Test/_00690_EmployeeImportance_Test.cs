using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
        //    You have a data structure of employee information, which includes the employee's unique id, their importance value, and their direct subordinates' id.
        //    You are given an array of employees employees where:
        //employees[i].id is the ID of the ith employee.
        //employees[i].importance is the importance value of the ith employee.
        //employees[i].subordinates is a list of the IDs of the subordinates of the ith employee.
        //Given an integer id that represents the ID of an employee, return the total importance value of this employee and all their subordinates.
    /// </summary>
    
    // Took 12 minutes.
    public class _00690_EmployeeImportance_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            //var answer = TwoSum(new int[] { 2, 7, 11, 15 }, 9);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);

            //answer = TwoSum(new int[] { 3, 2, 4 }, 6);
            //Assert.AreEqual(1, answer[0]);
            //Assert.AreEqual(2, answer[1]);

            //answer = TwoSum(new int[] { 3, 3 }, 6);
            //Assert.AreEqual(0, answer[0]);
            //Assert.AreEqual(1, answer[1]);
        }

        public int GetImportance(IList<Employee> employees, int id)
        {
            // Build a Dictionary for fast lookup
            Dictionary<int, Employee> dict = new Dictionary<int, Employee>();
            for (int i = 0; i < employees.Count; i++)
            {
                dict.Add(employees[i].id, employees[i]);
            }

            // Find the employee. There's no indication of where to go in the tree so search everywhere.
            Employee root = dict[id];

            // Sum up the importance of them and their subordinates.

            Queue<Employee> queue = new Queue<Employee>();
            queue.Enqueue(root);
            int importance = 0;
            while (queue.Any())
            {
                var employee = queue.Dequeue();
                importance += employee.importance;
                for (int k = 0; k < employee.subordinates.Count; k++)
                {
                    queue.Enqueue(dict[employee.subordinates[k]]);
                }
                
            }
            return importance;
        }

        // Definition for Employee.
        public class Employee
        {
            public int id;
            public int importance;
            public IList<int> subordinates;
        }
    }
}