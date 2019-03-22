using LinearAlgebra.Scalars;
using LinearAlgebra.Vectors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra.Matrices
{
    public interface IMatrix<T>
        where T : struct, IComparable
    {
        Vector2<int> Dimensions { get; }
        Scalar<T>[,] Data { get; }
    }

    public struct Matrix<T> : ICloneable, IEquatable<Matrix<T>>, IEnumerable, IEnumerable<Scalar<T>>, IEnumerable<T>, IMatrix<T>
        where T : struct, IComparable
    {
        public Vector2<int> Dimensions { get; }
        public Scalar<T>[,] Data { get; }

        public static Matrix<T> Zero(Vector2<int> dimensions)
        {
            Scalar<T>[,] data = new Scalar<T>[dimensions.x, dimensions.y];
            for (int i = 0; i < dimensions.x; i++)
                for (int j = 0; j < dimensions.y; j++)
                    data[i, j] = Scalar<T>.Zero;

            return new Matrix<T>(data);
        }
        public static Matrix<T> Zero(int dimension)
        {
            return Zero(new Vector2<int>(dimension));
        }

        public static Matrix<T> One(int dimension)
        {
            Scalar<T>[,] data = new Scalar<T>[dimension, dimension];
            for (int i = 0; i < dimension; i++)
                for (int j = 0; j < dimension; j++)
                    if (i == j)
                        data[i, j] = Scalar<T>.One;
                    else
                        data[i, j] = Scalar<T>.Zero;

            return new Matrix<T>(data);
        }

        public Matrix(Scalar<T>[,] data)
        {
            Dimensions = new Vector2<int>(data.GetLength(0), data.GetLength(1));
            Data = data;
        }

        public Matrix(T[,] data)
        {
            Dimensions = new Vector2<int>(data.GetLength(0), data.GetLength(1));
            Data = new Scalar<T>[Dimensions.x, Dimensions.y];

            for (int i = 0; i < Dimensions.x; i++)
                for (int j = 0; j < Dimensions.y; j++)
                    Data[i, j] = new Scalar<T>(data[i, j]);
        }

        public Scalar<T> this[int i, int j] => Data[i, j];

        public Vector<T>[] Rows
        {
            get
            {
                Vector<T>[] rows = new Vector<T>[Dimensions.x];

                for (int i = 0; i < Dimensions.x; i++)
                {
                    Scalar<T>[] data = new Scalar<T>[Dimensions.y];

                    for (int j = 0; j < Dimensions.y; j++)
                        data[j] = Data[i, j];

                    rows[i] = data;
                }

                return rows;
            }
        }

        public Vector<T>[] Columns
        {
            get
            {
                Vector<T>[] columns = new Vector<T>[Dimensions.y];

                for (int j = 0; j < Dimensions.y; j++)
                {
                    Scalar<T>[] data = new Scalar<T>[Dimensions.x];

                    for (int i = 0; i < Dimensions.x; i++)
                        data[j] = Data[i, j];

                    columns[j] = data;
                }

                return columns;
            }
        }

        public Vector<T> Transform(Vector<T> v)
        {
            return this * v;
        }

        public Matrix<T> Transform(Matrix<T> m)
        {
            return this * m;
        }

        public Matrix<T> Submatrix(Vector2<int> start, Vector2<int> count)
        {
            if (start.x < 0 || start.y < 0 ||
                start.x >= Dimensions.x || start.y >= Dimensions.y ||
                count.x < 0 || count.y < 0 ||
                start.x + count.x > Dimensions.x || start.y + count.y > Dimensions.y)
                throw new Exception("make a message here");

            Scalar<T>[,] data = new Scalar<T>[count.x, count.y];

            for (int i = start.x; i < count.x; i++)
                for (int j = start.y; j < count.y; j++)
                    data[i - start.x, j - start.y] = Data[i, j];

            return new Matrix<T>(data);
        }

        public Matrix<T> Transpose()
        {
            Scalar<T>[,] data = new Scalar<T>[Dimensions.y, Dimensions.x];

            for (int i = 0; i < Dimensions.x; i++)
                for (int j = 0; j < Dimensions.y; j++)
                    data[j, i] = Data[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator *(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimensions.y != right.Dimensions.x) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[,] data = new Scalar<T>[left.Dimensions.x, right.Dimensions.y];

            for (int i = 0; i < left.Dimensions.x; i++)
                for (int j = 0; j < right.Dimensions.y; j++)
                    for (int k = 0; k < left.Dimensions.y; k++)
                        data[i, j] = left[i, k] * right[k, j];

            return new Matrix<T>(data);
        }

        public static Vector<T> operator *(Matrix<T> left, Vector<T> right)
        {
            if (left.Dimensions.y != right.Dimension) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[] data = new Scalar<T>[left.Dimensions.x];
            int i = 0, j = 0;
            for (i = 0, data[i] = Scalar<T>.Zero; i < left.Dimensions.x; i++)
                for (j = 0; j < right.Dimension; j++)
                    data[i] += left[i, j] * right[j];

            return new Vector<T>(data);
        }

        public static Matrix<T> operator +(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimensions != right.Dimensions) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[,] data = new Scalar<T>[left.Dimensions.x, left.Dimensions.y];

            for (int i = 0; i < left.Dimensions.x; i++)
                for (int j = 0; j < left.Dimensions.y; j++)
                    data[i, j] = left[i, j] + right[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator -(Matrix<T> left, Matrix<T> right)
        {
            if (left.Dimensions != right.Dimensions) throw new ArgumentException("Incompatible dimensions.");

            Scalar<T>[,] data = new Scalar<T>[left.Dimensions.x, left.Dimensions.y];

            for (int i = 0; i < left.Dimensions.x; i++)
                for (int j = 0; j < left.Dimensions.y; j++)
                    data[i, j] = left[i, j] - right[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator *(Scalar<T> left, Matrix<T> right)
        {
            Scalar<T>[,] data = new Scalar<T>[right.Dimensions.x, right.Dimensions.y];

            for (int i = 0; i < right.Dimensions.x; i++)
                for (int j = 0; j < right.Dimensions.y; j++)
                    data[i, j] = left * right[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator *(Matrix<T> left, Scalar<T> right)
        {
            return right * left;
        }

        public static Matrix<T> operator /(Scalar<T> left, Matrix<T> right)
        {
            Scalar<T>[,] data = new Scalar<T>[right.Dimensions.x, right.Dimensions.y];

            for (int i = 0; i < right.Dimensions.x; i++)
                for (int j = 0; j < right.Dimensions.y; j++)
                    data[i, j] = left / right[i, j];

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator /(Matrix<T> left, Scalar<T> right)
        {
            Scalar<T>[,] data = new Scalar<T>[left.Dimensions.x, left.Dimensions.y];

            for (int i = 0; i < left.Dimensions.x; i++)
                for (int j = 0; j < left.Dimensions.y; j++)
                    data[i, j] = left[i, j] / right;

            return new Matrix<T>(data);
        }

        public static Matrix<T> operator -(Matrix<T> m)
        {
            var data = new Scalar<T>[m.Dimensions.x, m.Dimensions.y];

            for (int i = 0; i < m.Dimensions.x; i++)
                for (int j = 0; j < m.Dimensions.y; j++)
                    data[i, j] = -m.Data[i, j];

            return new Matrix<T>(data);
        }

        public object Clone()
        {
            return new Matrix<T>(Data);
        }

        public bool Equals(Matrix<T> other)
        {
            if (Dimensions != other.Dimensions)
                return false;

            for (int i = 0; i < Dimensions.x; i++)
                for (int j = 0; j < Dimensions.y; j++)
                    if (Data[i, j] != other.Data[i, j])
                        return false;

            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<Scalar<T>> IEnumerable<Scalar<T>>.GetEnumerator()
        {
            for (int i = 0; i < Dimensions.x; i++)
                for (int j = 0; j < Dimensions.y; j++)
                    yield return Data[i, j];
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < Dimensions.x; i++)
                for (int j = 0; j < Dimensions.y; j++)
                    yield return Data[i, j].Value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Matrix<T> m)
                return Equals(m);

            return false;
        }

        public override string ToString()
        {
            var res = new StringBuilder($"Matrix{ Dimensions.x }x{ Dimensions.y } {{");

            res.AppendLine();

            for (int i = 0; i < Dimensions.x; i++)
            {
                res.Append("\t{ ");
                for (int j = 0; j < Dimensions.y; j++)
                {
                    res.Append(Data[i, j]);
                    if (j != Dimensions.y - 1)
                        res.Append(", ");
                }
                res.AppendLine(" }");
            }

            res.Append("}");

            return res.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
