using LinearAlgebra.Scalars;
using System;

namespace LinearAlgebra.Vectors
{
    public interface IVector<T, TThis>
        where T : struct, IComparable
        where TThis : IVector<T, TThis>
    {
        Scalar<int> Dimension { get; }
        Scalar<T>[] Data { get; }
        TThis Zero { get; }
        TThis One { get; }
        Scalar<T> Magnitude { get; }
        Scalar<T> SqrMagnitude { get; }
        TThis Normalized { get; }
        Scalar<T> Dot(TThis vec);
        TThis Scale(TThis vec);
        TThis Add(TThis vec);
        TThis Substract(TThis vec);
        TThis Multiply(Scalar<T> s);
        TThis Divide(Scalar<T> s);
        TThis GetDividedBy(Scalar<T> s);
        TThis Negate();
    }
}
