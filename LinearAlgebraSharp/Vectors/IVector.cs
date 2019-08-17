using LinearAlgebraSharp.Scalars;
using System.Collections;
using System.Collections.Generic;

namespace LinearAlgebraSharp.Vectors
{
    public interface IVector<T, TThis> :
        IEnumerable,
        IEnumerable<Scalar<T>>,
        IEnumerable<T>,
        ITensor<T, Vector1<int>, TThis>
        where T : struct
        where TThis : IVector<T, TThis>
    {
        int Length { get; }
        Scalar<T>[] Data { get; }
        Scalar<T> Magnitude { get; }
        Scalar<T> SqrMagnitude { get; }
        TThis Normalized { get; }

        TThis SetComponent(int component, Scalar<T> value);

        Scalar<T> Norm(int p);
        Scalar<T> MaximumNorm();
        Scalar<T> Dot(TThis vec);

        Scalar<T> AngleTo(TThis vec);
        TThis ProjectionOnto(TThis vec);
        Scalar<T> SquareDistanceTo(TThis vec);
        Scalar<T> DistanceTo(TThis vec);
        TThis Lerp(TThis vec, Scalar<T> t);
    }
}
