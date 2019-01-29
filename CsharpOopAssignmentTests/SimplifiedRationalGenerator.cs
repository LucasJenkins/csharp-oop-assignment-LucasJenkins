using System;
using System.Collections.Generic;
using System.Linq;
using CsharpOopAssignment;

namespace CsharpOopAssignmentTests
{
    public class SimplifiedRationalGenerator
    {
        public static int Euclid(int n, int m)
        {
            while (m != 0)
            {
                var t = m;
                m = n % m;
                n = t;
            }

            return n;
        }

        public static int[] Collapse(int t, int b)
        {
            var e = t != 0 ? Euclid(Math.Abs(t), Math.Abs(b)) : 1;
            return new int[]{t / e, b / e};
        }

        public static IEnumerable<object[]> GenerateRational()
        {
            List<object[]> list = new List<object[]>();

            for (var i = 0; i < 3; i++)
            {
                Random random = new Random();
                var n = getRandomInt();
                var d = getRandomNonZeroInt();
                var simplified = Collapse(n, d);
                list.Add(new object[] {new SimplifiedRational(simplified[0], simplified[1]), simplified[0], simplified[1]});
            }

            return list;
        }

        public static IEnumerable<object[]> GenerateTwoRational()
        {
            List<object[]> rationals = GenerateRational() as List<object[]>;
            return new List<object[]>
            {
                new[]
                {
                    rationals.ToArray()[0][0],
                    rationals.ToArray()[1][0]
                }
            };
        }
            

        public static IEnumerable<object[]> GenerateSingleInts() =>
            new List<object[]>
            {
                new object[] {getRandomInt()},
                new object[] {getRandomInt()},
                new object[] {getRandomInt()}
            };
        
        public static IEnumerable<object[]> GenerateDoubleInts() =>
            new List<object[]>
            {
                new object[] {getRandomInt(), getRandomInt()},
                new object[] {getRandomInt(), getRandomInt()},
                new object[] {getRandomInt(), getRandomInt()}
            };
        
        public static IEnumerable<object[]> GenerateDoubleIntsWithNonZero() =>
            new List<object[]>
            {
                new object[] {getRandomInt(), getRandomNonZeroInt()},
                new object[] {getRandomInt(), getRandomNonZeroInt()},
                new object[] {getRandomInt(), getRandomNonZeroInt()}
            };
        
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