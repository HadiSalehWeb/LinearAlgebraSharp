using LinearAlgebra.Scalars;
using System;

namespace LinearAlgebra.Vectors
{
    public static class IVectorExtensions
    {
        public static Scalar<T> AngleTo<T, TVec>(this TVec v1, TVec v2)
            where T : struct, IComparable
            where TVec : IVector<T, TVec>
        {
            return Math.Acos(v1.Dot(v2) / (v1.Magnitude * v2.Magnitude));
        }

        public static TVec ProjectionOnto<T, TVec>(this TVec v1, TVec v2)
            where T : struct, IComparable
            where TVec : IVector<T, TVec>
        {
            return v2.Multiply(v1.Dot(v2) / v2.Dot(v2));
        }

        public static Scalar<T> SquareDistanceTo<T, TVec>(this TVec v1, TVec v2)
            where T : struct, IComparable
            where TVec : IVector<T, TVec>
        {
            return v1.Substract(v2).SqrMagnitude;
        }

        public static Scalar<T> DistanceTo<T, TVec>(this TVec v1, TVec v2)
            where T : struct, IComparable
            where TVec : IVector<T, TVec>
        {
            return v1.Substract(v2).Magnitude;
        }

        public static TVec Lerp<T, TVec>(this TVec v1, TVec v2, Scalar<T> t)
            where T : struct, IComparable
            where TVec : IVector<T, TVec>
        {
            return v1.Add(v2.Substract(v1).Multiply(t));
        }
    }
}
