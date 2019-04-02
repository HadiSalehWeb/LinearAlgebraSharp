using LinearAlgebra.Vectors;

namespace LinearAlgebra
{
    public interface ITensor<T, TDimension, TThis>
        where T : struct
        where TDimension : IVector<int, TDimension>
        where TThis : ITensor<T, TDimension, TThis>
    {
        TDimension Dimension { get; }
    }
}
