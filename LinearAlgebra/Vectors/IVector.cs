using LinearAlgebra.Scalars;

namespace LinearAlgebra.Vectors
{
    public interface IVector<T, TThis> : ITensor<T, Vector1<int>, IVector<T, TThis>>
        where T : struct
        where TThis : IVector<T, TThis>
    {
        //Vector1<int> Dimension { get; }
        Scalar<T>[] Data { get; }
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
