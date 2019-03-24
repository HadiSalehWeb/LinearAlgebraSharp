using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra.Scalars;
using System;

namespace LinearAlgebra.UnitTest.Scalars
{
    [TestClass]
    public class ScalarTest
    {
        [TestMethod]
        public void TestStaticConstants()
        {
            Assert.AreEqual(false, Scalar<bool>.Zero.Value);
            Assert.AreEqual(true, Scalar<bool>.One.Value);
            Assert.AreEqual((sbyte)0, Scalar<sbyte>.Zero.Value);
            Assert.AreEqual((sbyte)1, Scalar<sbyte>.One.Value);
            Assert.AreEqual((byte)0, Scalar<byte>.Zero.Value);
            Assert.AreEqual((byte)1, Scalar<byte>.One.Value);
            Assert.AreEqual((short)0, Scalar<short>.Zero.Value);
            Assert.AreEqual((short)1, Scalar<short>.One.Value);
            Assert.AreEqual((ushort)0, Scalar<ushort>.Zero.Value);
            Assert.AreEqual((ushort)1, Scalar<ushort>.One.Value);
            Assert.AreEqual(0, Scalar<int>.Zero.Value);
            Assert.AreEqual(1, Scalar<int>.One.Value);
            Assert.AreEqual(0u, Scalar<uint>.Zero.Value);
            Assert.AreEqual(1u, Scalar<uint>.One.Value);
            Assert.AreEqual(0L, Scalar<long>.Zero.Value);
            Assert.AreEqual(1L, Scalar<long>.One.Value);
            Assert.AreEqual(0uL, Scalar<ulong>.Zero.Value);
            Assert.AreEqual(1uL, Scalar<ulong>.One.Value);
            Assert.AreEqual(0f, Scalar<float>.Zero.Value);
            Assert.AreEqual(1f, Scalar<float>.One.Value);
            Assert.AreEqual(0d, Scalar<double>.Zero.Value);
            Assert.AreEqual(1d, Scalar<double>.One.Value);
            Assert.AreEqual(0m, Scalar<decimal>.Zero.Value);
            Assert.AreEqual(1m, Scalar<decimal>.One.Value);
        }

        [TestMethod]
        public void TestInitialization()
        {
            Scalar<bool> boolV = new Scalar<bool>(true);
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

            Assert.AreEqual(true, boolV.Value);
            Assert.AreEqual((sbyte)2, sbyteV.Value);
            Assert.AreEqual((byte)2, byteV.Value);
            Assert.AreEqual((short)2, shortV.Value);
            Assert.AreEqual((ushort)2, ushortV.Value);
            Assert.AreEqual(2, intV.Value);
            Assert.AreEqual(2u, uintV.Value);
            Assert.AreEqual(2L, longV.Value);
            Assert.AreEqual(2uL, ulongV.Value);
            Assert.AreEqual(2f, floatV.Value);
            Assert.AreEqual(2d, doubleV.Value);
            Assert.AreEqual(2m, decimalV.Value);
        }

        [TestMethod]
        public void TestImplicitOperators()
        {
            Scalar<bool> boolV = true;
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

            Assert.AreEqual(true, (bool)boolV);
            Assert.AreEqual((sbyte)2, (sbyte)sbyteV);
            Assert.AreEqual((byte)2, (byte)byteV);
            Assert.AreEqual((short)2, (short)shortV);
            Assert.AreEqual((ushort)2, (ushort)ushortV);
            Assert.AreEqual(2, (int)intV);
            Assert.AreEqual(2u, (uint)uintV);
            Assert.AreEqual(2L, (long)longV);
            Assert.AreEqual(2uL, (ulong)ulongV);
            Assert.AreEqual(2f, (float)floatV);
            Assert.AreEqual(2d, (double)doubleV);
            Assert.AreEqual(2m, (decimal)decimalV);
        }

