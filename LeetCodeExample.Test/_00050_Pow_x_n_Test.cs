using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCodeExample.Test
{
    public class _00050_Pow_x_n_Test
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
            Assert.AreEqual(1, answer, 0.0001);
            answer = MyPow(2.0000, 10);
            Assert.AreEqual(1024, answer, 0.0001);
            answer = MyPow(2.1, 3);
            Assert.AreEqual(9.261d, answer, 0.0001);
            answer = MyPow(2, -2);
            Assert.AreEqual(0.25d, answer, 0.0001);

            answer = MyPow(2.00000, -2147483648);
            Assert.AreEqual(0.00000d, answer, 0.0001);
        }

        //public double MyPow(double x, int n)
        //{
        //    if (n == 0)
        //        return 1;
        //    double currentPower = 1;
        //    var absolutePow = n < 0 ? -n : n;
        //    for (var i = 0; i < absolutePow; i++)
        //    {
        //        currentPower *= x;
        //    }
        //    if (n < 0)
        //        currentPower = 1 / currentPower;
        //    return currentPower;
        //}

        public double MyPow(double x, int n)
        {
            if (n == 0)
                return 1;
            long N = n;
            if (n < 0)
            {
                x = 1 / x;
                N = N * -1;
            }
            double currentPower = x;
            long pow = N;
            double oddCarryover = 1;

            while (pow > 1)
            {
                // If it's odd
                if (pow % 2 == 1)
                {
                    oddCarryover *= currentPower;
                }
                // The bread and butter - Logarithmic time!!!
                currentPower = currentPower * currentPower;
                pow /= 2;
            }

            currentPower *= oddCarryover;

            return currentPower;
        }
    }
}