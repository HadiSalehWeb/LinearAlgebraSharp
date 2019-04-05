using LinearAlgebra.Scalars;
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

    public static class ITensorExtensions
    {
        public static Scalar<int> Rank<T, TDimension, TThis>(this TThis tensor)
        where T : struct
        where TDimension : IVector<int, TDimension>
        where TThis : ITensor<T, TDimension, TThis>
        {
            return tensor.Dimension.Dimension.x;
        }
    }
}