        [TestMethod]
        public void TestAddition()
        {
            Scalar<bool> boolV1 = new Scalar<bool>(true), boolV2 = new Scalar<bool>(false);
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

            Assert.AreEqual(new Scalar<bool>(true), boolV1 + boolV2);
            Assert.AreEqual(new Scalar<sbyte>(7), sbyteV1 + sbyteV2);
            Assert.AreEqual(new Scalar<byte>(7), byteV1 + byteV2);
            Assert.AreEqual(new Scalar<short>(7), shortV1 + shortV2);
            Assert.AreEqual(new Scalar<ushort>(7), ushortV1 + ushortV2);
            Assert.AreEqual(new Scalar<int>(7), intV1 + intV2);
            Assert.AreEqual(new Scalar<uint>(7u), uintV1 + uintV2);
            Assert.AreEqual(new Scalar<long>(7L), longV1 + longV2);
            Assert.AreEqual(new Scalar<ulong>(7uL), ulongV1 + ulongV2);
            Assert.AreEqual(new Scalar<float>(7f), floatV1 + floatV2);
            Assert.AreEqual(new Scalar<double>(7d), doubleV1 + doubleV2);
            Assert.AreEqual(new Scalar<decimal>(7m), decimalV1 + decimalV2);
        }

        [TestMethod]
        public void TestSubstraction()
        {
            Scalar<bool> boolV1 = new Scalar<bool>(true), boolV2 = new Scalar<bool>(false);
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

            Assert.ThrowsException<Exception>(() => boolV1 - boolV2);
            Assert.AreEqual(new Scalar<sbyte>(3), sbyteV1 - sbyteV2);
            Assert.AreEqual(new Scalar<byte>(3), byteV1 - byteV2);
            Assert.AreEqual(new Scalar<short>(3), shortV1 - shortV2);
            Assert.AreEqual(new Scalar<ushort>(3), ushortV1 - ushortV2);
            Assert.AreEqual(new Scalar<int>(3), intV1 - intV2);
            Assert.AreEqual(new Scalar<uint>(3u), uintV1 - uintV2);
            Assert.AreEqual(new Scalar<long>(3L), longV1 - longV2);
            Assert.AreEqual(new Scalar<ulong>(3uL), ulongV1 - ulongV2);
            Assert.AreEqual(new Scalar<float>(3f), floatV1 - floatV2);
            Assert.AreEqual(new Scalar<double>(3d), doubleV1 - doubleV2);
            Assert.AreEqual(new Scalar<decimal>(3m), decimalV1 - decimalV2);
        }

        [TestMethod]
        public void TestSubstractionNegative()
        {
            Scalar<bool> boolV1 = new Scalar<bool>(true), boolV2 = new Scalar<bool>(false);
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

            Assert.ThrowsException<Exception>(() => boolV1 - boolV2);
            Assert.AreEqual(new Scalar<sbyte>(-3), sbyteV2 - sbyteV1);
            Assert.ThrowsException<OverflowException>(() => byteV2 - byteV1);
            Assert.AreEqual(new Scalar<short>(-3), shortV2 - shortV1);
            Assert.ThrowsException<OverflowException>(() => ushortV2 - ushortV1);
            Assert.AreEqual(new Scalar<int>(-3), intV2 - intV1);
            Assert.AreEqual(new Scalar<uint>(uintV2.Value - uintV1.Value), uintV2 - uintV1);//this will overflow and wrap around without exception
            Assert.AreEqual(new Scalar<long>(-3L), longV2 - longV1);
            Assert.AreEqual(new Scalar<ulong>(ulongV2.Value - ulongV1.Value), ulongV2 - ulongV1);//this will overflow and wrap around without exception
            Assert.AreEqual(new Scalar<float>(-3f), floatV2 - floatV1);
            Assert.AreEqual(new Scalar<double>(-3d), doubleV2 - doubleV1);
            Assert.AreEqual(new Scalar<decimal>(-3m), decimalV2 - decimalV1);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            Scalar<bool> boolV1 = new Scalar<bool>(true), boolV2 = new Scalar<bool>(false);
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

            Assert.AreEqual(new Scalar<bool>(false), boolV1 * boolV2);
            Assert.AreEqual(new Scalar<sbyte>(10), sbyteV1 * sbyteV2);
            Assert.AreEqual(new Scalar<byte>(10), byteV1 * byteV2);
            Assert.AreEqual(new Scalar<short>(10), shortV1 * shortV2);
            Assert.AreEqual(new Scalar<ushort>(10), ushortV1 * ushortV2);
            Assert.AreEqual(new Scalar<int>(10), intV1 * intV2);
            Assert.AreEqual(new Scalar<uint>(10u), uintV1 * uintV2);
            Assert.AreEqual(new Scalar<long>(10L), longV1 * longV2);
            Assert.AreEqual(new Scalar<ulong>(10uL), ulongV1 * ulongV2);
            Assert.AreEqual(new Scalar<float>(10f), floatV1 * floatV2);
            Assert.AreEqual(new Scalar<double>(10d), doubleV1 * doubleV2);
            Assert.AreEqual(new Scalar<decimal>(10m), decimalV1 * decimalV2);
        }

