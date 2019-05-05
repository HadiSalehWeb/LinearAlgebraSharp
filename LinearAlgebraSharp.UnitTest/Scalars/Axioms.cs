using LinearAlgebraSharp.Scalars;
using System;
using Xunit;

namespace LinearAlgebraSharp.UnitTest.Scalars
{
    /*
     * Note regarding fields "https://en.wikipedia.org/wiki/Field_(mathematics)"
     * Scalars are meant to be part of a field, and Vectors are meant to be part of a vector space.
     * However since fields are only formed on types that correspond to rational or real numbers, all the
     * types except float, double and decimal *don't* form fields, and thus don't obey all the axioms of
     * field (they obey some of them, see semirings, semimodules, rings and modules).
     * 
     * That's why some test cases are commented out.
     */

    public class Axioms
    {
        [Theory]
        [MemberData(nameof(ScalarTestData.SByteData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ByteData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ShortData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UShortData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.IntData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UIntData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.LongData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ULongData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.FloatData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.DoubleData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.DecimalData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        public void Associativity<T>(T ta, T tb, T tc)
            where T : struct
        {
            Scalar<T> a = new Scalar<T>(ta), b = new Scalar<T>(tb), c = new Scalar<T>(tc);

            Assert.Equal(a + (b + c), (a + b) + c);
            Assert.Equal(a * (b * c), (a * b) * c);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.SByteData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ByteData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ShortData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UShortData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.IntData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UIntData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.LongData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ULongData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.FloatData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.DoubleData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.DecimalData), new object[] { 2, 6 }, MemberType = typeof(ScalarTestData))]
        public void Commutativity<T>(T ta, T tb)
            where T : struct
        {
            Scalar<T> a = new Scalar<T>(ta), b = new Scalar<T>(tb);

            Assert.Equal(a + b, b + a);
            Assert.Equal(a * b, b * a);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.SByteData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ByteData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ShortData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UShortData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.IntData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UIntData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.LongData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ULongData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.FloatData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.DoubleData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.DecimalData), new object[] { 3, 6 }, MemberType = typeof(ScalarTestData))]
        public void Distributivity<T>(T ta, T tb, T tc)
            where T : struct
        {
            Scalar<T> a = new Scalar<T>(ta), b = new Scalar<T>(tb), c = new Scalar<T>(tc);

            Assert.Equal(a * (b + c), (a * b) + (a * c));
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.SByteData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ByteData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ShortData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UShortData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.IntData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UIntData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.LongData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ULongData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.FloatData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.DoubleData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void AdditiveIdentity<T>(T ta)
            where T : struct
        {
            Scalar<T> a = new Scalar<T>(ta);

            Assert.Equal(a + Scalar<T>.Zero, a);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.SByteData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ByteData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ShortData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UShortData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.IntData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UIntData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.LongData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ULongData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.FloatData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.DoubleData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void MultiplicativeIdentity<T>(T ta)
            where T : struct
        {
            Scalar<T> a = new Scalar<T>(ta);

            Assert.Equal(a * Scalar<T>.One, a);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.SByteData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.ByteData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ShortData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.UShortData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.IntData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.UIntData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.LongData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.ULongData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.FloatData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.DoubleData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void AdditiveInverse<T>(T ta)
            where T : struct
        {
            Scalar<T> a = new Scalar<T>(ta);

            Assert.Equal(a + (-a), Scalar<T>.Zero);
        }

        [Theory]
        //[MemberData(nameof(ScalarTestData.SByteData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.ByteData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.ShortData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.UShortData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.IntData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.UIntData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.LongData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.ULongData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.FloatData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.DoubleData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        //[MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void MultiplicativeInverse<T>(T ta)
            where T : struct
        {
            Scalar<T> a = new Scalar<T>(ta);

            if (a != Scalar<T>.Zero)
                Assert.Equal(a * (Scalar<T>.One / a), Scalar<T>.One);
        }
    }
}
