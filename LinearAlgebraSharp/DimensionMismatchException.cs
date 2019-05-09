using LinearAlgebraSharp.Vectors;
using System;

namespace LinearAlgebraSharp
{
    public class DimensionMismatchException<T, TDimension, TTensor> : ArgumentException
        where TDimension : IVector<int, TDimension>
        where TTensor : ITensor<T, TDimension, TTensor>
        where T : struct
    {
        public DimensionMismatchException(string paramName, TDimension paramDimension, TDimension thisDimension)
            : base
            (
                  $"Dimension mismatch between <{ paramName } : { typeof(TTensor).ToString() }, dimension = { paramDimension.ToString() }> and <this : { typeof(TTensor).ToString() }, dimension = { thisDimension.ToString() }>.",
                  paramName
            )
        { }
    }
}
