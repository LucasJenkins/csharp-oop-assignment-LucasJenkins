using System;

namespace CsharpOopAssignment
{
    public class SimplifiedRational : RationalBase
    {
        
        /**
         * Determines the greatest common denominator for the given values
         *
         * @param a the first value to consider
         * @param b the second value to consider
         * @return the greatest common denominator, or shared factor, of `a` and `b`
         * @throws ArgumentException if a <= 0 or b <= 0
         */
        public static int Gcd(int a, int b)
        {
            throw new NotImplementedException();
        }

        /**
         * Simplifies the numerator and denominator of a rational value.
         * <p>
         * For example:
         * `simplify(10, 100) = [1, 10]`
         * or:
         * `simplify(0, 10) = [0, 1]`
         *
         * @param numerator   the numerator of the rational value to simplify
         * @param denominator the denominator of the rational value to simplify
         * @return a two element array representation of the simplified numerator and denominator
         * @throws ArgumentException if the given denominator is 0
         */
        public static int[] Simplify(int numerator, int denominator)
        {
            throw new NotImplementedException();
        }

        /**
         * Constructor for rational values of the type:
         * <p>
         * `numerator / denominator`
         * <p>
         * Simplification of numerator/denominator pair should occur in this method.
         * If the numerator is zero, no further simplification can be performed
         *
         * @param numerator   the numerator of the rational value
         * @param denominator the denominator of the rational value
         * @throws ArgumentException if the given denominator is 0
         */
        public SimplifiedRational(int numerator, int denominator) : base(numerator, denominator)
        {
            throw new NotImplementedException();
        }

        /**
		 * Specialized constructor to take advantage of shared code between
		 * Rational and SimplifiedRational
		 * <p>
		 * Essentially, this method allows us to implement most of RationalBase methods
		 * directly in the interface while preserving the underlying type
		 *
		 * @param numerator
		 *            the numerator of the rational value to construct
		 * @param denominator
		 *            the denominator of the rational value to construct
		 * @return the constructed rational value
		 * @throws ArgumentException
		 *             if the given denominator is 0
		 */
        public override RationalBase Construct(int numerator, int denominator)
        {
            throw new NotImplementedException();
        }

        /**
         * @param obj the object to check this against for equality
         * @return true if the given obj is a rational value and its
         * numerator and denominator are equal to this rational value's numerator and denominator,
         * false otherwise
         */
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        /**
         * If this is positive, the string should be of the form `numerator/denominator`
         * <p>
         * If this is negative, the string should be of the form `-numerator/denominator`
         *
         * @return a string representation of this rational value
         */
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}