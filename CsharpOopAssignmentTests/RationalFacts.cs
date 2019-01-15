using System;
using CsharpOopAssignment;
using Xunit;

namespace CsharpOopAssignmentTests
{
    public class RationalFacts
    {
        
        [Fact]
        public void ConstructorFail()
        {
            Assert.Throws<ArgumentException>(() => new Rational(1, 0));
        }

        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void ConstructorSuccess(Rational rat, int n, int d)
        {
            Assert.Equal(rat.GetNumerator(), n);
            Assert.Equal(rat.GetDenominator(), d);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void ConstructFail(Rational rat, int n, int d)
        {
            Assert.Throws<ArgumentException>(() => rat.Construct(rat.GetNumerator(), 0));
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void ConstructSuccess(Rational r, int n, int d)
        {
            Rational newR = (Rational) r.Construct(r.GetNumerator(), r.GetDenominator());
            Assert.True(r != newR);
            Assert.Equal(r.GetNumerator(), newR.GetNumerator());
            Assert.Equal(r.GetDenominator(), newR.GetDenominator());
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void CheckEquals(Rational r1, int n, int d)
        {
            Assert.NotNull(r1);

            Rational r2 = new Rational(r1.GetNumerator(), r1.GetDenominator());
            Assert.Equal(r1, r2);

            Rational r3 = new Rational(r1.GetNumerator() + 1, r1.GetDenominator());
            Assert.NotEqual(r1, r3);
            Assert.NotEqual(r2, r3);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void CheckToString(Rational r, int num, int den)
        {
            int n = r.GetNumerator();
            int d = r.GetDenominator();

            Assert.Equal((n < 0 != d < 0 ? "-" : "") + Math.Abs(n) + "/" + Math.Abs(d), r.ToString());
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void Negate(Rational r, int n, int d)
        {
            RationalBase result = r.Negate();
            Assert.True(r != result);
            Assert.Equal(new Rational(-r.GetNumerator(), r.GetDenominator()), result);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void InvertFail(Rational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => new Rational(0, d).Invert());
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void AddFail(Rational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => r.Add(null));
        }
        
        [Theory]
        [MemberData("GenerateTwoRational", MemberType=typeof(RationalGenerator))]
        public void Add(Rational r1, Rational r2)
        {
            RationalBase result = r1.Add(r2);
            Assert.True(r1 != result && r2 != result);
            int n1 = r1.GetNumerator(), d1 = r1.GetDenominator(), n2 = r2.GetNumerator(), d2 = r2.GetDenominator();
            Assert.Equal(new Rational(n1 * d2 + n2 * d1, d1 * d2), result);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void SubFail(Rational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => r.Sub(null));
        }
        
        [Theory]
        [MemberData("GenerateTwoRational", MemberType=typeof(RationalGenerator))]
        public void Sub(Rational r1, Rational r2)
        {
            RationalBase result = r1.Sub(r2);
            Assert.True(r1 != result && r2 != result);
            int n1 = r1.GetNumerator(), d1 = r1.GetDenominator(), n2 = r2.GetNumerator(), d2 = r2.GetDenominator();
            Assert.Equal(new Rational(n1 * d2 - n2 * d1, d1 * d2), result);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void MulFail(Rational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => r.Mul(null));
        }
        
        [Theory]
        [MemberData("GenerateTwoRational", MemberType=typeof(RationalGenerator))]
        public void Mul(Rational r1, Rational r2)
        {
            RationalBase result = r1.Mul(r2);
            Assert.True(r1 != result && r2 != result);
            int n1 = r1.GetNumerator(), d1 = r1.GetDenominator(), n2 = r2.GetNumerator(), d2 = r2.GetDenominator();
            Assert.Equal(new Rational(n1 * n2, d1 * d2), result);
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void DivFail(Rational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => r.Div(null));
        }
        
        [Theory]
        [MemberData("GenerateRational", MemberType=typeof(RationalGenerator))]
        public void DivZeroFail(Rational r, int n, int d)
        {
            Assert.Throws<InvalidOperationException>(() => r.Div(new Rational(0, 1)));
        }
        
        [Theory]
        [MemberData("GenerateTwoRational", MemberType=typeof(RationalGenerator))]
        public void Div(Rational r1, Rational r2)
        {
            RationalBase result = r1.Div(r2);
            Assert.True(r1 != result && r2 != result);
            int n1 = r1.GetNumerator(), d1 = r1.GetDenominator(), n2 = r2.GetNumerator(), d2 = r2.GetDenominator();
            Assert.Equal(new Rational(n1 * d2, d1 * n2), result);
        }
    }
}











