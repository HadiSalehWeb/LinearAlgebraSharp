using LinearAlgebra.Scalars;
using System;
using Xunit;

namespace LinearAlgebra.UnitTest.Scalars
{

    /*
     * Note regarding decimals *
     * Apparently decimals aren't regarded as constants in C# and can't be passed as parameters to an 
     * attribute.
     * Seemingly because of that, they can't be passed as a generic parameter to xunit tests, which is why
     * I made separate tests for them. The tests are almost carbon copies of the 'Axioms' with 'decimal'
     * instead of 'T'
     */
    public class DecimalAxioms
    {
        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        public void Associativity(decimal ta, decimal tb, decimal tc)
        {
            Scalar<decimal> a = new Scalar<decimal>(ta), b = new Scalar<decimal>(tb), c = new Scalar<decimal>(tc);

            Assert.Equal(a + (b + c), (a + b) + c);
            Assert.Equal(a * (b * c), (a * b) * c);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        public void Commutativity(decimal ta, decimal tb)
        {
            Scalar<decimal> a = new Scalar<decimal>(ta), b = new Scalar<decimal>(tb);

            Assert.Equal(a + b, b + a);
            Assert.Equal(a * b, b * a);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        public void Distributivity(decimal ta, decimal tb, decimal tc)
        {
            Scalar<decimal> a = new Scalar<decimal>(ta), b = new Scalar<decimal>(tb), c = new Scalar<decimal>(tc);

            Assert.Equal(a * (b + c), (a * b) + (a * c));
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void AdditiveIdentity(decimal ta)
        {
            Scalar<decimal> a = new Scalar<decimal>(ta);

            Assert.Equal(a + Scalar<decimal>.Zero, a);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void MultiplicativeIdentity(decimal ta)
        {
            Scalar<decimal> a = new Scalar<decimal>(ta);

            Assert.Equal(a * Scalar<decimal>.One, a);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void AdditiveInverse(decimal ta)
        {
            Scalar<decimal> a = new Scalar<decimal>(ta);

            Assert.Equal(a + (-a), Scalar<decimal>.Zero);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void MultiplicativeInverse(decimal ta)
        {
            Scalar<decimal> a = new Scalar<decimal>(ta);

            if (a != Scalar<decimal>.Zero)
            {
                var inverse = Scalar<decimal>.One / a;
                var mult = inverse * a;
                var diff = Scalar<decimal>.One - mult;
                var abs = Math.Abs(diff.Value);
                Assert.True(abs <= 0.000000000000000000000000001m);
            }
        }
    }
}
