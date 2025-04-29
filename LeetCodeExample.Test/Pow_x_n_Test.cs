using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    public class Pow_x_n_Test
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            double answer;
            answer = MyPow(5, 0);
            Assert.AreEqual(answer, 1, 0.0001);
            answer = MyPow(2.0000, 10);
            Assert.AreEqual(answer, 1024, 0.0001);
            answer = MyPow(2.1, 3);
            Assert.AreEqual(answer, 9.261d, 0.0001);
            answer = MyPow(2, -2);
            Assert.AreEqual(answer, 0.25d, 0.0001);
        }

        public double MyPow(double x, int n)
        {
            if (n == 0)
                return 1;
            double currentPower = 1;
            var absolutePow = n < 0 ? -n : n;
            for (var i = 0; i < absolutePow; i++)
            {
                currentPower *= x;
            }
            if (n < 0)
                currentPower = 1 / currentPower;
            return currentPower;
        }
    }
}