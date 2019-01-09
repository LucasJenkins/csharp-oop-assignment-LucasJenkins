using System;
using System.Collections.Generic;
using CsharpOopAssignment;

namespace CsharpOopAssignmentTests
{
    public class RationalGenerator
    {
        public static IEnumerable<object[]> GenerateRational()
        {
            List<object[]> list = new List<object[]>();

            for (var i = 0; i < 3; i++)
            {
                Random random = new Random();
                int n = getRandomInt();
                int d = getRandomNonZeroInt();
                list.Add(new object[] {new Rational(n, d), n, d});
            }

            return list;
        }

        public static IEnumerable<object[]> GenerateTwoRational()
        {
            return new List<object[]>
            {
                new object[]
                {
                    new Rational(getRandomInt(), getRandomNonZeroInt()),
                    new Rational(getRandomInt(), getRandomNonZeroInt())
                }
            };
        }

        private static int getRandomNonZeroInt()
        {
            Random random = new Random();
            int d;
            do
            {
                d = random.Next();
            } while (d == 0);

            return d;
        }

        private static int getRandomInt()
        {
            Random random = new Random();
            return random.Next();
        }
    }
}