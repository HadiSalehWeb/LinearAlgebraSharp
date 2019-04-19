using System;

namespace LinearAlgebra
{
    public class DimensionMismatchException<TDimension, TTensor> : ArgumentException
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
