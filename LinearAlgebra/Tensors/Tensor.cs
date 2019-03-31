using LinearAlgebra.Scalars;
using LinearAlgebra.Vectors;
using System;
using System.Linq;

namespace LinearAlgebra.Tensors
{
    public class Tensor<TVec, T>
        where TVec : IVector<int, TVec>
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
            return ToString(Data);
        }

        private static string ToString(Array data, int depth = 0)
        {
            var tabs = string.Join("", Enumerable.Repeat("\t", depth));

            if (data is T[] t)
                return tabs + "{" + string.Join(",", t.Select(x => " " + x.ToString())) + " }";

            var arr = data as Array[];
            return tabs + "{" + (arr.Any() ? Environment.NewLine : "") +
                string.Join("," + Environment.NewLine, arr.Select(x => ToString(x, depth + 1))) +
                (arr.Any() ? Environment.NewLine : "") + tabs + "}";
        }
    }
}