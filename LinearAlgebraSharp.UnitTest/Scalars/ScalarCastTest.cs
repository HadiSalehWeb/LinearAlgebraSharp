using LinearAlgebraSharp.Scalars;
using System;
using Xunit;

namespace LinearAlgebraSharp.UnitTest.Scalars
{
    public class ScalarCastTest
    {
        [Fact]
        public void TestSbyteCasting()
        {
            Scalar<sbyte> scalar = new Scalar<sbyte>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }

        [Fact]
        public void TestByteCasting()
        {
            Scalar<byte> scalar = new Scalar<byte>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }

        [Fact]
        public void TestShortCasting()
        {
            Scalar<short> scalar = new Scalar<short>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }

        [Fact]
        public void TestUshortCasting()
        {
            Scalar<ushort> scalar = new Scalar<ushort>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }

        [Fact]
        public void TestIntCasting()
        {
            Scalar<int> scalar = new Scalar<int>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }

        [Fact]
        public void TestUintCasting()
        {
            Scalar<uint> scalar = new Scalar<uint>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }

        [Fact]
        public void TestLongCasting()
        {
            Scalar<long> scalar = new Scalar<long>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }

        [Fact]
        public void TestUlongCasting()
        {
            Scalar<ulong> scalar = new Scalar<ulong>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }

        [Fact]
        public void TestFloatCasting()
        {
            Scalar<float> scalar = new Scalar<float>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }

        [Fact]
        public void TestDoubleCasting()
        {
            Scalar<double> scalar = new Scalar<double>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }

        [Fact]
        public void TestDecimalCasting()
        {
            Scalar<decimal> scalar = new Scalar<decimal>(2);

            Assert.Equal(new Scalar<sbyte>(2), scalar.Cast<sbyte>());
            Assert.Equal(new Scalar<byte>(2), scalar.Cast<byte>());
            Assert.Equal(new Scalar<short>(2), scalar.Cast<short>());
            Assert.Equal(new Scalar<ushort>(2), scalar.Cast<ushort>());
            Assert.Equal(new Scalar<int>(2), scalar.Cast<int>());
            Assert.Equal(new Scalar<uint>(2u), scalar.Cast<uint>());
            Assert.Equal(new Scalar<long>(2L), scalar.Cast<long>());
            Assert.Equal(new Scalar<ulong>(2uL), scalar.Cast<ulong>());
            Assert.Equal(new Scalar<float>(2f), scalar.Cast<float>());
            Assert.Equal(new Scalar<double>(2d), scalar.Cast<double>());
            Assert.Equal(new Scalar<decimal>(2m), scalar.Cast<decimal>());
        }
    }
}