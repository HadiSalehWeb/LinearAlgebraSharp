using LinearAlgebraSharp.Scalars;
using System;
using System.Collections.Generic;
using Xunit;

namespace LinearAlgebraSharp.UnitTest.Scalars
{
    public class ScalarTest
    {
        [Fact]
        public void TestAlgebraicStructure()
        {
            Assert.Equal(AlgebraicStructure.Semiring, Scalar<byte>.algebraicStructure);
            Assert.Equal(AlgebraicStructure.Semiring, Scalar<ushort>.algebraicStructure);
            Assert.Equal(AlgebraicStructure.Semiring, Scalar<uint>.algebraicStructure);
            Assert.Equal(AlgebraicStructure.Semiring, Scalar<ulong>.algebraicStructure);
            Assert.Equal(AlgebraicStructure.Ring, Scalar<sbyte>.algebraicStructure);
            Assert.Equal(AlgebraicStructure.Ring, Scalar<short>.algebraicStructure);
            Assert.Equal(AlgebraicStructure.Ring, Scalar<int>.algebraicStructure);
            Assert.Equal(AlgebraicStructure.Ring, Scalar<long>.algebraicStructure);
            Assert.Equal(AlgebraicStructure.Field, Scalar<float>.algebraicStructure);
            Assert.Equal(AlgebraicStructure.Field, Scalar<double>.algebraicStructure);
            Assert.Equal(AlgebraicStructure.Field, Scalar<decimal>.algebraicStructure);
        }

