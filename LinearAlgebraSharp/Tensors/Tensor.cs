using LinearAlgebraSharp.Scalars;
using LinearAlgebraSharp.Vectors;
using System;
using System.Linq;

namespace LinearAlgebraSharp.Tensors
{
    [Serializable]
    public class Tensor<TVec, T> : ITensor<T, TVec, Tensor<TVec, T>>
        where TVec : IVector<int, TVec>
        where T : struct
    {
        public T[] Data { get; }
        public TVec Dimensions { get; }
        public Scalar<int> Depth => Dimensions.Length;

        private TVec Indexer { get; }

        public TVec Dimension => throw new NotImplementedException();

        public Tensor(TVec dimensions)
        {
            Dimensions = dimensions;

            Data = new T[Dimensions.Data.Aggregate(1, (a, c) => a * c.Value)];

            TVec indexer = (TVec)dimensions.Clone();
            for (int i = 0; i < dimensions.Length; i++)
            {
                indexer.Data[i] = 1;
                for (int j = i + 1; j < dimensions.Length; j++)
                    indexer.Data[i] *= dimensions.Data[j];
            }
            Indexer = indexer;
        }

        public Tensor(TVec dimensions, T[] data)
        {
            Dimensions = dimensions;
            Data = data;
        }

        public T GetComponent(TVec position)
        {
            return Data[position.Dot(Indexer)];
        }

        //public override string ToString()
        //{
        //    return ToString(Data);
        //}

        public Tensor<TVec, T> ElementwiseProduct(Tensor<TVec, T> ten)
        {
            throw new NotImplementedException();
        }

        public Tensor<TVec, T> ElementwiseQuotient(Tensor<TVec, T> ten)
        {
            throw new NotImplementedException();
        }

        public Tensor<TVec, T> Add(Tensor<TVec, T> ten)
        {
            throw new NotImplementedException();
        }

        public Tensor<TVec, T> Substract(Tensor<TVec, T> ten)
        {
            throw new NotImplementedException();
        }

        public Tensor<TVec, T> Multiply(Scalar<T> s)
        {
            throw new NotImplementedException();
        }

        public Tensor<TVec, T> DivideLeft(Scalar<T> s)
        {
            throw new NotImplementedException();
        }

        public Tensor<TVec, T> DivideRight(Scalar<T> s)
        {
            throw new NotImplementedException();
        }

        public Tensor<TVec, T> Negate()
        {
            throw new NotImplementedException();
        }

        public Tensor<TVec, T> Reciprocal()
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public bool Equals(Tensor<TVec, T> other)
        {
            throw new NotImplementedException();
        }

        //private static string ToString(Array data, int depth = 0)
        //{
        //    var tabs = new string('\t', depth);

        //    if (data is T[] t)
        //        return tabs + "{" + string.Join(",", t.Select(x => " " + x.ToString())) + " }";

        //    var arr = data as Array[];
        //    return tabs + "{" + (arr.Any() ? Environment.NewLine : "") +
        //        string.Join("," + Environment.NewLine, arr.Select(x => ToString(x, depth + 1))) +
        //        (arr.Any() ? Environment.NewLine : "") + tabs + "}";
        //}
    }
}