using System;

namespace CsharpOopAssignment
{
    public class Rational : RationalBase
    {
        /**
         * Constructor for rational values of the type:
         * <p>
         * `numerator / denominator`
         * <p>
         * No simplification of the numerator/denominator pair should occur in this method.
         *
         * @param numerator   the numerator of the rational value
         * @param denominator the denominator of the rational value
         * @throws ArgumentException if the given denominator is 0
         */
        public Rational(int numerator, int denominator) : base(numerator, denominator)
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