        [Fact]
        public void TestStaticConstants()
        {
            Assert.Equal((sbyte)0, Scalar<sbyte>.Zero.Value);
            Assert.Equal((sbyte)1, Scalar<sbyte>.One.Value);
            Assert.Equal((sbyte)-1, Scalar<sbyte>.NegativeOneOrZero.Value);
            Assert.Equal(sbyte.MinValue, Scalar<sbyte>.MinValue.Value);
            Assert.Equal(sbyte.MaxValue, Scalar<sbyte>.MaxValue.Value);

            Assert.Equal((byte)0, Scalar<byte>.Zero.Value);
            Assert.Equal((byte)1, Scalar<byte>.One.Value);
            Assert.Equal((byte)0, Scalar<byte>.NegativeOneOrZero.Value);
            Assert.Equal(byte.MinValue, Scalar<byte>.MinValue.Value);
            Assert.Equal(byte.MaxValue, Scalar<byte>.MaxValue.Value);

            Assert.Equal((short)0, Scalar<short>.Zero.Value);
            Assert.Equal((short)1, Scalar<short>.One.Value);
            Assert.Equal((short)-1, Scalar<short>.NegativeOneOrZero.Value);
            Assert.Equal(short.MinValue, Scalar<short>.MinValue.Value);
            Assert.Equal(short.MaxValue, Scalar<short>.MaxValue.Value);

            Assert.Equal((ushort)0, Scalar<ushort>.Zero.Value);
            Assert.Equal((ushort)1, Scalar<ushort>.One.Value);
            Assert.Equal((ushort)0, Scalar<ushort>.NegativeOneOrZero.Value);
            Assert.Equal(ushort.MinValue, Scalar<ushort>.MinValue.Value);
            Assert.Equal(ushort.MaxValue, Scalar<ushort>.MaxValue.Value);

            Assert.Equal(0, Scalar<int>.Zero.Value);
            Assert.Equal(1, Scalar<int>.One.Value);
            Assert.Equal(-1, Scalar<int>.NegativeOneOrZero.Value);
            Assert.Equal(int.MinValue, Scalar<int>.MinValue.Value);
            Assert.Equal(int.MaxValue, Scalar<int>.MaxValue.Value);

            Assert.Equal(0u, Scalar<uint>.Zero.Value);
            Assert.Equal(1u, Scalar<uint>.One.Value);
            Assert.Equal(0u, Scalar<uint>.NegativeOneOrZero.Value);
            Assert.Equal(uint.MinValue, Scalar<uint>.MinValue.Value);
            Assert.Equal(uint.MaxValue, Scalar<uint>.MaxValue.Value);

            Assert.Equal(0L, Scalar<long>.Zero.Value);
            Assert.Equal(1L, Scalar<long>.One.Value);
            Assert.Equal(-1L, Scalar<long>.NegativeOneOrZero.Value);
            Assert.Equal(long.MinValue, Scalar<long>.MinValue.Value);
            Assert.Equal(long.MaxValue, Scalar<long>.MaxValue.Value);

            Assert.Equal(0uL, Scalar<ulong>.Zero.Value);
            Assert.Equal(1uL, Scalar<ulong>.One.Value);
            Assert.Equal(0uL, Scalar<ulong>.NegativeOneOrZero.Value);
            Assert.Equal(ulong.MinValue, Scalar<ulong>.MinValue.Value);
            Assert.Equal(ulong.MaxValue, Scalar<ulong>.MaxValue.Value);

            Assert.Equal(0f, Scalar<float>.Zero.Value);
            Assert.Equal(1f, Scalar<float>.One.Value);
            Assert.Equal(-1f, Scalar<float>.NegativeOneOrZero.Value);
            Assert.Equal(float.MinValue, Scalar<float>.MinValue.Value);
            Assert.Equal(float.MaxValue, Scalar<float>.MaxValue.Value);

            Assert.Equal(0d, Scalar<double>.Zero.Value);
            Assert.Equal(1d, Scalar<double>.One.Value);
            Assert.Equal(-1d, Scalar<double>.NegativeOneOrZero.Value);
            Assert.Equal(double.MinValue, Scalar<double>.MinValue.Value);
            Assert.Equal(double.MaxValue, Scalar<double>.MaxValue.Value);

            Assert.Equal(0m, Scalar<decimal>.Zero.Value);
            Assert.Equal(1m, Scalar<decimal>.One.Value);
            Assert.Equal(-1m, Scalar<decimal>.NegativeOneOrZero.Value);
            Assert.Equal(decimal.MinValue, Scalar<decimal>.MinValue.Value);
            Assert.Equal(decimal.MaxValue, Scalar<decimal>.MaxValue.Value);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.SByteData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ByteData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ShortData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UShortData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.IntData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UIntData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.LongData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ULongData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.FloatData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.DoubleData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void TestDefaultValue<T>(T _)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
            where T : struct
        {
            Scalar<T> scalar = default;

            Assert.Equal(default, scalar.Value);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void TestDefaultValueDecimal(decimal _)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            Scalar<decimal> scalar = default;

            Assert.Equal(default, scalar.Value);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.SByteData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ByteData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ShortData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UShortData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.IntData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.UIntData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.LongData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.ULongData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.FloatData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
        [MemberData(nameof(ScalarTestData.DoubleData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void TestDefaultInitialization<T>(T _)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
            where T : struct
        {
            Scalar<T> scalar = new Scalar<T>();

            Assert.Equal(default, scalar.Value);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 1 }, MemberType = typeof(ScalarTestData))]
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
        public void TestDefaultInitializationDecimal(decimal _)
#pragma warning restore xUnit1026 // Theory methods should use all of their parameters
        {
            Scalar<decimal> scalar = new Scalar<decimal>();

            Assert.Equal(default, scalar.Value);
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
        public void TestInitialization<T>(T t)
            where T : struct
        {
            Scalar<T> scalar = new Scalar<T>(t);

            Assert.Equal(t, scalar.Value);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void TestInitializationDecimal(decimal t)
        {
            Scalar<decimal> scalar = new Scalar<decimal>(t);

            Assert.Equal(t, scalar.Value);
        }

        [Fact]
        public void TestImplicitOperators()
        {
            Scalar<sbyte> sbyteV = (sbyte)2;
            Scalar<byte> byteV = (byte)2;
            Scalar<short> shortV = (short)2;
            Scalar<ushort> ushortV = (ushort)2;
            Scalar<int> intV = 2;
            Scalar<uint> uintV = 2u;
            Scalar<long> longV = 2L;
            Scalar<ulong> ulongV = 2uL;
            Scalar<float> floatV = 2f;
            Scalar<double> doubleV = 2.0;
            Scalar<decimal> decimalV = 2m;

            Assert.Equal((sbyte)2, (sbyte)sbyteV);
            Assert.Equal((byte)2, (byte)byteV);
            Assert.Equal((short)2, (short)shortV);
            Assert.Equal((ushort)2, (ushort)ushortV);
            Assert.Equal(2, (int)intV);
            Assert.Equal(2u, (uint)uintV);
            Assert.Equal(2L, (long)longV);
            Assert.Equal(2uL, (ulong)ulongV);
            Assert.Equal(2f, (float)floatV);
            Assert.Equal(2d, (double)doubleV);
            Assert.Equal(2m, (decimal)decimalV);
        }

        [Fact]
        public void TestAddition()
        {
            Scalar<sbyte> sbyteV1 = new Scalar<sbyte>(5), sbyteV2 = new Scalar<sbyte>(2);
            Scalar<byte> byteV1 = new Scalar<byte>(5), byteV2 = new Scalar<byte>(2);
            Scalar<short> shortV1 = new Scalar<short>(5), shortV2 = new Scalar<short>(2);
            Scalar<ushort> ushortV1 = new Scalar<ushort>(5), ushortV2 = new Scalar<ushort>(2);
            Scalar<int> intV1 = new Scalar<int>(5), intV2 = new Scalar<int>(2);
            Scalar<uint> uintV1 = new Scalar<uint>(5), uintV2 = new Scalar<uint>(2);
            Scalar<long> longV1 = new Scalar<long>(5), longV2 = new Scalar<long>(2);
            Scalar<ulong> ulongV1 = new Scalar<ulong>(5), ulongV2 = new Scalar<ulong>(2);
            Scalar<float> floatV1 = new Scalar<float>(5f), floatV2 = new Scalar<float>(2f);
            Scalar<double> doubleV1 = new Scalar<double>(5.0), doubleV2 = new Scalar<double>(2.0);
            Scalar<decimal> decimalV1 = new Scalar<decimal>(5m), decimalV2 = new Scalar<decimal>(2m);

            Assert.Equal(new Scalar<sbyte>(7), sbyteV1 + sbyteV2);
            Assert.Equal(new Scalar<byte>(7), byteV1 + byteV2);
            Assert.Equal(new Scalar<short>(7), shortV1 + shortV2);
            Assert.Equal(new Scalar<ushort>(7), ushortV1 + ushortV2);
            Assert.Equal(new Scalar<int>(7), intV1 + intV2);
            Assert.Equal(new Scalar<uint>(7u), uintV1 + uintV2);
            Assert.Equal(new Scalar<long>(7L), longV1 + longV2);
            Assert.Equal(new Scalar<ulong>(7uL), ulongV1 + ulongV2);
            Assert.Equal(new Scalar<float>(7f), floatV1 + floatV2);
            Assert.Equal(new Scalar<double>(7d), doubleV1 + doubleV2);
            Assert.Equal(new Scalar<decimal>(7m), decimalV1 + decimalV2);
        }

        [Fact]
        public void TestSubstraction()
        {
            Scalar<sbyte> sbyteV1 = new Scalar<sbyte>(5), sbyteV2 = new Scalar<sbyte>(2);
            Scalar<byte> byteV1 = new Scalar<byte>(5), byteV2 = new Scalar<byte>(2);
            Scalar<short> shortV1 = new Scalar<short>(5), shortV2 = new Scalar<short>(2);
            Scalar<ushort> ushortV1 = new Scalar<ushort>(5), ushortV2 = new Scalar<ushort>(2);
            Scalar<int> intV1 = new Scalar<int>(5), intV2 = new Scalar<int>(2);
            Scalar<uint> uintV1 = new Scalar<uint>(5), uintV2 = new Scalar<uint>(2);
            Scalar<long> longV1 = new Scalar<long>(5), longV2 = new Scalar<long>(2);
            Scalar<ulong> ulongV1 = new Scalar<ulong>(5), ulongV2 = new Scalar<ulong>(2);
            Scalar<float> floatV1 = new Scalar<float>(5f), floatV2 = new Scalar<float>(2f);
            Scalar<double> doubleV1 = new Scalar<double>(5.0), doubleV2 = new Scalar<double>(2.0);
            Scalar<decimal> decimalV1 = new Scalar<decimal>(5m), decimalV2 = new Scalar<decimal>(2m);

            Assert.Equal(new Scalar<sbyte>(3), sbyteV1 - sbyteV2);
            Assert.Equal(new Scalar<byte>(3), byteV1 - byteV2);
            Assert.Equal(new Scalar<short>(3), shortV1 - shortV2);
            Assert.Equal(new Scalar<ushort>(3), ushortV1 - ushortV2);
            Assert.Equal(new Scalar<int>(3), intV1 - intV2);
            Assert.Equal(new Scalar<uint>(3u), uintV1 - uintV2);
            Assert.Equal(new Scalar<long>(3L), longV1 - longV2);
            Assert.Equal(new Scalar<ulong>(3uL), ulongV1 - ulongV2);
            Assert.Equal(new Scalar<float>(3f), floatV1 - floatV2);
            Assert.Equal(new Scalar<double>(3d), doubleV1 - doubleV2);
            Assert.Equal(new Scalar<decimal>(3m), decimalV1 - decimalV2);
        }

        [Fact]
        public void TestSubstractionNegative()
        {
            Scalar<sbyte> sbyteV1 = new Scalar<sbyte>(5), sbyteV2 = new Scalar<sbyte>(2);
            Scalar<byte> byteV1 = new Scalar<byte>(5), byteV2 = new Scalar<byte>(2);
            Scalar<short> shortV1 = new Scalar<short>(5), shortV2 = new Scalar<short>(2);
            Scalar<ushort> ushortV1 = new Scalar<ushort>(5), ushortV2 = new Scalar<ushort>(2);
            Scalar<int> intV1 = new Scalar<int>(5), intV2 = new Scalar<int>(2);
            Scalar<uint> uintV1 = new Scalar<uint>(5), uintV2 = new Scalar<uint>(2);
            Scalar<long> longV1 = new Scalar<long>(5), longV2 = new Scalar<long>(2);
            Scalar<ulong> ulongV1 = new Scalar<ulong>(5), ulongV2 = new Scalar<ulong>(2);
            Scalar<float> floatV1 = new Scalar<float>(5f), floatV2 = new Scalar<float>(2f);
            Scalar<double> doubleV1 = new Scalar<double>(5.0), doubleV2 = new Scalar<double>(2.0);
            Scalar<decimal> decimalV1 = new Scalar<decimal>(5m), decimalV2 = new Scalar<decimal>(2m);

            Assert.Equal(new Scalar<sbyte>(-3), sbyteV2 - sbyteV1);
            Assert.Throws<OverflowException>(() => byteV2 - byteV1);
            Assert.Equal(new Scalar<short>(-3), shortV2 - shortV1);
            Assert.Throws<OverflowException>(() => ushortV2 - ushortV1);
            Assert.Equal(new Scalar<int>(-3), intV2 - intV1);
            Assert.Equal(new Scalar<uint>(uintV2.Value - uintV1.Value), uintV2 - uintV1);//this will overflow and wrap around without exception
            Assert.Equal(new Scalar<long>(-3L), longV2 - longV1);
            Assert.Equal(new Scalar<ulong>(ulongV2.Value - ulongV1.Value), ulongV2 - ulongV1);//this will overflow and wrap around without exception
            Assert.Equal(new Scalar<float>(-3f), floatV2 - floatV1);
            Assert.Equal(new Scalar<double>(-3d), doubleV2 - doubleV1);
            Assert.Equal(new Scalar<decimal>(-3m), decimalV2 - decimalV1);
        }

        [Fact]
        public void TestMultiplication()
        {
            Scalar<sbyte> sbyteV1 = new Scalar<sbyte>(5), sbyteV2 = new Scalar<sbyte>(2);
            Scalar<byte> byteV1 = new Scalar<byte>(5), byteV2 = new Scalar<byte>(2);
            Scalar<short> shortV1 = new Scalar<short>(5), shortV2 = new Scalar<short>(2);
            Scalar<ushort> ushortV1 = new Scalar<ushort>(5), ushortV2 = new Scalar<ushort>(2);
            Scalar<int> intV1 = new Scalar<int>(5), intV2 = new Scalar<int>(2);
            Scalar<uint> uintV1 = new Scalar<uint>(5), uintV2 = new Scalar<uint>(2);
            Scalar<long> longV1 = new Scalar<long>(5), longV2 = new Scalar<long>(2);
            Scalar<ulong> ulongV1 = new Scalar<ulong>(5), ulongV2 = new Scalar<ulong>(2);
            Scalar<float> floatV1 = new Scalar<float>(5f), floatV2 = new Scalar<float>(2f);
            Scalar<double> doubleV1 = new Scalar<double>(5.0), doubleV2 = new Scalar<double>(2.0);
            Scalar<decimal> decimalV1 = new Scalar<decimal>(5m), decimalV2 = new Scalar<decimal>(2m);

            Assert.Equal(new Scalar<sbyte>(10), sbyteV1 * sbyteV2);
            Assert.Equal(new Scalar<byte>(10), byteV1 * byteV2);
            Assert.Equal(new Scalar<short>(10), shortV1 * shortV2);
            Assert.Equal(new Scalar<ushort>(10), ushortV1 * ushortV2);
            Assert.Equal(new Scalar<int>(10), intV1 * intV2);
            Assert.Equal(new Scalar<uint>(10u), uintV1 * uintV2);
            Assert.Equal(new Scalar<long>(10L), longV1 * longV2);
            Assert.Equal(new Scalar<ulong>(10uL), ulongV1 * ulongV2);
            Assert.Equal(new Scalar<float>(10f), floatV1 * floatV2);
            Assert.Equal(new Scalar<double>(10d), doubleV1 * doubleV2);
            Assert.Equal(new Scalar<decimal>(10m), decimalV1 * decimalV2);
        }

        [Fact]
        public void TestDivision()
        {
            Scalar<sbyte> sbyteV1 = new Scalar<sbyte>(5), sbyteV2 = new Scalar<sbyte>(2);
            Scalar<byte> byteV1 = new Scalar<byte>(5), byteV2 = new Scalar<byte>(2);
            Scalar<short> shortV1 = new Scalar<short>(5), shortV2 = new Scalar<short>(2);
            Scalar<ushort> ushortV1 = new Scalar<ushort>(5), ushortV2 = new Scalar<ushort>(2);
            Scalar<int> intV1 = new Scalar<int>(5), intV2 = new Scalar<int>(2);
            Scalar<uint> uintV1 = new Scalar<uint>(5), uintV2 = new Scalar<uint>(2);
            Scalar<long> longV1 = new Scalar<long>(5), longV2 = new Scalar<long>(2);
            Scalar<ulong> ulongV1 = new Scalar<ulong>(5), ulongV2 = new Scalar<ulong>(2);
            Scalar<float> floatV1 = new Scalar<float>(5f), floatV2 = new Scalar<float>(2f);
            Scalar<double> doubleV1 = new Scalar<double>(5.0), doubleV2 = new Scalar<double>(2.0);
            Scalar<decimal> decimalV1 = new Scalar<decimal>(5m), decimalV2 = new Scalar<decimal>(2m);

            Assert.Equal(new Scalar<sbyte>(2), sbyteV1 / sbyteV2);
            Assert.Equal(new Scalar<byte>(2), byteV1 / byteV2);
            Assert.Equal(new Scalar<short>(2), shortV1 / shortV2);
            Assert.Equal(new Scalar<ushort>(2), ushortV1 / ushortV2);
            Assert.Equal(new Scalar<int>(2), intV1 / intV2);
            Assert.Equal(new Scalar<uint>(2u), uintV1 / uintV2);
            Assert.Equal(new Scalar<long>(2L), longV1 / longV2);
            Assert.Equal(new Scalar<ulong>(2uL), ulongV1 / ulongV2);
            Assert.Equal(new Scalar<float>(2.5f), floatV1 / floatV2);
            Assert.Equal(new Scalar<double>(2.5d), doubleV1 / doubleV2);
            Assert.Equal(new Scalar<decimal>(2.5m), decimalV1 / decimalV2);
        }

        [Fact]
        public void TestModulo()
        {
            Scalar<sbyte> sbyteV1 = new Scalar<sbyte>(5), sbyteV2 = new Scalar<sbyte>(2);
            Scalar<byte> byteV1 = new Scalar<byte>(5), byteV2 = new Scalar<byte>(2);
            Scalar<short> shortV1 = new Scalar<short>(5), shortV2 = new Scalar<short>(2);
            Scalar<ushort> ushortV1 = new Scalar<ushort>(5), ushortV2 = new Scalar<ushort>(2);
            Scalar<int> intV1 = new Scalar<int>(5), intV2 = new Scalar<int>(2);
            Scalar<uint> uintV1 = new Scalar<uint>(5), uintV2 = new Scalar<uint>(2);
            Scalar<long> longV1 = new Scalar<long>(5), longV2 = new Scalar<long>(2);
            Scalar<ulong> ulongV1 = new Scalar<ulong>(5), ulongV2 = new Scalar<ulong>(2);
            Scalar<float> floatV1 = new Scalar<float>(5f), floatV2 = new Scalar<float>(2f);
            Scalar<double> doubleV1 = new Scalar<double>(5.0), doubleV2 = new Scalar<double>(2.0);
            Scalar<decimal> decimalV1 = new Scalar<decimal>(5m), decimalV2 = new Scalar<decimal>(2m);

            Assert.Equal(new Scalar<sbyte>(1), sbyteV1 % sbyteV2);
            Assert.Equal(new Scalar<byte>(1), byteV1 % byteV2);
            Assert.Equal(new Scalar<short>(1), shortV1 % shortV2);
            Assert.Equal(new Scalar<ushort>(1), ushortV1 % ushortV2);
            Assert.Equal(new Scalar<int>(1), intV1 % intV2);
            Assert.Equal(new Scalar<uint>(1u), uintV1 % uintV2);
            Assert.Equal(new Scalar<long>(1L), longV1 % longV2);
            Assert.Equal(new Scalar<ulong>(1uL), ulongV1 % ulongV2);
            Assert.Equal(new Scalar<float>(1.0f), floatV1 % floatV2);
            Assert.Equal(new Scalar<double>(1.0d), doubleV1 % doubleV2);
            Assert.Equal(new Scalar<decimal>(1.0m), decimalV1 % decimalV2);
        }

        [Fact]
        public void TestNegation()
        {
            Scalar<sbyte> sbyteV = new Scalar<sbyte>(5);
            Scalar<byte> byteV = new Scalar<byte>(5);
            Scalar<short> shortV = new Scalar<short>(5);
            Scalar<ushort> ushortV = new Scalar<ushort>(5);
            Scalar<int> intV = new Scalar<int>(5);
            Scalar<uint> uintV = new Scalar<uint>(5);
            Scalar<long> longV = new Scalar<long>(5);
            Scalar<ulong> ulongV = new Scalar<ulong>(5);
            Scalar<float> floatV = new Scalar<float>(5f);
            Scalar<double> doubleV = new Scalar<double>(5.0);
            Scalar<decimal> decimalV = new Scalar<decimal>(5m);

            Assert.Equal(new Scalar<sbyte>(-5), -sbyteV);
            Assert.Throws<Exception>(() => -byteV);
            Assert.Equal(new Scalar<short>(-5), -shortV);
            Assert.Throws<Exception>(() => -ushortV);
            Assert.Equal(new Scalar<int>(-5), -intV);
            Assert.Throws<Exception>(() => -uintV);
            Assert.Equal(new Scalar<long>(-5L), -longV);
            Assert.Throws<Exception>(() => -ulongV);
            Assert.Equal(new Scalar<float>(-5f), -floatV);
            Assert.Equal(new Scalar<double>(-5d), -doubleV);
            Assert.Equal(new Scalar<decimal>(-5m), -decimalV);
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
        public void TestEquality<T>(T t)
            where T : struct
        {
            Scalar<T> scalar = new Scalar<T>(t);

#pragma warning disable CS1718 // Comparison made to same variable // which is the point of the test
            Assert.True(scalar == scalar);
#pragma warning restore CS1718 // Comparison made to same variable
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void TestEqualityDecimal(decimal t)
        {
            Scalar<decimal> scalar = new Scalar<decimal>(t);

#pragma warning disable CS1718 // Comparison made to same variable // which is the point of the test
            Assert.True(scalar == scalar);
#pragma warning restore CS1718 // Comparison made to same variable
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
        public void TestGreaterThan<T>(T t)
            where T : struct
        {
            Scalar<T> scalar = new Scalar<T>(t);

            Assert.True(scalar + Scalar<T>.One > scalar);
            Assert.False(scalar > scalar + Scalar<T>.One);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void TestGreaterThanDecimal(decimal t)
        {
            Scalar<decimal> scalar = new Scalar<decimal>(t);

            Assert.True(scalar + Scalar<decimal>.One > scalar);
            Assert.False(scalar > scalar + Scalar<decimal>.One);
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
        public void TestLessThan<T>(T t)
            where T : struct
        {
            Scalar<T> scalar = new Scalar<T>(t);

            Assert.True(scalar < scalar + Scalar<T>.One);
            Assert.False(scalar + Scalar<T>.One < scalar);
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void TestLessThanDecimal(decimal t)
        {
            Scalar<decimal> scalar = new Scalar<decimal>(t);

            Assert.True(scalar < scalar + Scalar<decimal>.One);
            Assert.False(scalar + Scalar<decimal>.One < scalar);
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
        public void TestToString<T>(T t)
            where T : struct
        {
            Scalar<T> scalar = new Scalar<T>(t);

            Assert.Equal(t.ToString(), scalar.ToString());
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void TestToStringDecimal(decimal t)
        {
            Scalar<decimal> scalar = new Scalar<decimal>(t);

            Assert.Equal(t.ToString(), scalar.ToString());
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
        public void TestEquals<T>(T t)
            where T : struct
        {
            Scalar<T> scalar = new Scalar<T>(t);

            Assert.True(scalar.Equals(scalar));
            Assert.True(scalar.Equals(t));
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void TestEqualsDecimal(decimal t)
        {
            Scalar<decimal> scalar = new Scalar<decimal>(t);

            Assert.True(scalar.Equals(scalar));
            Assert.True(scalar.Equals(t));
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
        public void TestGetHashCode<T>(T t)
            where T : struct
        {
            Scalar<T> scalar = new Scalar<T>(t);

            Assert.Equal(t.GetHashCode(), scalar.GetHashCode());
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void TestGetHashCodeDecimal(decimal t)
        {
            Scalar<decimal> scalar = new Scalar<decimal>(t);

            Assert.Equal(t.GetHashCode(), scalar.GetHashCode());
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
        public void TestClone<T>(T t)
            where T : struct
        {
            Scalar<T> scalar = new Scalar<T>(t);

            Assert.Equal(scalar, scalar.Clone());
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void TestCloneDecimal(decimal t)
        {
            Scalar<decimal> scalar = new Scalar<decimal>(t);

            Assert.Equal(scalar, scalar.Clone());
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
        public void TestIEnumerable<T>(T t)
            where T : struct
        {
            Scalar<T> scalar = new Scalar<T>(t);
            IEnumerator<T> enumerator = scalar.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(t, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Theory]
        [MemberData(nameof(ScalarTestData.DecimalData), new object[] { 1, 6 }, MemberType = typeof(ScalarTestData))]
        public void TestIEnumerableDecimal(decimal t)
        {
            Scalar<decimal> scalar = new Scalar<decimal>(t);
            IEnumerator<decimal> enumerator = scalar.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(t, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }
    }
}