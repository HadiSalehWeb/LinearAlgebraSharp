using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinearAlgebra.Scalars;
using System;

namespace LinearAlgebra.UnitTest.Scalars
{
    [TestClass]
    public class ScalarTest
    {
        [TestMethod]
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
        public void TestImplicitInitialization()
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
    }
}