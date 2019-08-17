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
        public Scalar<T>[] Data { get; }
        public TVec Dimension { get; }
        public Scalar<int> Depth => Dimension.Length;

        private TVec Indexer { get; }

        public Tensor(TVec dimension)
        {
            Dimension = dimension;

            Data = new Scalar<T>[Dimension.Data.Aggregate(1, (a, c) => a * c.Value)];

            Indexer = ConstructIndexer(dimension);
        }

        public Tensor(TVec dimension, Scalar<T>[] data)
        {
            Dimension = dimension;
            Data = data;

            Indexer = ConstructIndexer(dimension);
        }

        private TVec ConstructIndexer(TVec dimension)
        {
            TVec indexer = (TVec)dimension.Clone();
            for (int i = 0; i < dimension.Length; i++)
            {
                int x = 1;
                for (int j = i + 1; j < dimension.Length; j++)
                    x *= dimension.Data[j];
                indexer = indexer.SetComponent(i, x);
            }
            return indexer;
        }

        public Scalar<T> GetComponent(TVec index)
        {
            return Data[index.Dot(Indexer)];
        }

        public override string ToString()
        {
            return ToStringRecursive(Data, Depth);
        }

        private string ToStringRecursive(Scalar<T>[] data, int depth)
        {
            if (depth <= 1)
                return '[' + string.Join(", ", data) + ']';

            var tabbedNewline = Environment.NewLine + new string('\t', Depth - depth + 1);
            return
                '[' + tabbedNewline +
                string.Join(',' + tabbedNewline,
                    Enumerable.Range(0, Dimension.Data[Depth - depth]).Select(i => ToStringRecursive(
                        data.Skip(i * Indexer.Data[Depth - depth]).Take(Indexer.Data[Depth - depth]).ToArray(), depth - 1))
                ) +
                Environment.NewLine + new string('\t', Depth - depth) + ']';
        }

        public Tensor<TVec, T> ElementwiseProduct(Tensor<TVec, T> ten)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i] * ten.Data[i];

            return new Tensor<TVec, T>(Dimension, data);
        }

        public Tensor<TVec, T> ElementwiseQuotient(Tensor<TVec, T> ten)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i] / ten.Data[i];

            return new Tensor<TVec, T>(Dimension, data);
        }

        public Tensor<TVec, T> Add(Tensor<TVec, T> ten)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i] + ten.Data[i];

            return new Tensor<TVec, T>(Dimension, data);
        }

        public Tensor<TVec, T> Substract(Tensor<TVec, T> ten)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i] - ten.Data[i];

            return new Tensor<TVec, T>(Dimension, data);
        }

        public Tensor<TVec, T> Multiply(Scalar<T> s)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i] * s;

            return new Tensor<TVec, T>(Dimension, data);
        }

        public Tensor<TVec, T> DivideLeft(Scalar<T> s)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i].DivideLeft(s);

            return new Tensor<TVec, T>(Dimension, data);
        }

        public Tensor<TVec, T> DivideRight(Scalar<T> s)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i].DivideRight(s);

            return new Tensor<TVec, T>(Dimension, data);
        }

        public Tensor<TVec, T> Negate()
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i].Negate();

            return new Tensor<TVec, T>(Dimension, data);
        }

        public Tensor<TVec, T> Reciprocal()
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i].Reciprocal();

            return new Tensor<TVec, T>(Dimension, data);
        }

        public object Clone()
        {
            return new Tensor<TVec, T>((TVec)Dimension.Clone(), (Scalar<T>[])this.Data.Clone());
        }

        public bool Equals(Tensor<TVec, T> other)
        {
            for (int i = 0; i < Data.Length; i++)
                if (Data[i] != other.Data[i])
                    return false;

            return true;
        }
    }
}