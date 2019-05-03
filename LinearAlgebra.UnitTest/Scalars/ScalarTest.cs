using LinearAlgebra.Scalars;
using System;
using Xunit;

namespace LinearAlgebra.UnitTest.Scalars
{
    public class ScalarTest
    {
        [Fact]
        public void TestStaticConstants()
        {
            Assert.Equal((sbyte)0, Scalar<sbyte>.Zero.Value);
            Assert.Equal((sbyte)1, Scalar<sbyte>.One.Value);
            Assert.Equal((byte)0, Scalar<byte>.Zero.Value);
            Assert.Equal((byte)1, Scalar<byte>.One.Value);
            Assert.Equal((short)0, Scalar<short>.Zero.Value);
            Assert.Equal((short)1, Scalar<short>.One.Value);
            Assert.Equal((ushort)0, Scalar<ushort>.Zero.Value);
            Assert.Equal((ushort)1, Scalar<ushort>.One.Value);
            Assert.Equal(0, Scalar<int>.Zero.Value);
            Assert.Equal(1, Scalar<int>.One.Value);
            Assert.Equal(0u, Scalar<uint>.Zero.Value);
            Assert.Equal(1u, Scalar<uint>.One.Value);
            Assert.Equal(0L, Scalar<long>.Zero.Value);
            Assert.Equal(1L, Scalar<long>.One.Value);
            Assert.Equal(0uL, Scalar<ulong>.Zero.Value);
            Assert.Equal(1uL, Scalar<ulong>.One.Value);
            Assert.Equal(0f, Scalar<float>.Zero.Value);
            Assert.Equal(1f, Scalar<float>.One.Value);
            Assert.Equal(0d, Scalar<double>.Zero.Value);
            Assert.Equal(1d, Scalar<double>.One.Value);
            Assert.Equal(0m, Scalar<decimal>.Zero.Value);
            Assert.Equal(1m, Scalar<decimal>.One.Value);
        }

        [Fact]
        public void TestInitialization()
        {
            Scalar<sbyte> sbyteV = new Scalar<sbyte>(2);
            Scalar<byte> byteV = new Scalar<byte>(2);
            Scalar<short> shortV = new Scalar<short>(2);
            Scalar<ushort> ushortV = new Scalar<ushort>(2);
            Scalar<int> intV = new Scalar<int>(2);
            Scalar<uint> uintV = new Scalar<uint>(2);
            Scalar<long> longV = new Scalar<long>(2);
            Scalar<ulong> ulongV = new Scalar<ulong>(2);
            Scalar<float> floatV = new Scalar<float>(2f);
            Scalar<double> doubleV = new Scalar<double>(2.0);
            Scalar<decimal> decimalV = new Scalar<decimal>(2m);

            Assert.Equal((sbyte)2, sbyteV.Value);
            Assert.Equal((byte)2, byteV.Value);
            Assert.Equal((short)2, shortV.Value);
            Assert.Equal((ushort)2, ushortV.Value);
            Assert.Equal(2, intV.Value);
            Assert.Equal(2u, uintV.Value);
            Assert.Equal(2L, longV.Value);
            Assert.Equal(2uL, ulongV.Value);
            Assert.Equal(2f, floatV.Value);
            Assert.Equal(2d, doubleV.Value);
            Assert.Equal(2m, decimalV.Value);
        }

        [Fact]
        public void TestImplicitOperators()
        {
            Scalar<sbyte> sbyteV = 2;
            Scalar<byte> byteV = 2;
            Scalar<short> shortV = 2;
            Scalar<ushort> ushortV = 2;
            Scalar<int> intV = 2;
            Scalar<uint> uintV = 2;
            Scalar<long> longV = 2;
            Scalar<ulong> ulongV = 2;
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

        [Fact]
        public void TestEquality()
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

#pragma warning disable CS1718 // Comparison made to same variable // which is the point of the test
            Assert.True(sbyteV == sbyteV);
            Assert.True(byteV == byteV);
            Assert.True(shortV == shortV);
            Assert.True(ushortV == ushortV);
            Assert.True(intV == intV);
            Assert.True(uintV == uintV);
            Assert.True(longV == longV);
            Assert.True(ulongV == ulongV);
            Assert.True(floatV == floatV);
            Assert.True(doubleV == doubleV);
            Assert.True(decimalV == decimalV);
#pragma warning restore CS1718 // Comparison made to same variable
        }

        [Fact]
        public void TestGreaterThan()
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

            Assert.True(sbyteV + Scalar<sbyte>.One > sbyteV);
            Assert.True(byteV + Scalar<byte>.One > byteV);
            Assert.True(shortV + Scalar<short>.One > shortV);
            Assert.True(ushortV + Scalar<ushort>.One > ushortV);
            Assert.True(intV + Scalar<int>.One > intV);
            Assert.True(uintV + Scalar<uint>.One > uintV);
            Assert.True(longV + Scalar<long>.One > longV);
            Assert.True(ulongV + Scalar<ulong>.One > ulongV);
            Assert.True(floatV + Scalar<float>.One > floatV);
            Assert.True(doubleV + Scalar<double>.One > doubleV);
            Assert.True(decimalV + Scalar<decimal>.One > decimalV);

            Assert.False(sbyteV > sbyteV + Scalar<sbyte>.One);
            Assert.False(byteV > byteV + Scalar<byte>.One);
            Assert.False(shortV > shortV + Scalar<short>.One);
            Assert.False(ushortV > ushortV + Scalar<ushort>.One);
            Assert.False(intV > intV + Scalar<int>.One);
            Assert.False(uintV > uintV + Scalar<uint>.One);
            Assert.False(longV > longV + Scalar<long>.One);
            Assert.False(ulongV > ulongV + Scalar<ulong>.One);
            Assert.False(floatV > floatV + Scalar<float>.One);
            Assert.False(doubleV > doubleV + Scalar<double>.One);
            Assert.False(decimalV > decimalV + Scalar<decimal>.One);
        }

        [Fact]
        public void TestLessThan()
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

            Assert.True(sbyteV < sbyteV + Scalar<sbyte>.One);
            Assert.True(byteV < byteV + Scalar<byte>.One);
            Assert.True(shortV < shortV + Scalar<short>.One);
            Assert.True(ushortV < ushortV + Scalar<ushort>.One);
            Assert.True(intV < intV + Scalar<int>.One);
            Assert.True(uintV < uintV + Scalar<uint>.One);
            Assert.True(longV < longV + Scalar<long>.One);
            Assert.True(ulongV < ulongV + Scalar<ulong>.One);
            Assert.True(floatV < floatV + Scalar<float>.One);
            Assert.True(doubleV < doubleV + Scalar<double>.One);
            Assert.True(decimalV < decimalV + Scalar<decimal>.One);

            Assert.False(sbyteV + Scalar<sbyte>.One < sbyteV);
            Assert.False(byteV + Scalar<byte>.One < byteV);
            Assert.False(shortV + Scalar<short>.One < shortV);
            Assert.False(ushortV + Scalar<ushort>.One < ushortV);
            Assert.False(intV + Scalar<int>.One < intV);
            Assert.False(uintV + Scalar<uint>.One < uintV);
            Assert.False(longV + Scalar<long>.One < longV);
            Assert.False(ulongV + Scalar<ulong>.One < ulongV);
            Assert.False(floatV + Scalar<float>.One < floatV);
            Assert.False(doubleV + Scalar<double>.One < doubleV);
            Assert.False(decimalV + Scalar<decimal>.One < decimalV);
        }
    }
}