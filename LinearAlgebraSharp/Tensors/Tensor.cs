using LinearAlgebraSharp.Scalars;
using LinearAlgebraSharp.Vectors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinearAlgebraSharp.Tensors
{
    [Serializable]
    public class Tensor<TDimension, T> : ITensor<T, TDimension, Tensor<TDimension, T>>
        where TDimension : IVector<int, TDimension>
        where T : struct
    {
        #region Fields and Properties

        public Scalar<int> Order => Dimension.Length;
        public TDimension Dimension { get; }
        public Scalar<T>[] Data { get; }

        private TDimension Indexer { get; }

        #endregion

        #region Static

        /// <summary>
        /// Returns a tensor of shape 'dimensions' filled with 'filling'.
        /// </summary>
        public static Tensor<TDimension, T> Fill(TDimension dimensions, Scalar<T> filling)
        {
            return new Tensor<TDimension, T>(dimensions, Enumerable.Repeat(filling, dimensions.Data.Aggregate(1, (a, c) => a * c.Value)).ToArray());
        }

        /// <summary>
        /// Returns a tensor of shape 'dimensions' filled with zeros.
        /// </summary>
        public static Tensor<TDimension, T> Zeros(TDimension dimensions)
        {
            return Fill(dimensions, Scalar<T>.Zero);
        }

        /// <summary>
        /// Returns a tensor of shape 'dimensions' filled with ones.
        /// </summary>
        public static Tensor<TDimension, T> Ones(TDimension dimensions)
        {
            return Fill(dimensions, Scalar<T>.One);
        }

        /// <summary>
        /// Returns a tensor of shape 'dimensions' filled with the scalars starting from 'start' and increasing by 'increment' every element.
        /// </summary>
        /// <param name="increment">Defaults to Scalar&lt;<typeparamref name="T"/>&gt;.One</param>
        public static Tensor<TDimension, T> Range(TDimension dimensions, Scalar<T> start, Scalar<T>? increment = null)
        {
            var concreteIncrement = increment ?? Scalar<T>.One;

            var len = dimensions.Data.Aggregate(1, (a, c) => a * c.Value);
            var data = new Scalar<T>[len];

            for (int i = 0; i < len; i++)
            {
                data[i] = start;
                start += concreteIncrement;
            }

            return new Tensor<TDimension, T>(dimensions, data);
        }

        #endregion

        #region Constructors

        public Tensor(TDimension dimension, Scalar<T>[] data)
        {
            Dimension = dimension;

            Data = data;

            Indexer = ConstructIndexer(dimension);
        }

        public Tensor(TDimension dimension, T[] data) : this(dimension, data.Select(x => new Scalar<T>(x)).ToArray()) { }

        public Tensor(TDimension dimension) : this(dimension, new Scalar<T>[dimension.Data.Aggregate(1, (a, c) => a * c.Value)]) { }

        private TDimension ConstructIndexer(TDimension dimension)
        {
            TDimension indexer = (TDimension)dimension.Clone();
            for (int i = 0; i < dimension.Length; i++)
            {
                int x = 1;
                for (int j = i + 1; j < dimension.Length; j++)
                    x *= dimension.Data[j];
                indexer = indexer.SetComponent(i, x);
            }
            return indexer;
        }

        #endregion

        #region Functions

        public Scalar<T> GetComponent(TDimension index)
        {
            return Data[index.Dot(Indexer)];
        }

        public Tensor<TDimension, T> ElementwiseProduct(Tensor<TDimension, T> ten)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i] * ten.Data[i];

            return new Tensor<TDimension, T>(Dimension, data);
        }

        public Tensor<TDimension, T> ElementwiseQuotient(Tensor<TDimension, T> ten)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i] / ten.Data[i];

            return new Tensor<TDimension, T>(Dimension, data);
        }

        #endregion

        #region Operators

        #region Arithmetic

        public Tensor<TDimension, T> Add(Tensor<TDimension, T> ten)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i] + ten.Data[i];

            return new Tensor<TDimension, T>(Dimension, data);
        }

        public static Tensor<TDimension, T> operator +(Tensor<TDimension, T> left, Tensor<TDimension, T> right)
        {
            return left.Add(right);
        }

        public Tensor<TDimension, T> Substract(Tensor<TDimension, T> ten)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i] - ten.Data[i];

            return new Tensor<TDimension, T>(Dimension, data);
        }

        public static Tensor<TDimension, T> operator -(Tensor<TDimension, T> left, Tensor<TDimension, T> right)
        {
            return left.Substract(right);
        }

        public Tensor<TDimension, T> Multiply(Scalar<T> s)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i] * s;

            return new Tensor<TDimension, T>(Dimension, data);
        }

        public static Tensor<TDimension, T> operator *(Scalar<T> left, Tensor<TDimension, T> right)
        {
            return right.Multiply(left);
        }

        public static Tensor<TDimension, T> operator *(Tensor<TDimension, T> left, Scalar<T> right)
        {
            return left.Multiply(right);
        }

        public Tensor<TDimension, T> DivideLeft(Scalar<T> s)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i].DivideLeft(s);

            return new Tensor<TDimension, T>(Dimension, data);
        }

        public static Tensor<TDimension, T> operator /(Tensor<TDimension, T> left, Scalar<T> right)
        {
            return left.DivideLeft(right);
        }

        public Tensor<TDimension, T> DivideRight(Scalar<T> s)
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i].DivideRight(s);

            return new Tensor<TDimension, T>(Dimension, data);
        }

        public static Tensor<TDimension, T> operator /(Scalar<T> left, Tensor<TDimension, T> right)
        {
            return right.DivideRight(left);
        }

        public Tensor<TDimension, T> Reciprocal()
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i].Reciprocal();

            return new Tensor<TDimension, T>(Dimension, data);
        }

        public Tensor<TDimension, T> Negate()
        {
            Scalar<T>[] data = new Scalar<T>[Data.Length];

            for (int i = 0; i < Data.Length; i++)
                data[i] = Data[i].Negate();

            return new Tensor<TDimension, T>(Dimension, data);
        }

        public static Tensor<TDimension, T> operator -(Tensor<TDimension, T> m)
        {
            return m.Negate();
        }

        #endregion

        #region Identity

        public static bool operator ==(Tensor<TDimension, T> left, Tensor<TDimension, T> right)
        {
            if (!left.Dimension.Equals(right.Dimension)) throw new DimensionMismatchException<T, TDimension, Tensor<TDimension, T>>(nameof(right), right.Dimension, left.Dimension);

            for (int i = 0; i < left.Data.Length; i++)
                if (left.Data[i] != right.Data[i])
                    return false;

            return true;
        }

        public static bool operator !=(Tensor<TDimension, T> left, Tensor<TDimension, T> right)
        {
            if (!left.Dimension.Equals(right.Dimension)) throw new DimensionMismatchException<T, TDimension, Tensor<TDimension, T>>(nameof(right), right.Dimension, left.Dimension);

            for (int i = 0; i < left.Data.Length; i++)
                if (left.Data[i] != right.Data[i])
                    return true;

            return false;
        }

        #endregion

        #endregion

        #region Interface Implementations

        public object Clone()
        {
            return new Tensor<TDimension, T>((TDimension)Dimension.Clone(), (Scalar<T>[])this.Data.Clone());
        }

        public bool Equals(Tensor<TDimension, T> other)
        {
            if (!Dimension.Equals(other.Dimension)) throw new DimensionMismatchException<T, TDimension, Tensor<TDimension, T>>(nameof(other), other.Dimension, Dimension);

            for (int i = 0; i < Data.Length; i++)
                if (Data[i] != other.Data[i])
                    return false;

            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            for (int i = 0; i < Data.Length; i++)
                yield return Data[i];
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < Data.Length; i++)
                yield return Data[i].Value;
        }

        public override bool Equals(object obj)
        {
            return obj is Tensor<TDimension, T> tensor && Equals(tensor);
        }

        public override string ToString()
        {
            return ToStringRecursive(Data, Order);
        }

        private string ToStringRecursive(Scalar<T>[] data, int depth)
        {
            if (depth <= 1)
                return '[' + string.Join(", ", data) + ']';

            var tabbedNewline = Environment.NewLine + new string('\t', Order - depth + 1);
            return
                '[' + tabbedNewline +
                string.Join(',' + tabbedNewline,
                    Enumerable.Range(0, Dimension.Data[Order - depth]).Select(i => ToStringRecursive(
                        data.Skip(i * Indexer.Data[Order - depth]).Take(Indexer.Data[Order - depth]).ToArray(), depth - 1))
                ) +
                Environment.NewLine + new string('\t', Order - depth) + ']';
        }

        public override int GetHashCode()
        {
            int hash = 1;

            for (int i = 0; i < Data.Length; i++)
                hash = hash * 31 + Data[i].GetHashCode();

            return hash;
        }

        #endregion
    }
}