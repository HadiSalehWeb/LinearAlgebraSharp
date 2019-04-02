using LinearAlgebra.Scalars;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinearAlgebra.Vectors
{
    public struct Vector<T> :
        ICloneable,
        IEquatable<Vector<T>>,
        IEnumerable,
        IEnumerable<Scalar<T>>,
        IEnumerable<T>,
        IVector<T, Vector<T>>
        where T : struct
    {
        public Scalar<int> Rank => 1;
        public Vector1<int> Dimension { get; }
        public int Length => Dimension;

        public Scalar<T>[] Data { get; }
        public Scalar<T> this[int i] => Data[i];

        /// <summary>
        /// (1)
        /// </summary>
        public static readonly Vector<T> right = new Vector<T>(Scalar<T>.One);
        /// <summary>
        /// (-1)
        /// </summary>
        public static readonly Vector<T> left = new Vector<T>(-Scalar<T>.One);
        /// <summary>
        /// (0, 1)
        /// </summary>
        public static readonly Vector<T> up = new Vector<T>(Scalar<T>.Zero, Scalar<T>.One);
        /// <summary>
        /// (0, -1)
        /// </summary>
        public static readonly Vector<T> down = new Vector<T>(Scalar<T>.Zero, -Scalar<T>.One);
        /// <summary>
        /// (0, 0, 1)
        /// </summary>
        public static readonly Vector<T> forward = new Vector<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One);
        /// <summary>
        /// (0, 0, -1)
        /// </summary>
        public static readonly Vector<T> backward = new Vector<T>(Scalar<T>.Zero, Scalar<T>.Zero, -Scalar<T>.One);
        /// <summary>
        /// (0, 0, 0, 1)
        /// </summary>
        public static readonly Vector<T> ana = new Vector<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.One);
        /// <summary>
        /// (0, 0, 0, -1)
        /// </summary>
        public static readonly Vector<T> kata = new Vector<T>(Scalar<T>.Zero, Scalar<T>.Zero, Scalar<T>.Zero, -Scalar<T>.One);

        public static Vector<T> Zero(int dimension)
        {
            return new Vector<T>(Enumerable.Range(0, dimension).Select(_ => Scalar<T>.Zero).ToArray());
        }

        public static Vector<T> One(int dimension)
        {
            return new Vector<T>(Enumerable.Range(0, dimension).Select(_ => Scalar<T>.One).ToArray());
        }

        /// <summary>
        /// Retrurns an n-dimensional vector with the i-th element set to one
        /// </summary>
        /// <param name="dimension">the 'n' in n-dimensional, the dimension of the vector</param>
        /// <param name="basis">the 'i' in i-th element, the 1-based axis of the vector</param>
        /// <returns></returns>
        public static Vector<T> Basis(int dimension, int basis)
        {
            return new Vector<T>(Enumerable.Range(0, dimension).Select(i => i == basis + 1 ? Scalar<T>.One : Scalar<T>.Zero).ToArray());
        }

        public static Vector<T> Repeat(T t, int dimension)
        {
            var arr = new Scalar<T>[dimension];

            for (int i = 0; i < dimension; i++)
                arr[i] = new Scalar<T>(t);

            return new Vector<T>(arr);
        }

        public static Vector<T> Range(T start, int dimension)
        {
            var arr = new Scalar<T>[dimension];
            arr[0] = new Scalar<T>(start);

            for (int i = 1; i < dimension; i++)
                arr[i - 1] = arr[i] + Scalar<T>.One;

            return new Vector<T>(arr);
        }

        public Vector(params Scalar<T>[] data)
        {
            Dimension = data.Length;
            Data = data;
        }

        public Vector(params T[] data)
        {
            Dimension = data.Length;
            Data = data.Select(x => new Scalar<T>(x)).ToArray();
        }

        public Scalar<T> SqrMagnitude => Dot(this);
        public Scalar<T> Magnitude => Math.Sqrt(SqrMagnitude);
        public Vector<T> Normalized => this / Magnitude;

        public Vector<T> Subvector(int start, int count)
        {
            if (start < 0 || start >= Dimension || count < 0 || start + count > Dimension)
                throw new Exception("make a message here");

            return new Vector<T>(Data.Skip(start).Take(count).ToArray());
        }

        public Vector<T> ExpandBy(int length)
        {
            return new Vector<T>(Data.Concat(Zero(length).Data).ToArray());
        }

        public Vector<T> ExpandTo(int targetLength)
        {
            if (targetLength >= Length)
                return new Vector<T>(Data.Concat(Zero(targetLength - Length).Data).ToArray());

            throw new ArgumentException($"{ nameof(targetLength) } must be greater than or equal to the length of this vector.");
        }

        public Scalar<T> Dot(Vector<T> vec)
        {
            if (Dimension != vec.Dimension)
                throw new DimensionMismatchException<Vector1<int>, Vector<T>>(nameof(vec), vec.Dimension, Dimension);

            Scalar<T> result = Scalar<T>.Zero;

            for (int i = 0; i < Dimension; i++)
            {
                result += Data[i] * vec.Data[i];
            }

            return result;
        }

        public Vector<T> Cross(Vector<T> vec)
        {
            if (Dimension != vec.Dimension)
                throw new DimensionMismatchException<Vector1<int>, Vector<T>>(nameof(vec), vec.Dimension, Dimension);

            if (Dimension == 0) return new Vector<T>(new Scalar<T>[0]);
            if (Dimension == 1) return new Vector<T>(Scalar<T>.Zero);
            if (Dimension == 3) return new Vector<T>(
                Data[1] * vec.Data[2] - Data[2] * vec.Data[1],
                Data[2] * vec.Data[0] - Data[0] * vec.Data[2],
                Data[0] * vec.Data[1] - Data[1] * vec.Data[0]
            );
            if (Dimension == 7) return new Vector<T>(
                Data[1] * vec.Data[3] - Data[3] * vec.Data[1] + Data[2] * vec.Data[6] - Data[6] * vec.Data[2] + Data[4] * vec.Data[5] - Data[5] * vec.Data[4],
                Data[2] * vec.Data[4] - Data[4] * vec.Data[2] + Data[3] * vec.Data[0] - Data[0] * vec.Data[3] + Data[5] * vec.Data[6] - Data[6] * vec.Data[5],
                Data[3] * vec.Data[5] - Data[5] * vec.Data[3] + Data[4] * vec.Data[1] - Data[1] * vec.Data[4] + Data[6] * vec.Data[0] - Data[0] * vec.Data[6],
                Data[4] * vec.Data[6] - Data[6] * vec.Data[4] + Data[5] * vec.Data[2] - Data[2] * vec.Data[5] + Data[0] * vec.Data[1] - Data[1] * vec.Data[0],
                Data[5] * vec.Data[0] - Data[0] * vec.Data[5] + Data[6] * vec.Data[3] - Data[3] * vec.Data[6] + Data[1] * vec.Data[2] - Data[2] * vec.Data[1],
                Data[6] * vec.Data[1] - Data[1] * vec.Data[6] + Data[0] * vec.Data[4] - Data[4] * vec.Data[0] + Data[2] * vec.Data[3] - Data[3] * vec.Data[2],
                Data[0] * vec.Data[2] - Data[2] * vec.Data[0] + Data[1] * vec.Data[5] - Data[5] * vec.Data[1] + Data[3] * vec.Data[4] - Data[4] * vec.Data[3]
            );

            throw new Exception("Cross product can only be performed on vectors of dimension 0, 1, 3 and 7.");
        }

        public Vector<T> Scale(Vector<T> vec)
        {
            if (Dimension != vec.Dimension)
                throw new DimensionMismatchException<Vector1<int>, Vector<T>>(nameof(vec), vec.Dimension, Dimension);

            Scalar<T>[] result = new Scalar<T>[Dimension];

            for (int i = 0; i < Dimension; i++)
                result[i] = Data[i] * vec.Data[i];

            return new Vector<T>(result);
        }

        public static Vector<T> operator +(Vector<T> left, Vector<T> right)
        {
            return left.Add(right);
        }

        public static Vector<T> operator -(Vector<T> left, Vector<T> right)
        {
            return left.Substract(right);
        }

        public static Vector<T> operator *(Vector<T> left, Scalar<T> right)
        {
            return left.Multiply(right);
        }

        public static Vector<T> operator *(Scalar<T> left, Vector<T> right)
        {
            return right.Multiply(left);
        }

        public static Vector<T> operator /(Vector<T> left, Scalar<T> right)
        {
            return left.Divide(right);
        }

        public static Vector<T> operator /(Scalar<T> left, Vector<T> right)
        {
            return right.GetDividedBy(left);
        }

        public static Vector<T> operator -(Vector<T> v)
        {
            return v.Negate();
        }

        public static bool operator ==(Vector<T> left, Vector<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector<T> left, Vector<T> right)
        {
            return !left.Equals(right);
        }

        public static implicit operator Vector<T>(T[] value)
        {
            return new Vector<T>(value);
        }

        //public static implicit operator Vector<T>(T t)
        //{
        //    return new Vector<T>(t);
        //}

        //public static implicit operator Vector<T>((T, T) tuple)
        //{
        //    return new Vector<T>(tuple.Item1, tuple.Item2);
        //}

        //public static implicit operator Vector<T>((T, T, T) tuple)
        //{
        //    return new Vector<T>(tuple.Item1, tuple.Item2, tuple.Item3);
        //}

        //public static implicit operator Vector<T>((T, T, T, T) tuple)
        //{
        //    return new Vector<T>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
        //}

        //public static implicit operator Vector<T>((T, T, T, T, T) tuple)
        //{
        //    return new Vector<T>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
        //}

        //public static implicit operator Vector<T>((T, T, T, T, T, T) tuple)
        //{
        //    return new Vector<T>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);
        //}

        //public static implicit operator Vector<T>((T, T, T, T, T, T, T) tuple)
        //{
        //    return new Vector<T>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7);
        //}

        //public static implicit operator Vector<T>((T, T, T, T, T, T, T, T) tuple)
        //{
        //    return new Vector<T>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8);
        //}

        //public static implicit operator Vector<T>((T, T, T, T, T, T, T, T, T) tuple)
        //{
        //    return new Vector<T>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9);
        //}

        //public static implicit operator Vector<T>((T, T, T, T, T, T, T, T, T, T) tuple)
        //{
        //    return new Vector<T>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7, tuple.Item8, tuple.Item9, tuple.Item10);
        //}

        public object Clone()
        {
            return new Vector<T>(Data);
        }

        public bool Equals(Vector<T> other)
        {
            int i = 0;
            return Data.All(x => x == other.Data[i++]);
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            foreach (var d in Data)
                yield return d;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var d in Data)
                yield return d.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector<T> v)
                return Equals(v);

            return false;
        }

        public override string ToString()
        {
            return $"Vector{ Dimension }({ string.Join(", ", Data) })";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Vector<T> Add(Vector<T> vec)
        {
            if (Dimension != vec.Dimension) throw new ArgumentException("Parameter 'v' must be in the same dimension as the current vector.");

            return new Vector<T>(Data.Select((x, i) => x + vec.Data[i]).ToArray());
        }

        public Vector<T> Substract(Vector<T> vec)
        {
            if (Dimension != vec.Dimension) throw new ArgumentException("Parameter 'v' must be in the same dimension as the current vector.");

            return new Vector<T>(Data.Select((x, i) => x - vec.Data[i]).ToArray());
        }

        public Vector<T> Multiply(Scalar<T> s)
        {
            return new Vector<T>(Data.Select((x, i) => x * s).ToArray());
        }

        public Vector<T> Divide(Scalar<T> s)
        {
            return new Vector<T>(Data.Select((x, i) => x / s).ToArray());
        }

        public Vector<T> GetDividedBy(Scalar<T> s)
        {
            return new Vector<T>(Data.Select((x, i) => s / x).ToArray());
        }

        public Vector<T> Negate()
        {
            return new Vector<T>(Data.Select(x => -x).ToArray());
        }
    }
}