        [TestMethod]
        public void TestDivision()
        {
            Scalar<bool> boolV1 = new Scalar<bool>(true), boolV2 = new Scalar<bool>(false);
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

            Assert.ThrowsException<Exception>(() => boolV1 / boolV2);
            Assert.AreEqual(new Scalar<sbyte>(2), sbyteV1 / sbyteV2);
            Assert.AreEqual(new Scalar<byte>(2), byteV1 / byteV2);
            Assert.AreEqual(new Scalar<short>(2), shortV1 / shortV2);
            Assert.AreEqual(new Scalar<ushort>(2), ushortV1 / ushortV2);
            Assert.AreEqual(new Scalar<int>(2), intV1 / intV2);
            Assert.AreEqual(new Scalar<uint>(2u), uintV1 / uintV2);
            Assert.AreEqual(new Scalar<long>(2L), longV1 / longV2);
            Assert.AreEqual(new Scalar<ulong>(2uL), ulongV1 / ulongV2);
            Assert.AreEqual(new Scalar<float>(2.5f), floatV1 / floatV2);
            Assert.AreEqual(new Scalar<double>(2.5d), doubleV1 / doubleV2);
            Assert.AreEqual(new Scalar<decimal>(2.5m), decimalV1 / decimalV2);
        }

        [TestMethod]
        public void TestNegation()
        {
            Scalar<bool> boolV = new Scalar<bool>(true);
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

            Assert.ThrowsException<Exception>(() => -boolV);
            Assert.AreEqual(new Scalar<sbyte>(-5), -sbyteV);
            Assert.ThrowsException<Exception>(() => -byteV);
            Assert.AreEqual(new Scalar<short>(-5), -shortV);
            Assert.ThrowsException<Exception>(() => -ushortV);
            Assert.AreEqual(new Scalar<int>(-5), -intV);
            Assert.ThrowsException<Exception>(() => -uintV);
            Assert.AreEqual(new Scalar<long>(-5L), -longV);
            Assert.ThrowsException<Exception>(() => -ulongV);
            Assert.AreEqual(new Scalar<float>(-5f), -floatV);
            Assert.AreEqual(new Scalar<double>(-5d), -doubleV);
            Assert.AreEqual(new Scalar<decimal>(-5m), -decimalV);
        }

        [TestMethod]
        public void TestBitwiseComplements()
        {
            Scalar<bool> boolV = new Scalar<bool>(true);
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
            
            Assert.AreEqual(new Scalar<bool>(false), ~boolV);
            Assert.AreEqual(new Scalar<sbyte>(~5), ~sbyteV);
            Assert.ThrowsException<OverflowException>(() => ~byteV);
            Assert.AreEqual(new Scalar<short>(~5), ~shortV);
            Assert.ThrowsException<OverflowException>(() => ~ushortV);
            Assert.AreEqual(new Scalar<int>(~5), ~intV);
            Assert.AreEqual(new Scalar<uint>(~5u), ~uintV);
            Assert.AreEqual(new Scalar<long>(~5L), ~longV);
            Assert.AreEqual(new Scalar<ulong>(~5uL), ~ulongV);
            Assert.ThrowsException<Exception>(() => ~floatV);
            Assert.ThrowsException<Exception>(() => ~doubleV);
            Assert.ThrowsException<Exception>(() => ~decimalV);
        }
    }
}