using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearAlgebra.UnitTest.Scalars
{
    public class ScalarTestData
    {
        //private static readonly Dictionary<Type, Func<int, int, IEnumerable<object[]>>> TypeToFunc = new Dictionary<Type, Func<int, int, IEnumerable<object[]>>>
        //{
        //    { typeof(bool), BoolData },
        //    { typeof(sbyte), SByteData },
        //    { typeof(byte), ByteData },
        //    { typeof(short), ShortData },
        //    { typeof(ushort), UShortData },
        //    { typeof(int), IntData },
        //    { typeof(uint), UIntData },
        //    { typeof(long), LongData },
        //    { typeof(ulong), ULongData },
        //    { typeof(float), FloatData },
        //    { typeof(double), DoubleData },
        //    { typeof(decimal), DecimalData }
        //};

        public static IEnumerable<object[]> BoolData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { true, true, true },
                new object[] { false, true, true },
                new object[] { true, false, true },
                new object[] { false, false, true },
                new object[] { true, true, false },
                new object[] { false, true, false },
                new object[] { true, false, false },
                new object[] { false, false, false }
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> SByteData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { (sbyte)0  , (sbyte)1  , (sbyte)2   },
                new object[] { (sbyte)1  , (sbyte)2  , (sbyte)10  },
                new object[] { (sbyte)2  , (sbyte)10 , (sbyte)-1  },
                new object[] { (sbyte)10 , (sbyte)-1 , (sbyte)-11 },
                new object[] { (sbyte)-1 , (sbyte)-11, (sbyte)0   },
                new object[] { (sbyte)-11, (sbyte)0  , (sbyte)1   },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> ByteData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { (byte)0, (byte)1, (byte)2 },
                new object[] { (byte)1, (byte)2, (byte)3 },
                new object[] { (byte)2, (byte)3, (byte)4 },
                new object[] { (byte)3, (byte)4, (byte)5 },
                new object[] { (byte)4, (byte)5, (byte)0 },
                new object[] { (byte)5, (byte)0, (byte)1 },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> ShortData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { (short)0  , (short)1  , (short)2   },
                new object[] { (short)1  , (short)2  , (short)10  },
                new object[] { (short)2  , (short)10 , (short)-1  },
                new object[] { (short)10 , (short)-1 , (short)-20 },
                new object[] { (short)-1 , (short)-20, (short)0   },
                new object[] { (short)-20, (short)0  , (short)1   },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> UShortData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { (ushort)0  , (ushort)1  , (ushort)2   },
                new object[] { (ushort)1  , (ushort)2  , (ushort)10  },
                new object[] { (ushort)2  , (ushort)10 , (ushort)30  },
                new object[] { (ushort)10 , (ushort)30 , (ushort)100 },
                new object[] { (ushort)30 , (ushort)100, (ushort)0   },
                new object[] { (ushort)100, (ushort)0  , (ushort)1   },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> IntData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { 0  , 1  , 2   },
                new object[] { 1  , 2  , 10  },
                new object[] { 2  , 10 , -1  },
                new object[] { 10 , -1 , -20 },
                new object[] { -1 , -20, 0   },
                new object[] { -20, 0  , 1   },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> UIntData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { 0u     , 1u     , 2u      },
                new object[] { 1u     , 2u     , 10u     },
                new object[] { 2u     , 10u    , 300u    },
                new object[] { 10u    , 300u   , 100000u },
                new object[] { 300u   , 100000u, 0u      },
                new object[] { 100000u, 0u     , 1u      },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> LongData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { 0L  , 1L  , 2L   },
                new object[] { 1L  , 2L  , 10L  },
                new object[] { 2L  , 10L , -1L  },
                new object[] { 10L , -1L , -20L },
                new object[] { -1L , -20L, 0L   },
                new object[] { -20L, 0L  , 1L   },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> ULongData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { 0uL          , 1uL          , 2uL           },
                new object[] { 1uL          , 2uL          , 10uL          },
                new object[] { 2uL          , 10uL         , 300uL         },
                new object[] { 10uL         , 300uL        , 10000000000uL },
                new object[] { 300uL        , 10000000000uL, 0uL           },
                new object[] { 10000000000uL, 0uL          , 1uL           },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> FloatData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { 0f        , 1f      , 2f       },
                new object[] { 1f        , 2f      , 0.5f     },
                new object[] { 2f        , 0.5f    , 12.0358f },
                new object[] { 0.5f      , 12.0358f, 10000f   },
                new object[] { 12.0358f  , 10000f  , 0f       },
                new object[] { 10000f    , 0f      , 1f       },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> DoubleData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { 0d        , 1d      , 2d       },
                new object[] { 1d        , 2d      , 0.5d     },
                new object[] { 2d        , 0.5d    , 12.0358d },
                new object[] { 0.5d      , 12.0358d, 10000d   },
                new object[] { 12.0358d  , 10000d  , 0d       },
                new object[] { 10000d    , 0d      , 1d       },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }

        public static IEnumerable<object[]> DecimalData(int itemCount, int testCount)
        {
            return new List<object[]>
            {
                new object[] { 0m       , 1m     , 2m      },
                new object[] { 1m       , 2m     , 0.5m    },
                new object[] { 2m       , 0.5m   , 12.035m },
                new object[] { 0.5m     , 12.035m, 10000m  },
                new object[] { 12.035m  , 10000m , 0m      },
                new object[] { 10000m   , 0m     , 1m      },
            }.Select(x => x.Take(itemCount).ToArray()).Take(testCount);
        }
    }
}
