using LinearAlgebraSharp.Scalars;
using LinearAlgebraSharp.Vectors;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebraSharp.Matrices
{
    /// <typeparam name="T">Element type</typeparam>
    /// <typeparam name="TThis">This type</typeparam>
    /// <typeparam name="TRow">The row shape (Vector2 for a 3x2 matrix)</typeparam>
    /// <typeparam name="TColumn">The column shape (Vector3 for a 3x2 matrix)</typeparam>
    public interface IMatrix<T, TThis, TRow, TColumn> : ITensor<T, Vector2<int>, TThis>
        where T : struct
        where TThis : IMatrix<T, TThis, TRow, TColumn>
        where TRow : IVector<T, TRow>
        where TColumn : IVector<T, TColumn>
    {
        Scalar<T>[,] Data { get; }
        TRow[] Rows { get; }
        TColumn[] Columns { get; }
        TColumn MultiplyLeft(TRow vec);
        TRow MultiplyRight(TColumn vec);
    }
}