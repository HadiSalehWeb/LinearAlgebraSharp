using LinearAlgebra.Scalars;
using LinearAlgebra.Vectors;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra.Matrices
{
    public interface IMatrix<T>
        where T : struct
    {
        Vector2<int> Dimension { get; }
        Scalar<T>[,] Data { get; }
    }
}
