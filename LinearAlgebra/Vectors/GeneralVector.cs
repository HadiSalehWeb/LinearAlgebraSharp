using LinearAlgebra.Scalars;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinearAlgebra.Vectors
{
    public interface IVector<T>
        where T : struct, IComparable
    {
        Scalar<int> Dimension { get; }
        Scalar<T>[] Data { get; }
    }

    public struct Vector<T> : ICloneable, IEquatable<Vector<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IVector<T>
        where T : struct, IComparable
    {
        public Scalar<int> Dimension { get; }

        public Scalar<T>[] Data { get; }
        public Scalar<T> this[int i] => Data[i];

        public static Vector<T> Zero(int dimension)
        {
            return new Vector<T>(Enumerable.Range(0, dimension).Select(_ => Scalar<T>.Zero).ToArray());
        }

        public static Vector<T> One(int dimension)
        {
            return new Vector<T>(Enumerable.Range(0, dimension).Select(_ => Scalar<T>.One).ToArray());
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

        public Vector<T> Subvector(int start, int count)
        {
            if (start < 0 || start >= Dimension || count < 0 || start + count > Dimension)
                throw new Exception("make a message here");

            return new Vector<T>(Data.Skip(start).Take(count).ToArray());
        }

        public static Vector<T> operator +(Vector<T> left, Vector<T> right)
        {
            if (left.Dimension != right.Dimension) throw new ArgumentException("Parameter 'v' must be in the same dimension as the current vector.");

            return new Vector<T>(left.Data.Select((x, i) => x + right.Data[i]).ToArray());
        }

        public static Vector<T> operator -(Vector<T> left, Vector<T> right)
        {
            if (left.Dimension != right.Dimension) throw new ArgumentException("Parameter 'v' must be in the same dimension as the current vector.");

            return new Vector<T>(left.Data.Select((x, i) => x - right.Data[i]).ToArray());
        }

        public static Vector<T> operator *(Vector<T> left, Scalar<T> right)
        {
            return new Vector<T>(left.Data.Select((x, i) => x * right).ToArray());
        }

        public static Vector<T> operator *(Scalar<T> left, Vector<T> right)
        {
            return right * left;
        }

        public static Vector<T> operator /(Vector<T> left, Scalar<T> right)
        {
            return new Vector<T>(left.Data.Select((x, i) => x / right).ToArray());
        }

        public static Vector<T> operator /(Scalar<T> left, Vector<T> right)
        {
            return new Vector<T>(right.Data.Select((x, i) => x / left).ToArray());
        }

        public static Vector<T> operator -(Vector<T> v)
        {
            return new Vector<T>(v.Data.Select(x => -x).ToArray());
        }

        public static bool operator ==(Vector<T> left, Vector<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector<T> left, Vector<T> right)
        {
            return !left.Equals(right);
        }

        public static implicit operator Vector<T>(Scalar<T>[] value)
        {
            return new Vector<T>(value);
        }

        public U Aggregate<U>(U seed, Func<U, T, U> accumulator)
        {
            return Data.Aggregate(seed, (a, c) => accumulator(a, c.Value));
        }

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
    }
}
