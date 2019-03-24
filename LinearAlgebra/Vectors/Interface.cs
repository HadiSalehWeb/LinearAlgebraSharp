using LinearAlgebra.Scalars;
using System;

namespace LinearAlgebra.Vectors
{
    public interface IVectorBase<T>
        where T : struct, IComparable
    {
        Scalar<int> Dimension { get; }
        Scalar<T>[] Data { get; }
    }

    public interface IVector<T, TThis> : IVectorBase<T>
        where T : struct, IComparable
        where TThis : IVector<T, TThis>
    {
        Scalar<T> SqrMagnitude { get; }
        Scalar<T> Magnitude { get; }
        TThis Normalized { get; }
        Scalar<T> Dot(TThis vec);
        Scalar<T> AngleTo(TThis vec);
        TThis ProjectionOnto(TThis vec);
        Scalar<T> SquareDistanceTo(TThis vec);
        Scalar<T> DistanceTo(TThis vec);
        TThis Lerp(TThis vec, Scalar<T> t);
        TThis Scale(TThis vec);
        TThis Add(TThis vec);
        TThis Substract(TThis vec);
        TThis Multiply(Scalar<T> s);
        TThis Divide(Scalar<T> s);
        TThis Negate();
    }
}
