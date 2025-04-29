using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeExample.Test
{
    /// <summary>
    //    You are implementing a program to use as your calendar.We can add a new event if adding the event will not cause a double booking.
    //A double booking happens when two events have some non-empty intersection (i.e., some moment is common to both events.).
    //The event can be represented as a pair of integers start and end that represents a booking on the half-open interval [start, end), the range of real numbers x such that start <= x<end.
    //Implement the MyCalendar class:

    //MyCalendar() Initializes the calendar object.
    //boolean book(int start, int end) Returns true if the event can be added to the calendar successfully without causing a double booking.Otherwise, return false and do not add the event to the calendar.
    /// </summary>
    public class _00729_MyCalendarI
    {
        //public class MyCalendar
        //{
        //    // key: start, value: end
        //    private SortedSet<int> set = new SortedSet<int>();

        //    public MyCalendar()
        //    {

        //    }

        //    public bool Book(int start, int end)
        //    {
        //        //SortedDictionary<int, int> dict;
        //        //dict.cei
        //        // binary search
        //        //this.set.view
        //        //set.GetViewBetween
        //        int li = BinarySearch(start);
        //        //Console.WriteLine($"bs: {li}");
        //        if (li < 0 || li >= this.list.Count)
        //        {
        //            //Console.WriteLine($"Adding {start}, {end - 1}");
        //            this.list.Add(start, end - 1);
        //            return true;
        //        }
        //        for (int i = li; i < this.list.Count && this.list.Keys[i] <= end; i++)
        //        {
        //            int sv = this.list.Keys[i];
        //            int ev = this.list.Values[i];
        //            //Console.WriteLine($"Comparing {start}, {end} to {sv}, {ev}");
        //            if (sv <= end - 1 && ev >= start)
        //            { // Overlap check
        //                return false;
        //            }
        //        }
        //        //Console.WriteLine($"Adding {start}, {end - 1}");
        //        this.list.Add(start, end - 1);
        //        return true;
        //    }
        //}


        public class MyCalendar2
        {
            // key: start, value: end
            private SortedList<int, int> list;

            public MyCalendar2()
            {
                //SortedDictionary<int, int> dict;
                //dict.
                list = new SortedList<int, int>();
            }

            public bool Book(int start, int end)
            {
                //list.
                // binary search
                int li = BinarySearch(start);
                //Console.WriteLine($"bs: {li}");
                if (li < 0 || li >= this.list.Count)
                {
                    //Console.WriteLine($"Adding {start}, {end - 1}");
                    this.list.Add(start, end - 1);
                    return true;
                }
                for (int i = li; i < this.list.Count && this.list.Keys[i] <= end; i++)
                {
                    int sv = this.list.Keys[i];
                    int ev = this.list.Values[i];
                    //Console.WriteLine($"Comparing {start}, {end} to {sv}, {ev}");
                    if (sv <= end - 1 && ev >= start)
                    { // Overlap check
                        return false;
                    }
                }
                //Console.WriteLine($"Adding {start}, {end - 1}");
                this.list.Add(start, end - 1);
                return true;
            }

            private int BinarySearch(int start)
            {
                int l = 0;
                int r = list.Count - 1;
                while (l <= r)
                {
                    int mid = (l + r) / 2;
                    if (start == this.list.Keys[mid])
                    {
                        //Console.WriteLine($"Found binary search {this.list.Keys[mid]}");
                        return mid;
                    }
                    else if (start < this.list.Keys[mid])
                    {
                        // go left
                        r = mid - 1;
                    }
                    else
                    {
                        // go right
                        l = mid + 1;
                    }
                }
                // Return the index less than or equal to start
                return Math.Max(0, r);
            }
        }
    }
}