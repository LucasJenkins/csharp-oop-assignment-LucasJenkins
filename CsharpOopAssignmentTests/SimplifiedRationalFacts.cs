using System;
using System.Collections.Generic;
using CsharpOopAssignment;
using Xunit;

using static CsharpOopAssignmentTests.SimplifiedRationalGenerator;

namespace CsharpOopAssignmentTests
{
    public class SimplifiedRationalFacts
    {
        [Theory]
        [MemberData("GenerateSingleInts", MemberType=typeof(SimplifiedRationalGenerator))]
        public void GcdFailA(int a)
        {
            Assert.Throws<InvalidOperationException>(() => SimplifiedRational.Gcd(a < 0 ? a : -a, 0));
        }
        
        [Theory]
        [MemberData("GenerateSingleInts", MemberType=typeof(SimplifiedRationalGenerator))]
        public void GcdFailB(int b)
        {
            Assert.Throws<InvalidOperationException>(() => SimplifiedRational.Gcd(0, b < 0 ? b : -b));
        }
        
        [Theory]
        [MemberData("GenerateDoubleIntsWithNonZero", MemberType=typeof(SimplifiedRationalGenerator))]
        public void GcdSuccess(int a, int b)
        {
            Assert.Equal(SimplifiedRational.Gcd(a, b), Euclid(a, b));
        }
        
        [Theory]
        [MemberData("GenerateSingleInts", MemberType=typeof(SimplifiedRationalGenerator))]
        public void SimplifyFail(int n)
        {
            Assert.Throws<InvalidOperationException>(() => SimplifiedRational.Simplify(n, 0));
        }
        
        [Theory]
        [MemberData("GenerateDoubleIntsWithNonZero", MemberType=typeof(SimplifiedRationalGenerator))]
        public void SimplifySuccess(int n, int d)
        {
            Assert.Equal(new List<int>(Collapse(n, d)), new List<int>(SimplifiedRational.Simplify(n, d)));
        }
        
        [Fact]
        public void ConstructorFail()
        {
            Assert.Throws<ArgumentException>(() => new SimplifiedRational(1, 0));
        }

        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void ConstructorSuccess(SimplifiedRational rat, int n, int d)
        {
            int[] expected = Collapse(n, d);

            Assert.Equal(rat.Numerator, expected[0]);
            Assert.Equal(rat.Denominator, expected[1]);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void ConstructFail(SimplifiedRational rat, int n, int d)
        {
            Assert.Throws<ArgumentException>(() => rat.Construct(rat.Numerator, 0));
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void ConstructSuccess(SimplifiedRational r, int n, int d)
        {
            SimplifiedRational newR = (SimplifiedRational)r.Construct(r.Numerator, r.Denominator);
            Assert.True(r != newR);
            Assert.Equal(r.Numerator, newR.Numerator);
            Assert.Equal(r.Denominator, newR.Denominator);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void CheckEquals(SimplifiedRational r1, int n, int d)
        {
            Assert.NotNull(r1);

            RationalBase r2 = r1.Construct(r1.Numerator, r1.Denominator).Mul(r1.Construct(2, 2));
            Assert.Equal(r1, r2);

            RationalBase r3 = r2.Construct(r2.Numerator * 3, r2.Denominator * 5).Mul(r2.Construct(3, 5));
            Assert.NotEqual(r1, r3);
            Assert.NotEqual(r2, r3);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void CheckToString(SimplifiedRational r, int num, int den)
        {
            int n = r.Numerator;
            int d = r.Denominator;

            Assert.Equal((n < 0 != d < 0 ? "-" : "") + Math.Abs(n) + "/" + Math.Abs(d), r.ToString());
        }

        [Theory]
        [MemberData("GenerateRational", MemberType = typeof(SimplifiedRationalGenerator))]
        public void Negate(SimplifiedRational r, int n, int d)
        {
            RationalBase result = r.Negate();
            Assert.True(r != result);
            Assert.Equal(new SimplifiedRational(-n, d), result);
        }

        [Theory]
        [MemberData("GenerateRational", MemberType = typeof(SimplifiedRationalGenerator))]
        public void Invert(SimplifiedRational r, int n, int d)
        {
            RationalBase result = r.Invert();
            Assert.True(r != result);
            Assert.Equal(new SimplifiedRational(r.Denominator, r.Numerator), result);
        }

        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void InvertFail(SimplifiedRational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => new SimplifiedRational(0, d).Invert());
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void AddFail(SimplifiedRational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => r.Add(null));
        }
        
        [Theory]
        [MemberData("GenerateTwoRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void Add(SimplifiedRational r1, SimplifiedRational r2)
        {
            RationalBase result = r1.Add(r2);
            Assert.True(r1 != result && r2 != result);
            int n1 = r1.Numerator, d1 = r1.Denominator, n2 = r2.Numerator, d2 = r2.Denominator;
            Assert.Equal(new SimplifiedRational(n1 * d2 + n2 * d1, d1 * d2), result);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void SubFail(SimplifiedRational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => r.Sub(null));
        }
        
        [Theory]
        [MemberData("GenerateTwoRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void Sub(SimplifiedRational r1, SimplifiedRational r2)
        {
            RationalBase result = r1.Sub(r2);
            Assert.True(r1 != result && r2 != result);
            int n1 = r1.Numerator, d1 = r1.Denominator, n2 = r2.Numerator, d2 = r2.Denominator;
            Assert.Equal(new SimplifiedRational(n1 * d2 - n2 * d1, d1 * d2), result);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void MulFail(SimplifiedRational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => r.Mul(null));
        }
        
        [Theory]
        [MemberData("GenerateTwoRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void Mul(SimplifiedRational r1, SimplifiedRational r2)
        {
            RationalBase result = r1.Mul(r2);
            Assert.True(r1 != result && r2 != result);
            int n1 = r1.Numerator, d1 = r1.Denominator, n2 = r2.Numerator, d2 = r2.Denominator;
            Assert.Equal(new SimplifiedRational(n1 * n2, d1 * d2), result);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void DivFail(SimplifiedRational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => r.Div(null));
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void DivZeroFail(SimplifiedRational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => r.Div(new SimplifiedRational(0, 1)));
        }
        
        [Theory]
        [MemberData("GenerateTwoRational", MemberType=typeof(SimplifiedRationalGenerator))]
        public void Div(SimplifiedRational r1, SimplifiedRational r2)
        {
            RationalBase result = r1.Div(r2);
            Assert.True(r1 != result && r2 != result);
            int n1 = r1.Numerator, d1 = r1.Denominator, n2 = r2.Numerator, d2 = r2.Denominator;
            Assert.Equal(new SimplifiedRational(n1 * d2, d1 * n2), result);
        }
        
    }
}