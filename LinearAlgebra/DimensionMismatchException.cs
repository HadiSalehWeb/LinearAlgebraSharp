using System;

namespace LinearAlgebra
{
    public class DimensionMismatchException<TDimension, TTensor> : ArgumentException
    {
        public DimensionMismatchException(string paramName, TDimension paramDimension, TDimension thisDimension)
            : base
            (
                  $"Dimension mismatch between <{ typeof(TTensor).ToString() } { paramName }, dimension = { paramDimension.ToString() }> and <{ typeof(TTensor).ToString() } this, dimension = { thisDimension.ToString() }>.",
                  paramName
            )
        { }
    }
}
