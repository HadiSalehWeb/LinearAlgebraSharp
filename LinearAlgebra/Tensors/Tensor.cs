using LinearAlgebra.Scalars;
using LinearAlgebra.Vectors;
using System;
using System.Linq;

namespace LinearAlgebra.Tensors
{
    public class Tensor<TVec, T>
        where TVec : IVector<int>
        where T : struct, IComparable
    {
        public Array Data { get; }
        public TVec Dimensions { get; }

        public Tensor(TVec dimensions)
        {
            Dimensions = dimensions;
            Data = Array.CreateInstance(typeof(T), dimensions.Data.Select(x => x.Value).ToArray());
        }

        public Tensor(TVec dimensions, Array data)
        {
            Dimensions = dimensions;
            Data = data;
        }

        public T GetComponent(TVec position)
        {
            return (T)Data.GetValue(position.Data.Select(x => x.Value).ToArray());
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}