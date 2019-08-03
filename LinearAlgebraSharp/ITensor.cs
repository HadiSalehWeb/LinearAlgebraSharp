using LinearAlgebraSharp.Scalars;
using LinearAlgebraSharp.Vectors;
using System;

namespace LinearAlgebraSharp
{
    public interface ITensor<T, TDimension, TThis> : ICloneable, IEquatable<TThis>
        where T : struct
        where TDimension : IVector<int, TDimension>
        where TThis : ITensor<T, TDimension, TThis>
    {
        TDimension Dimension { get; }

        TThis ElementwiseProduct(TThis ten);
        TThis ElementwiseQuotient(TThis ten);
        TThis Add(TThis ten);
        TThis Substract(TThis ten);
        TThis Multiply(Scalar<T> s);
        TThis DivideLeft(Scalar<T> s);
        TThis DivideRight(Scalar<T> s);
        TThis Negate();
        TThis Reciprocal();
    }
}
