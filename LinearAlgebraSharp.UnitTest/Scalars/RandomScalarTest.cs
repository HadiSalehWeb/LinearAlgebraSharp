using LinearAlgebraSharp.Scalars;
using System.Linq;
using Xunit;

namespace LinearAlgebraSharp.UnitTest.Scalars
{
    /// <summary>
    /// Because the behaviour under testing is random there will a be a very small chance that a test fails although the 
    /// code is function or vise versa, but you know that's like. The higher sampleCount is, the lower this likelihood.
    /// </summary>
    public class RandomScalarTest
    {
        const int sampleCount = 1000;

        [Theory]
        [MemberData(nameof(ScalarTestData.SByteData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ByteData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ShortData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UShortData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.IntData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UIntData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.LongData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ULongData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void TestRingRandom01<T>(T _)
            where T : struct
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            RandomScalar<T> rand = new RandomScalar<T>(0);
            var scalars = Enumerable.Range(0, sampleCount).Select(x => rand.NextBetweenZeroOne());

            Assert.True(scalars.All(x => x == Scalar<T>.One || x == Scalar<T>.Zero));
            Assert.Contains(scalars, x => x == Scalar<T>.One);
            Assert.Contains(scalars, x => x == Scalar<T>.Zero);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.FloatData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.DoubleData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void TestFieldRandom01<T>(T _)
            where T : struct
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            RandomScalar<T> rand = new RandomScalar<T>(0);

            Assert.True(Enumerable.Range(0, sampleCount).Select(x => rand.NextBetweenZeroOne()).All(x =>
                x < Scalar<T>.One && x >= Scalar<T>.Zero
            ));
        }
    }
}
