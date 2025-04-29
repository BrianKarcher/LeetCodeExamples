using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace LeetCodeExample.Test.Google
{
    /// <summary>
    //    Design a logger system that receives a stream of messages along with their timestamps.Each unique message should only be printed at most every 10 seconds (i.e.a message printed at timestamp t will prevent other identical messages from being printed until timestamp t + 10).

    //All messages will come in chronological order.Several messages may arrive at the same timestamp.

    //Implement the Logger class:

    //Logger() Initializes the logger object.
    //bool shouldPrintMessage(int timestamp, string message) Returns true if the message should be printed in the given timestamp, otherwise returns false.
    /// </summary>
    public class _00359_LoggerRateLimiter_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
        }

        // Message : timestamp
        Dictionary<string, int> timer = new Dictionary<string, int>();

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (!timer.ContainsKey(message))
            {
                timer.Add(message, timestamp);
                return true;
            }
            int prevTimestamp = timer[message];
            if (timestamp - prevTimestamp < 10)
                return false;

            timer[message] = timestamp;
            return true;
        }
    }
}